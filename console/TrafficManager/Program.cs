using System;

namespace TrafficManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Welcome to Traffic Manager ===");
            TrafficManagerMenu menu = new TrafficManagerMenu();
            menu.StartMenu();
        }
    }
}
