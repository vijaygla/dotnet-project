using System.Collections.Generic;

public class QueueManager
{
    private readonly Queue<string> serviceQueue;
    private readonly Queue<string> priorityQueue;

    public QueueManager()
    {
        serviceQueue = new Queue<string>();
        priorityQueue = new Queue<string>();
    }

    public void EnqueueService(string serviceId, bool isPriority = false)
    {
        if (isPriority)
            priorityQueue.Enqueue(serviceId);
        else
            serviceQueue.Enqueue(serviceId);
    }

    public string DequeueNextService()
    {
        if (priorityQueue.Count > 0)
            return priorityQueue.Dequeue();

        if (serviceQueue.Count > 0)
            return serviceQueue.Dequeue();

        return null;
    }

    public int GetQueueLength()
    {
        return serviceQueue.Count + priorityQueue.Count;
    }
}
