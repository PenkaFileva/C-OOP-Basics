using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class FireMonument : Monument
{
    public int FireAffinity  { get; private set; }

    public FireMonument(string name, int fireAffinity) : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public override double GetMonumentPower()
    {
        return this.FireAffinity;
    }
}
