using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Nation
{
    public List<Bender> benders { get; }
    public List<Monument> monuments { get; }

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public void AddBender(Bender bender) => this.benders.Add(bender);
    public void AddMonument(Monument monument) => this.monuments.Add(monument);
}