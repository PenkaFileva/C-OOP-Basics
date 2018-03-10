using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    public string model;
    public Engine engine;
    public Cargo cargo;
    public Tire[] tires;

    public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }
}


