using SmartCheckout.Services;
using SmartCheckout.Utils;

namespace SmartCheckout
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            InventoryService inventoryService = new InventoryService();
            CheckoutService checkoutService = new CheckoutService(inventoryService);

            while (isRunning)
            {
                Console.WriteLine("\n=== SMART CHECKOUT SYSTEM ===");
                Console.WriteLine("1. Add Item to Inventory");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Add Customer to Queue");
                Console.WriteLine("4. Process Next Customer Billing");
                Console.WriteLine("5. View Queue Count");
                Console.WriteLine("0. Exit");

                int choice = InputHelper.ReadInt("Enter choice: ");

                switch (choice)
                {
                    case 1:
                        inventoryService.AddItem();
                        break;

                    case 2:
                        inventoryService.DisplayInventory();
                        break;

                    case 3:
                        checkoutService.AddCustomer();
                        break;

                    case 4:
                        checkoutService.ProcessBilling();
                        break;

                    case 5:
                        Console.WriteLine($"Customers in Queue: {checkoutService.QueueCount()}");
                        break;

                    case 0:
                        Console.WriteLine("Exiting SmartCheckout System...");
                        isRunning = false;   // ✅ STOP CONDITION
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
