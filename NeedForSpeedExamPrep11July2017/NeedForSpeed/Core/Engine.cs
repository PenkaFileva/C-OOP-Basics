using System;
using System.Collections.Generic;
using System.Text;


public class Engine
{
    private CarManager manager;

    public Engine()
    {
        this.manager = new CarManager();
    }

    public void Run()
    {
        string command;
        while ((command = Console.ReadLine()) != "Cops Are Here")
        {
            var cmdArg = command.Split(' ');
            ExecuteCommand(cmdArg);
        }
    }

    public void ExecuteCommand(string[] cmdArgs)
    {
        var argument = cmdArgs[0];
        //int id = int.Parse(cmdArgs[1]);
        int raceId;
        switch (argument)
        {
            case "register":
                int id = int.Parse(cmdArgs[1]);
                string type = cmdArgs[2];
                string brand = cmdArgs[3];
                string model = cmdArgs[4];
                int yearOfProduction = int.Parse(cmdArgs[5]);
                int horsepower = int.Parse(cmdArgs[6]);
                int acceleration = int.Parse(cmdArgs[7]);
                int suspension = int.Parse(cmdArgs[8]);
                int durability = int.Parse(cmdArgs[9]);
                manager.Register(id, type, brand, model, yearOfProduction,
                    horsepower, acceleration, suspension, durability);
                break;
            case "check":
                int id1 = int.Parse(cmdArgs[1]);
                Console.WriteLine(manager.Check(id1));

                break;
            case "open":
                int id2 = int.Parse(cmdArgs[1]);
                string type2 = cmdArgs[2];
                int length = int.Parse(cmdArgs[3]);
                string route = cmdArgs[4];
                int prizePool = int.Parse(cmdArgs[5]);
                manager.Open(id2, type2, length, route, prizePool);
                break;
            case "participate":
                int carId = int.Parse(cmdArgs[1]);
                raceId = int.Parse(cmdArgs[2]);
                manager.Participate(carId, raceId);
                break;
            case "start":
                raceId = int.Parse(cmdArgs[1]);
                Console.WriteLine(manager.Start(raceId));
                break;
            case "park":
                int id4 = int.Parse(cmdArgs[1]);
                manager.Park(id4);
                break;
            case "unpark":
                int id5 = int.Parse(cmdArgs[1]);
                manager.Unpark(id5);
                break;
            case "tune":
                int tuneIndex = int.Parse(cmdArgs[1]);
                string addOn = cmdArgs[2];
                manager.Tune(tuneIndex, addOn);
                break;

        }
    }
}
