namespace MyApp
{
    internal class Program
    {
        static void Main(String[] args)
        {
            Console.WriteLine("Hello Vijay");
            Console.Write("Enter num1 : ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter num2 : ");
            int num2 = int.Parse(Console.ReadLine());

            // add two number
            int ans = AddTwoNumber(num1, num2);
            Console.WriteLine("Sum of two number : " + ans);

            // check positive negative number
            Console.Write("Enter any number to check wheather it is positve or negative : ");
            int num = int.Parse(Console.ReadLine());
            string result = CheckedNumber(num);
            Console.WriteLine(num + " is " + result + " number");

            // check even odd number 
            Console.Write("Enter any number to check wheather it is even or odd : ");
            int number = int.Parse(Console.ReadLine());
            string result2 = CheckOddEven(number);
            Console.WriteLine(number + " is " + result2);

            // check prine number
            string checkPrime = CheckPrimeNumber(number);
            Console.WriteLine(number + " is " + checkPrime);
        }

        // method to add two number
        public static int AddTwoNumber(int num1, int num2)
        {
            return num1 + num2;
        }

        // method to check wheather the number is positive or negative
        public static string CheckedNumber(int num)
        {
            if(num > 0)
            {
                return "positive";
            }
            else
            {
                return "negative";
            }
        }

        // method to check wheather odd even number
        public static string CheckOddEven(int number)
        {
            if(number % 2 == 0)
            {
                return "Even number";
            }
            else
            {
                return "Odd number";
            }
        }

        // method to check prime number
        public static string CheckPrimeNumber(int number2)
        {
            int count = 0;

            for(int i=2; i<number2; i++)
            {
                if(number2 % i == 0)
                {
                    count++;
                }
            }

            if(count > 0) 
                return "not prime number";
            else 
                return "prime number";
        }
    }
}
