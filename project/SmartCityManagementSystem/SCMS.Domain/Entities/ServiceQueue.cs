using System.Collections.Generic;
using System.Linq;

namespace SCMS.Domain.Entities
{
    public class ServiceQueue
    {
        private readonly Queue<Service> regularQueue;
        private readonly PriorityQueue<Service, int> priorityQueue;

        public ServiceQueue()
        {
            regularQueue = new Queue<Service>();
            priorityQueue = new PriorityQueue<Service, int>();
        }

        public void EnqueueRegular(Service service)
        {
            regularQueue.Enqueue(service);
        }

        public void EnqueuePriority(Service service, int priority)
        {
            priorityQueue.Enqueue(service, priority);
        }

        public Service DequeueNext()
        {
            if (priorityQueue.Count > 0)
                return priorityQueue.Dequeue();
            return regularQueue.Count > 0 ? regularQueue.Dequeue() : null;
        }
    }
}
