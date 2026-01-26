using ParcelTracker.Interfaces;
using ParcelTracker.LinkedLists;

namespace ParcelTracker.Services
{
    public class ParcelTrackerService : IParcelTracker
    {
        private readonly DeliveryChain deliveryChain;

        public ParcelTrackerService()
        {
            deliveryChain = new DeliveryChain();
        }

        public void AddStage(string stageName)
        {
            deliveryChain.AddStage(stageName);
        }

        public void AddCheckpointAfter(string existingStage, string newStage)
        {
            bool result = deliveryChain.AddCheckpointAfter(existingStage, newStage);

            if (!result)
                Console.WriteLine("Stage not found. Cannot add checkpoint.");
        }

        public void TrackParcel()
        {
            deliveryChain.DisplayChain();
        }

        public void MarkParcelLost()
        {
            deliveryChain.MarkLost();
            Console.WriteLine("Parcel marked as lost. Tracking chain cleared.");
        }
    }
}
