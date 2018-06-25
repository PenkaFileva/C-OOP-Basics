using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    static void Main(string[] args)
    {
        int[] counts = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<Rectangle> rectangles = new List<Rectangle>();
        for (int i = 0; i < counts[0]; i++)
        {
            var line = Console.ReadLine().Split();
            Rectangle rectangle = new Rectangle(line[0], double.Parse(line[1]), double.Parse(line[2]), double.Parse(line[3]), double.Parse(line[4]));
            rectangles.Add(rectangle);
        }
        for (int i = 0; i < counts[1]; i++)
        {
            var tokens = Console.ReadLine().Split();
            Rectangle rectangle1 = rectangles.First(r => r.ID == tokens[0]);
            Rectangle rectangle2 = rectangles.First(r => r.ID == tokens[1]);

            if (rectangle1.Intersects(rectangle2))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}

