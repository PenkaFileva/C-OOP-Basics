using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WaterMonument : Monument
{
    public int WaterAffinity  { get; private set; }

    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public override double GetMonumentPower()
    {
        return this.WaterAffinity;
    }
}
