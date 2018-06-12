using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Monument
{
    public string Name { get;  }

    public Monument(string name)
    {
        Name = name;
    }

    public abstract double GetMonumentPower();
}
