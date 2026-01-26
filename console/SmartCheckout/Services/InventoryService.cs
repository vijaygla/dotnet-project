using SmartCheckout.Models;
using SmartCheckout.Utils;

namespace SmartCheckout.Services
{
    public class InventoryService
    {
        private Dictionary<string, Item> inventory = new();

        public void AddItem()
        {
            string name = InputHelper.ReadString("Item Name: ");
            double price = InputHelper.ReadDouble("Price: ");
            int stock = InputHelper.ReadInt("Stock Quantity: ");

            inventory[name] = new Item(name, price, stock);
            Console.WriteLine("Item added/updated successfully.");
        }

        public bool IsAvailable(string itemName)
        {
            return inventory.ContainsKey(itemName) && inventory[itemName].Stock > 0;
        }

        public double GetPrice(string itemName)
        {
            return inventory[itemName].Price;
        }

        public void ReduceStock(string itemName)
        {
            inventory[itemName].Stock--;
        }

        public void DisplayInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            Console.WriteLine("\n--- Inventory ---");
            foreach (var item in inventory.Values)
            {
                Console.WriteLine($"{item.Name} | ₹{item.Price} | Stock: {item.Stock}");
            }
        }
    }
}
