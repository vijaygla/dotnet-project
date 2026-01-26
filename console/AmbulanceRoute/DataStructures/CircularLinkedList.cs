using AmbulanceRoute.Models;

namespace AmbulanceRoute.DataStructures
{
    public class CircularLinkedList
    {
        private class Node
        {
            public HospitalUnit Data;
            public Node Next;

            public Node(HospitalUnit data)
            {
                Data = data;
            }
        }

        private Node head = null;

        public void AddUnit(HospitalUnit unit)
        {
            Node newNode = new Node(unit);

            if (head == null)
            {
                head = newNode;
                newNode.Next = head;
                return;
            }

            Node temp = head;
            while (temp.Next != head)
                temp = temp.Next;

            temp.Next = newNode;
            newNode.Next = head;
        }

        public void DisplayUnits()
        {
            if (head == null)
            {
                Console.WriteLine("No hospital units available.");
                return;
            }

            Console.WriteLine("\n--- Hospital Units (Circular) ---");
            Node temp = head;
            do
            {
                Console.WriteLine($"{temp.Data.Name} | Available: {temp.Data.IsAvailable}");
                temp = temp.Next;
            } while (temp != head);
        }

        public void FindNearestAvailableUnit()
        {
            if (head == null)
            {
                Console.WriteLine("No units in route.");
                return;
            }

            Node temp = head;
            do
            {
                if (temp.Data.IsAvailable)
                {
                    Console.WriteLine($"🚑 Ambulance redirected to: {temp.Data.Name}");
                    return;
                }
                temp = temp.Next;
            } while (temp != head);

            Console.WriteLine("❌ No units available at the moment.");
        }

        public void MarkUnavailable(string unitName)
        {
            if (head == null) return;

            Node temp = head;
            do
            {
                if (temp.Data.Name.Equals(unitName, StringComparison.OrdinalIgnoreCase))
                {
                    temp.Data.IsAvailable = false;
                    Console.WriteLine($"{unitName} marked under maintenance.");
                    return;
                }
                temp = temp.Next;
            } while (temp != head);

            Console.WriteLine("Unit not found.");
        }

        public void MarkAvailable(string unitName)
        {
            if (head == null) return;

            Node temp = head;
            do
            {
                if (temp.Data.Name.Equals(unitName, StringComparison.OrdinalIgnoreCase))
                {
                    temp.Data.IsAvailable = true;
                    Console.WriteLine($"{unitName} restored and available.");
                    return;
                }
                temp = temp.Next;
            } while (temp != head);

            Console.WriteLine("Unit not found.");
        }
    }
}
