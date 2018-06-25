using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    static void Main(string[] args)
    {
        var engines = new List<Engine>();
        var cars = new List<Car>();

        int numOfEngine = int.Parse(Console.ReadLine());
        for (int i = 0; i < numOfEngine; i++)
        {
            string[] input = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            Engine engine = null;
            int displacement = 0;
            if (input.Length == 2)
            {
                engine = new Engine(input[0], int.Parse(input[1]));
            }
            else if (input.Length == 4)
            {
                engine = new Engine(input[0], int.Parse(input[1]), int.Parse(input[2]), input[3]);
            }
            else if (input.Length == 3 && int.TryParse(input[2], out displacement))
            {
                engine = new Engine(input[0], int.Parse(input[1]), displacement);
            }
            else
            {
                engine = new Engine(input[0], int.Parse(input[1]), input[2]);
            }
            engines.Add(engine);
        }

        int numOfCar = int.Parse(Console.ReadLine());
        for (int i = 0; i < numOfCar; i++)
        {
            string[] carInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Car car = null;
            Engine engine = engines.First(e => e.model == carInfo[1]);
            int weight = 0;
            if (carInfo.Length == 2)
            {
                car = new Car(carInfo[0], engine);
            }
            else if (carInfo.Length == 4)
            {
                car = new Car(carInfo[0], engine, int.Parse(carInfo[2]), carInfo[3]);
            }
            else if (carInfo.Length == 3 && int.TryParse(carInfo[2], out weight))
            {
                car = new Car(carInfo[0], engine, weight);
            }
            else
            {
                car = new Car(carInfo[0], engine, carInfo[2]);
            }

            cars.Add(car);
        }

        foreach (var car in cars)
        {
            Console.WriteLine("{0}:", car.model);
            Console.WriteLine(" {0}:", car.engine.model);
            Console.WriteLine("  Power: {0}", car.engine.power);
            Console.WriteLine("  Displacement: {0}", car.engine.displacement == -1 ? @"n/a" : car.engine.displacement.ToString());
            Console.WriteLine("  Efficiency: {0}", car.engine.efficiency);
            Console.WriteLine(" Weight: {0}", car.weight  == -1 ? @"n/a" : car.weight.ToString());
            Console.WriteLine(" Color: {0}", car.color);
        }
    }
}

