using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Pizza
{
    private const int MIN_LEINGHT = 1;
    private const int MAX_LEINGHT = 15;
    private const int MIN_TOPPINGS = 0;
    private const int MAX_TOPPINGS = 10;

    private string name;

    public Pizza()
    {
        this.Toppings = new List<Topping>();
    }
    public Pizza(string name)
        :this()
    {
        this.Name = name;
    }

    private double ToppingCalories
    {
        get
        {
            if (this.Toppings.Count == 0)
            {
                return 0;
            }
            return this.Toppings.Select(t => t.Calories).Sum();
        }
    }

    private double Calories => this.Dough.Calories + this.ToppingCalories;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > MAX_LEINGHT)
            {
                throw new ArgumentException($"Pizza name should be between {MIN_LEINGHT} and {MAX_LEINGHT} symbols.");
            }
            name = value;
        }
    }

    public Dough Dough { get; set; }
    private List<Topping> Toppings { get; set; }

    public void SetDough(Dough dough)
    {
        if (this.Dough != null)
        {
            throw new InvalidOperationException("Dough already set");
        }
        this.Dough = dough;
    }

    public void AddTopping(Topping topping)
    {
        this.Toppings.Add(topping);
        if (this.Toppings.Count > MAX_TOPPINGS)
        {
            throw  new ArgumentException($"Number of toppings should be in range [{MIN_TOPPINGS}..{MAX_TOPPINGS}].");
        }
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Calories:f2} Calories.";
    }
}
