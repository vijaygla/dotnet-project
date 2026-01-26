
namespace AdharSortingSystem
{
    // emplement the radix sort
    public class RadixSort : IRadixSort
    {
        // method to sort the array element
        public void Sort(long[] arr)
        {
            long max = GetMax(arr);

            for (long exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSort(arr, exp);
            }
        }

        // method to get the max
        private long GetMax(long[] arr)
        {
            long max = arr[0];
            foreach (long num in arr)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            return max;
        }

        // stable counting sort
        private void CountingSort(long[] arr, long exp)
        {
            int n = arr.Length;
            long[] output = new long[n];
            int[] count = new int[10];

            for(int i=0; i<n; i++)
            {
                count[(arr[i] / exp) % 10]++;
            }

            for(int i=1; i<10; i++)
            {
                count[i] += count[i - 1];
            }

            for(int i=n - 1; i >= 0; i--)
            {
                int index = (int)((arr[i] / exp) % 10);
                output[count[index] - 1] = arr[i];
                count[index]--;
            }

            for(int i=0; i<n; i++)
            {
                arr[i] = output[i];
            }
        }
    }
}
