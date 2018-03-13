using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private double length;

    public double Length
    {
        get { return length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
            }
            length = value;
        }
    }
    private double width;

    public double Width
    {
        get { return width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
            }
            width = value;
        }
    }
    private double height;

    public double Height
    {
        get { return height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
            }
            height = value;
        }
    }


    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double GetSurfaceArea()
    {
        return 2 * this.Length * this.Height + 
            2 * this.Length * this.Width + 2 * this.Height * this.Width;
    }

    public double GetLateralSurfaceArea()
    {
        return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
    }

    public double GetVolume()
    {
        return this.Length * this.Height * this.Width;
    }
}
