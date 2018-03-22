using System;
using System.Collections.Generic;
using System.Text;


public class SonicHarvester : Harvester
{
    public override string Type => "Sonic";

    private int sonicFactor;

    public int SonicFactor
    {
        get { return sonicFactor; }
        private set { sonicFactor = value; }
    }

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) 
        : base(id, oreOutput, energyRequirement)
    {
        this.EnergyRequirement = energyRequirement / sonicFactor;
    }
}
