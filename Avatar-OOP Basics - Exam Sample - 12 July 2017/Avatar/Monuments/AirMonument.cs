using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AirMonument : Monument
{
    public int AirAffinity  { get;  set; }

    public AirMonument(string name, int airAffinity) : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public override double GetMonumentPower()
    {
        return this.AirAffinity;
    }
}

