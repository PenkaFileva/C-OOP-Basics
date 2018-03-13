using System;


public class Program
{
    static void Main(string[] args)
    {
        try
        {
            var boxParams = new double[3];
            for (int i = 0; i < boxParams.Length; i++)
            {
                boxParams[i] = double.Parse(Console.ReadLine());
            }

            Box box = new Box(boxParams[0], boxParams[1], boxParams[2]);
            var surfaceArea = box.GetSurfaceArea();
            var lateralSurfaceArea = box.GetLateralSurfaceArea();
            var volume = box.GetVolume();
            Console.WriteLine($"Surface Area - {surfaceArea:f2}");
            Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
            Console.WriteLine($"Volume - {volume:f2}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
       
    }
}
