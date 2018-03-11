using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;
    private decimal money;
    private IList<Product> Products { get; set; }

    public Person()
    {
        this.Products = new List<Product>();
    }

    public Person(string name, decimal money) : this()
    {
        this.Name = name;
        this.Money = money;
    }
    public decimal Money
    {
        get { return money; }
        set
        {
            Validator.ValidateMoney(value);
            money = value;
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            Validator.ValidateName(value);
            name = value;
        }
    }

    public string TryBuyProduct(Product procuct)
    {
        if (this.Money < procuct.Cost)
        {
            return $"{this.Name} can't afford {procuct.Name}";
        }
        this.Money -= procuct.Cost;
        this.Products.Add(procuct);
        return $"{this.Name} bought {procuct.Name}";
    }

    public override string ToString()
    {
        string procuctOutput = this.Products.Count > 0 ? 
            string.Join(", ", this.Products) : "Nothing bought";
        string result = $"{this.Name} - {procuctOutput}";
        return result;
    }
}
