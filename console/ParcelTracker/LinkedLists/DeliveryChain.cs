using ParcelTracker.Nodes;

namespace ParcelTracker.LinkedLists
{
    public class DeliveryChain
    {
        private StageNode head;

        public void AddStage(string stageName)
        {
            StageNode newNode = new StageNode(stageName);

            if (head == null)
            {
                head = newNode;
                return;
            }

            StageNode temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
        }

        public bool AddCheckpointAfter(string existingStage, string newStage)
        {
            StageNode temp = head;

            while (temp != null)
            {
                if (temp.StageName.Equals(existingStage, StringComparison.OrdinalIgnoreCase))
                {
                    StageNode newNode = new StageNode(newStage);
                    newNode.Next = temp.Next;
                    temp.Next = newNode;
                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        public void DisplayChain()
        {
            if (head == null)
            {
                Console.WriteLine("No delivery stages found.");
                return;
            }

            StageNode temp = head;
            while (temp != null)
            {
                Console.Write(temp.StageName);
                if (temp.Next != null)
                    Console.Write(" → ");
                temp = temp.Next;
            }
            Console.WriteLine();
        }

        public void MarkLost()
        {
            head = null;
        }
    }
}
