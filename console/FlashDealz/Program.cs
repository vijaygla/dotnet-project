using System;

class Program
{
    static void Main(string[] agrs)
    {
        Products products = new Products();
        Product[] sortedProducts = products.sortByDiscount();

        Console.WriteLine("Products sorted by discount:");
        foreach (var product in sortedProducts)
        {
            Console.WriteLine(product);
        }
    }
}