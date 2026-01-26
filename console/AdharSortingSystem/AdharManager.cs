
namespace AdharSortingSystem
{
    class AdharManager
    {
        private long[] adharNumber;
        private IRadixSort sort;

        public AdharManager(long[] number)
        {
            adharNumber = number;
            sort = new RadixSort();
        }

        public void SortAdharNumber()
        {
            sort.Sort(adharNumber);
            Console.WriteLine("Adhar number sorted successfully");
        }

        public void Display()
        {
            foreach(long num in adharNumber)
            {
                Console.WriteLine(num);
            }
        }

        public void Search(long number)
        {
            int result = SearchUtility.BinarySearch(adharNumber, number);
            if(result != -1)
            {
                Console.WriteLine($"Adhar found at index {result}");
            }
            else
            {
                Console.WriteLine("Adhar number not found");
            }
        }
    }
}
