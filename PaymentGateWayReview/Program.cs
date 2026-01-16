namespace PaymentGateWayReview
{
    class Program
    {
        static void Main(String[] args)
        {
            Console.Write("Enter no of customer: ");
            int n = int.Parse(Console.ReadLine());
            string[] users = new string[n];

            Console.Write("Enter you member tag(vip/normal): ");
            string tag = Console.ReadLine();
            users[0] = tag;

            Console.Write("Enter total price for the payement: ");
            int price = int.Parse(Console.ReadLine());

            Console.Write("=== select the payment method===\n 1. CashOndelevry \t 2. PaymentByUpi \t 3. PaymentByCard\n");
            Console.Write("Enter choice : ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CashOnDelevery(price, users);
            }
            else if (choice == "2")
            {
                PaymentByUpi(price, users);
            }
            else if (choice == "3")
            {
                PaymentByCard(price, users);
            }
            else
            {
                Console.WriteLine("you have to entered the correct choice");
                return;
            }
        }

        static string CashOnDelevery(int price, string[] users)
        {
            if (users[0] == "vip")
            {
                price = price + (int)(price * 0.02);
            }

            Console.WriteLine("You have to pay " + price);
            return "CashOnDelivery Done";
        }

        static string PaymentByUpi(int price, string[] users)
        {
            if (users[0] == "vip")
            {
                price = price - (int)(price * 0.2);
            }

            Console.WriteLine("You have to pay " + price);
            return "UPI Payment Done";
        }

        static string PaymentByCard(int price, string[] users)
        {
            if (users[0] == "vip")
            {
                price = price - (int)(price * 0.2);
            }

            Console.WriteLine("You have to pay " + price);
            return "Card Payment Done";
        }
    }
}
