namespace ParcelTracker.Nodes
{
    public class StageNode
    {
        public string StageName { get; set; }
        public StageNode Next { get; set; }

        public StageNode(string stageName)
        {
            StageName = stageName;
            Next = null;
        }
    }
}
