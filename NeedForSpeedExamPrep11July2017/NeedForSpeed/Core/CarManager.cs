using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    private List<int> racesClosed;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
        this.racesClosed=new List<int>();
    }

    public void Register(int id, string type, string brand, 
        string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        if (type == "Performance")
        {
            this.cars.Add(id, new PerformanceCar(brand, model, 
                yearOfProduction, horsepower, 
                acceleration, suspension, durability));
        }
        else 
        {
            var car = new ShowCar(brand, model,
                yearOfProduction, horsepower,
                acceleration, suspension, durability);
            this.cars.Add(id, car);
        }
        
    }

    public string Check(int id)
    {
        var result = cars[id].ToString();
        return result;
    }

    public void Open(int id, string type, int length, string route,
        int prizePool)
    {
        if (type == "Casual")
        {
            var race = new CasualRace(length, route, prizePool);
            this.races.Add(id, race);
        }
        else if (type == "Drag")
        {
            var race = new DragRace(length, route, prizePool);
            this.races.Add(id, race);
        }
        else if (type == "Drift")
        {
            var race = new DriftRace(length, route, prizePool);
            this.races.Add(id, race);
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (!garage.ParkedCars.Contains(carId))
        {
            if (!racesClosed.Contains(raceId))
            {
                this.races[raceId].Participants.Add(carId, cars[carId]);
            }
        }        
    }

    public string Start(int id)
    {
        if (races[id].Participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }
        var result = races[id].StartRace();
        racesClosed.Add(id);
        //races.Remove(id);
        return result;
    }

    public void Park(int id)
    {
        foreach (var race in races
            .Where(r => !racesClosed.Contains(r.Key)))
        {
            if (race.Value.Participants.ContainsKey(id))
            {
                return;
            }
        }
        this.garage.AddCar(id);
    }

    public void Unpark(int id)
    {
        this.garage.RemoveCar(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var id in garage.ParkedCars)
        {
            cars[id].Tune(tuneIndex, addOn);
        }
    }

}
