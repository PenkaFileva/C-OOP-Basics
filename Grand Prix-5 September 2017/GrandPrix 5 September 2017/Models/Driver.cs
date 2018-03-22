using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;


public abstract class Driver
{
    private const double boxDefaultTime = 20;

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.TotalTime = 0.0;
        this.IsRacing = true;
    }
    public string Name { get; }
    public double TotalTime { get; set; }
    public Car Car { get; set; }
    public double FuelConsumptionPerKm { get; }
    public virtual double Speed => 
        (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public bool IsRacing { get; private set; }
    public string FailureReason { get; private set; }

    private string Status => IsRacing ? this.TotalTime.ToString("f3") 
        : this.FailureReason;

    private void Box()
    {
        this.TotalTime += boxDefaultTime;
    }
   
    internal void Refuel(string[] methodArgs)
    {
        this.Box();
        double fuelAmount = double.Parse(methodArgs[0]);
        this.Car.Refuel(fuelAmount);
    }

    internal void ChangeTyres(Tyre tyre)
    {
        this.Box();
        this.Car.ChangeTyres(tyre);
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Status}";
    }

    public void ConpleteLap(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);
        this.Car.CompleteLap(trackLength, this.FuelConsumptionPerKm);
    }

    public void Fail(string eMessage)
    {
        this.IsRacing = false;
        this.FailureReason = eMessage;
    }
}
