using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Engine
{
    private NationsBuilder nationsBuilder;
    private bool isRunning;
    private string input;

    public Engine()
    {
        isRunning = true;
        this.nationsBuilder = new NationsBuilder();
    }

    public void Run()
    {        
        while (isRunning)
        {
            var cmdArgs = input.Split(' ').ToList();
            var argument = cmdArgs[0];
            cmdArgs.RemoveAt(0);

            switch (argument)
            {
                case "Bender":
                    nationsBuilder.AssignBender(cmdArgs);
                    break;
                case "Monument":
                    nationsBuilder.AssignMonument(cmdArgs);
                    break;
                case "Status":

                    break;
                case "War":
                    break;
                case "Quit":
                    isRunning = false;
                    break;

            }
        }
    }   
}
