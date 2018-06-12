﻿using System;
using System.Collections.Generic;
using System.Text;


public class ShowCar : Car
{
    private int stars;

    public ShowCar(string brand,
        string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
        : base(brand,model,yearOfProduction,
            horsepower,acceleration,suspension,durability)
    {
        
    }

    public override string ToString()
    {
        var sb = new StringBuilder(base.ToString());
        sb.AppendLine($"{stars} *");
        
        return sb.ToString().Trim();
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.stars += tuneIndex;
    }
}