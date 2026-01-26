using SmartCheckout.Models;
using SmartCheckout.Utils;

namespace SmartCheckout.Services
{
    public class CheckoutService
    {
        private Queue<Customer> customerQueue = new();
        private InventoryService inventory;

        public CheckoutService(InventoryService inventoryService)
        {
            inventory = inventoryService;
        }

        public void AddCustomer()
        {
            string name = InputHelper.ReadString("Customer Name: ");
            Customer customer = new Customer(name);

            int itemCount = InputHelper.ReadInt("Number of items in cart: ");
            for (int i = 1; i <= itemCount; i++)
            {
                string item = InputHelper.ReadString($"Item {i}: ");
                customer.CartItems.Add(item);
            }

            customerQueue.Enqueue(customer);
            Console.WriteLine("Customer added to queue.");
        }

        public void ProcessBilling()
        {
            if (customerQueue.Count == 0)
            {
                Console.WriteLine("No customers in queue.");
                return;
            }

            Customer customer = customerQueue.Dequeue();
            double total = 0;

            Console.WriteLine($"\n--- Billing for {customer.Name} ---");

            foreach (string item in customer.CartItems)
            {
                if (inventory.IsAvailable(item))
                {
                    double price = inventory.GetPrice(item);
                    inventory.ReduceStock(item);
                    total += price;
                    Console.WriteLine($"{item} - ₹{price}");
                }
                else
                {
                    Console.WriteLine($"{item} - Out of Stock");
                }
            }

            Console.WriteLine($"Total Amount: ₹{total}");
        }

        public int QueueCount()
        {
            return customerQueue.Count;
        }
    }
}

