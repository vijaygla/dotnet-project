namespace AmbulanceRoute.Models
{
    public class HospitalUnit
    {
        public string Name { get; set; }
        public bool IsAvailable { get; set; }

        public HospitalUnit(string name, bool isAvailable)
        {
            Name = name;
            IsAvailable = isAvailable;
        }
    }
}
