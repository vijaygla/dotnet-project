using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace BrowserBuddy
{
    public class ClosedTabStack
    {
        private const int MaxClosedTab = 10;
        private string[] closedTab;
        private int topIndex;

        public ClosedTabStack()
        {
            closedTab = new string[MaxClosedTab];
            topIndex = -1;
        }

        public void Push(string url)
        {
            if(topIndex < MaxClosedTab - 1)
            {
                topIndex = topIndex + 1;
                closedTab[topIndex] = url;
            }
            else
            {
                Console.WriteLine("Closed tab memory is full");
            }
        }

        // 
        public string Pop()
        {
            if (topIndex >= 0)
            {
                string url = closedTab[topIndex];
                topIndex = topIndex - 1;
                return url;
            }

            return null;
        }

        // 
        public bool IsEmpty()
        {
            return topIndex < 0;
        }
    }
}
