using System;
using System.Collections.Generic;
using System.Text;


public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    protected Car(string brand, string model, int yearOfProduction, 
        int horsepower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public string Brand { get; set; }
    public string Model { get; set; }
    public int YearOfProduction { get; set; }
    public int Horsepower { get; set; }
    public int Acceleration { get; set; }
    public int Suspension { get; set; }
    public int Durability { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{brand} {model} {yearOfProduction}");
        sb.AppendLine($"{horsepower} HP, 100 m/h in {acceleration} s");
        sb.AppendLine($"{suspension} Suspension force, {durability} Durability");

        return sb.ToString();
    }

    public virtual void Tune(int tuneIndex, string addOn)
    {
        this.Horsepower += tuneIndex;
        this.Suspension += tuneIndex / 2;
    }
}