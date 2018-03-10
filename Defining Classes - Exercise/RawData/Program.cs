using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();
        for (int i = 0; i < n; i++)
        {
            string[] carDetail = Console.ReadLine().Split();
            string carModel = carDetail[0];
            int engineSpeed = int.Parse(carDetail[1]);
            int enginePower = int.Parse(carDetail[2]);
            double cargoWeight = double.Parse(carDetail[3]);
            string cargoTipe = carDetail[4];
            double tire1Pressure = double.Parse(carDetail[5]);
            int tire1Age = int.Parse(carDetail[6]);
            double tire2Pressure = double.Parse(carDetail[7]);
            int tire2Age = int.Parse(carDetail[8]);
            double tire3Pressure = double.Parse(carDetail[9]);
            int tire3Age = int.Parse(carDetail[10]);
            double tire4Pressure = double.Parse(carDetail[11]);
            int tire4Age = int.Parse(carDetail[12]);

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoTipe);
            Tire[] tires = new Tire[4];
            tires[0] = new Tire(tire1Pressure, tire1Age);
            tires[1] = new Tire(tire2Pressure, tire2Age);
            tires[2] = new Tire(tire3Pressure, tire3Age);
            tires[3] = new Tire(tire4Pressure, tire4Age);

            Car car = new Car(carModel, engine, cargo, tires);
            cars.Add(car);
        }
        string cargoTypeForPrint = Console.ReadLine();
        List<Car> sortedCars = new List<Car>();
        if (cargoTypeForPrint == "fragile")
        {
            sortedCars = cars.Where(x => x.cargo.type == "fragile"
                                         && x.tires.Any(t => t.pressure < 1)).ToList();
        }
        else
        {
            sortedCars = cars.Where(x => x.cargo.type == "flamable" && x.engine.power > 250).ToList();
        }
        foreach (var car in sortedCars)
        {
            Console.WriteLine(car.model);
        }
    }
}

