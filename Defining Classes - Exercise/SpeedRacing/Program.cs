using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string model = input[0];
            double fuel = double.Parse(input[1]);   
            double fuelPerKm = double.Parse(input[2]);
            Car car = new Car(model, fuel, fuelPerKm);
            cars.Add(car);
        }
        string driveCommand = Console.ReadLine();
        while (driveCommand != "End")
        {
            string[] driveCommandArgs = driveCommand.Split();
            string carModel = driveCommandArgs[1];
            int amountOfKilometers = int.Parse(driveCommandArgs[2]);
            Car carToDrive = cars.First(c => c.model == carModel);
            carToDrive.Drive(amountOfKilometers);

            driveCommand = Console.ReadLine();
        }
        foreach (var car in cars)
        {
            Console.WriteLine("{0} {1:f2} {2}", car.model, car.fuel, car.distanceTraveled);
        }
    }
}

