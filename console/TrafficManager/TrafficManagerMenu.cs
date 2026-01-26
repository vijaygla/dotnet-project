using System;

namespace TrafficManager
{
    internal class TrafficManagerMenu
    {
        public void StartMenu()
        {
            bool isRunning = true;
            WaitingQueue carQueue = new WaitingQueue();

            while (isRunning)
            {
                Console.WriteLine("\n--- Traffic Manager Menu ---");
                Console.WriteLine("1. Add Car");
                Console.WriteLine("2. Remove Car");
                Console.WriteLine("3. Display Cars");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter car number: ");
                        int carNumber;
                        if (int.TryParse(Console.ReadLine(), out carNumber))
                        {
                            carQueue.AddCar(carNumber);
                        }
                        else
                        {
                            Console.WriteLine("Invalid car number");
                        }
                        break;

                    case 2:
                        carQueue.RemoveCar();
                        break;

                    case 3:
                        carQueue.DisplayCar();
                        break;

                    case 4:
                        Console.WriteLine("Exit successfully");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
