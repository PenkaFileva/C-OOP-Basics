using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class RaceTower
{
    private const string crashReasson = "Crashed";

    private TyreFactory tyreFactory;
    private DriverFactory driverFactory;    
    private IList<Driver> drivers;
    private Stack<Driver> falledDrivers;
    private Track track;

    public RaceTower()
    {
        this.driverFactory = new DriverFactory();
        this.drivers = new List<Driver>();
        this.falledDrivers = new Stack<Driver>();
        this.tyreFactory = new TyreFactory();
    }

    public bool IsRaceOver => this.track.CurrentLap == this.track.LapsNumber;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track = new Track(lapsNumber, trackLength);
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            string driverType = commandArgs[0];
            string driverName = commandArgs[1];

            int horsePower = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);

            string[] tyreArgs = commandArgs.Skip(4).ToArray();

            Tyre tyre = this.tyreFactory.CreateTyre(tyreArgs);
            Car car = new Car(horsePower, fuelAmount, tyre);
            Driver driver = this.driverFactory.CreateDriver(driverType, driverName, car);
            this.drivers.Add(driver);
        }
        catch {}
    }

    //private Driver CreateDriver(string driverType, string driverName, Car car)
    //{
    //    Driver driver = null;
    //    if (driverType == "Endurance")
    //    {
    //        driver = new EnduranceDriver(driverName, car);
    //        return driver;
    //    }
    //    else if (driverType == "Aggressive")
    //    {
    //        driver = new AggressiveDriver(driverName, car);
    //        return driver;
    //    }

    //    throw new ArgumentException(ErrorMessages.InvalidDriverType);

    //}

    //private Tyre CreateTyre(string[] tyreArgs)
    //{
    //    string tyreType = tyreArgs[0];
    //    double tyreHardness = double.Parse(tyreArgs[1]);
    //    Tyre tyre = null;
    //    if (tyreType == "Hard")
    //    {
    //        tyre = new HardTyre(tyreHardness);
    //    }
    //    else if (tyreType == "Ultrasoft")
    //    {
    //        double grip = double.Parse(tyreArgs[2]);
    //        tyre = new UltrasoftTyre(tyreHardness, grip);
    //    }
    //    if (tyre == null)
    //    {
    //        throw new ArgumentException(ErrorMessages.InvalidTyreType);
    //    }
    //    return tyre;
    //}

    public void DriverBoxes(List<string> commandArgs)
    {
        string boxReason = commandArgs[0];
        string driverName = commandArgs[1];

        Driver driver = this.drivers.FirstOrDefault(d => d.Name == driverName);
        string[] methodArgs = commandArgs.Skip(2).ToArray();

        if (boxReason == "Refuel")
        {
            driver.Refuel(methodArgs);
        }
        else if (boxReason == "ChangeTyres")
        {
            Tyre tyre = this.tyreFactory.CreateTyre(methodArgs);
            driver.ChangeTyres(tyre);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder builder = new StringBuilder();

        int numberOfLaps = int.Parse(commandArgs[0]);

        if (numberOfLaps > this.track.LapsNumber - this.track.CurrentLap)
        {
            try
            {
                throw new ArgumentException(
                    string.Format(ErrorMessages.InvalidLaps, this.track.CurrentLap));
            }
            catch(ArgumentException e)
            {
                return e.Message;
            }
        }
        for (int lap = 0; lap < numberOfLaps; lap++)
        {
            for (int index = 0; index < this.drivers.Count; index++)
            {
                Driver driver = drivers[index];
                try
                {
                    driver.ConpleteLap(this.track.TrackLength);
                }
                catch (ArgumentException e)
                {
                    driver.Fail(e.Message);
                    this.falledDrivers.Push(driver);
                    this.drivers.RemoveAt(index);
                    index--;
                }                
            }
            this.track.CurrentLap++;

            List<Driver> orderedDrivers = this.drivers
                .OrderByDescending(d => d.TotalTime)
                .ToList();

            for (int i = 0; i < orderedDrivers.Count - 1; i++)
            {
                Driver overtakingDriver = orderedDrivers[i];
                Driver targetDriver = orderedDrivers[i + 1];
                bool overtakenHappened = this.TryOverTake(overtakingDriver, targetDriver);

                if (overtakenHappened)
                {
                    i++;
                    builder.AppendLine($"{overtakingDriver.Name} " +
                                       $"has overtaken {targetDriver.Name} " +
                                       $"on lap {this.track.CurrentLap}.");
                }
                else
                {
                    if (!overtakingDriver.IsRacing)
                    {
                        this.falledDrivers.Push(overtakingDriver);
                        this.drivers.Remove(overtakingDriver);
                    }
                }
            }
        }
        if (this.IsRaceOver)
        {
            Driver winner = this.drivers.OrderBy(d => d.TotalTime).First();
            builder.AppendLine($"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.");
        }
        string result = builder.ToString().Trim();
        return result;
    }

    private bool TryOverTake(Driver overtakingDriver, Driver targetDriver)
    {
        double timeDiff = overtakingDriver.TotalTime - targetDriver.TotalTime;
 
        bool aggressiveDriver = overtakingDriver is AggressiveDriver &&
            overtakingDriver.Car.Tyre is UltrasoftTyre;

        bool enduranceDriver = overtakingDriver is EnduranceDriver && 
            overtakingDriver.Car.Tyre is HardTyre;

        bool crash = (aggressiveDriver && this.track.Weather == Weather.Foggy) ||
            (enduranceDriver && this.track.Weather == Weather.Rainy);

        if ((aggressiveDriver || enduranceDriver) && timeDiff <= 3)
        {
            if (crash)
            {
                overtakingDriver.Fail(crashReasson);
                return false;
            }
            overtakingDriver.TotalTime -= 3;
            targetDriver.TotalTime += 3;
            return true;
        }

        else if (timeDiff <= 2)
        {
            overtakingDriver.TotalTime -= 2;
            targetDriver.TotalTime += 2;
            return true;
        }
        return false;
    }

    public string GetLeaderboard()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Lap {this.track.CurrentLap}/{this.track.LapsNumber}");

        IEnumerable<Driver> leaderboardDrivers = this.drivers
            .OrderBy(d => d.TotalTime)
            .Concat(this.falledDrivers);
        int position = 1;
        foreach (Driver driver in leaderboardDrivers)
        {
            builder.AppendLine($"{position} {driver.ToString()}");
            position++;
        }
        string result = builder.ToString().TrimEnd();
        return result;
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string weatherType = commandArgs[0];
        bool validWeather = Enum.TryParse(typeof(Weather), weatherType, out object weatherObj);
        if (!validWeather)
        {
            throw new ArgumentException(ErrorMessages.InvalidWeatherType);
        }
        Weather weather = (Weather) weatherObj;
        this.track.Weather = weather;
    }

}
