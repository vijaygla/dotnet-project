using System;
using System.Collections.Generic;

namespace BikeRentalApp
{
    class Program
    {
        public static SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();

        static void Main(string[] args)
        {
            BikeUtility utility = new BikeUtility();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Add Bike Details");
                Console.WriteLine("2. Group Bikes By Brand");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice : ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the model : ");
                        string model = Console.ReadLine();

                        Console.Write("Enter the brand : ");
                        string brand = Console.ReadLine();

                        Console.Write("Enter the price per day : ");
                        int price = int.Parse(Console.ReadLine());

                        utility.AddBikeDetails(model, brand, price);
                        Console.WriteLine("Bike added");
                        Console.WriteLine();
                        break;

                    case 2:
                        var grouped = utility.GroupBikesByBrand();

                        foreach (var brandGroup in grouped)
                        {
                            foreach (var bike in brandGroup.Value)
                            {
                                Console.WriteLine($"{brandGroup.Key} {bike.Model}");
                            }
                            Console.WriteLine();
                        }
                        break;

                    case 3:
                        exit = true;
                        break;
                }
            }
        }
    }
}
