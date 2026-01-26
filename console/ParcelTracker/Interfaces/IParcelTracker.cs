namespace ParcelTracker.Interfaces
{
    public interface IParcelTracker
    {
        void AddStage(string stageName);
        void AddCheckpointAfter(string existingStage, string newStage);
        void TrackParcel();
        void MarkParcelLost();
    }
}

