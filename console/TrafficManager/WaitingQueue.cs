namespace TrafficManager
{
    internal class WaitingQueue
    {
        // Linked List Node
        private class ListNode
        {
            public int CarNumber;
            public ListNode Next;

            public ListNode(int carNumber)
            {
                CarNumber = carNumber;
                Next = null;
            }
        }

        private ListNode front;
        private ListNode rear;

        // Constructor
        public WaitingQueue()
        {
            front = null;
            rear = null;
        }

        // Add car (Enqueue)
        public void AddCar(int carNumber)
        {
            ListNode newNode = new ListNode(carNumber);

            if (rear == null) // queue empty
            {
                front = rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }

            Console.WriteLine("Car " + carNumber + " added to waiting queue");
        }

        // Remove car (Dequeue)
        public void RemoveCar()
        {
            if (front == null)
            {
                Console.WriteLine("Waiting Queue is empty");
                return;
            }

            int removedCar = front.CarNumber;
            front = front.Next;

            if (front == null) // queue became empty
            {
                rear = null;
            }

            Console.WriteLine("Car " + removedCar + " removed from waiting queue");
        }

        // Display cars
        public void DisplayCar()
        {
            if (front == null)
            {
                Console.WriteLine("Waiting Queue is empty");
                return;
            }

            Console.Write("Cars in Waiting Queue: ");
            ListNode temp = front;

            while (temp != null)
            {
                Console.Write(temp.CarNumber + " ");
                temp = temp.Next;
            }

            Console.WriteLine();
        }
    }
}
