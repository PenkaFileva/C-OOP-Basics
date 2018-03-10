using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public string model;
    public double fuel;
    public double fuelPerKm;
    public double distanceTraveled;

    public Car(string model, double fuel, double fuelPerKm)
    {
        this.model = model;
        this.fuel = fuel;
        this.fuelPerKm = fuelPerKm;
        this.distanceTraveled = 0;
    }

    public void Drive(int amountOfKilometers)
    {
        if (amountOfKilometers <= this.fuel/this.fuelPerKm)
        {
            this.distanceTraveled += amountOfKilometers;
            this.fuel -= amountOfKilometers * fuelPerKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}

