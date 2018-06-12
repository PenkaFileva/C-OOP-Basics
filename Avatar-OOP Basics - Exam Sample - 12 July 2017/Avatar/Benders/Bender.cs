using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Bender
{
    public string Name { get; }
    public int Power { get;  }

    public Bender(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public abstract double GetPower();

}
