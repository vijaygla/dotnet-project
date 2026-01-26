namespace SmartCheckout.Models
{
    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public Item(string name, double price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
    }
}
