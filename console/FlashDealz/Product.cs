using System;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public double Discount { get; set; }

    public Product(int id, string name, double price, double discount)
    {
        Id = id;
        Name = name;
        Price = price;
        Discount = discount;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Price: {Price}";
    }
}