using System;

namespace SCMS.Domain.Entities
{
    public class HealthcareService : Service
    {
        public string ServiceType { get; set; }

        public HealthcareService(string citizenId, string serviceType) : base(citizenId)
        {
            ServiceType = serviceType;
        }

        public override void ProcessService()
        {
            Console.WriteLine($"Processing {ServiceType} healthcare service for citizen {CitizenId}");
        }

        public override decimal CalculateCost()
        {
            return ServiceType == "Premium" ? 1500m : 800m;
        }
    }
}
