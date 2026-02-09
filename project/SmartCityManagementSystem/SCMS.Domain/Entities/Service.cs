using System;
using SCMS.Domain.Interfaces;

namespace SCMS.Domain.Entities
{
    public abstract class Service : IBookable
    {
        public string Id { get; set; }
        public string CitizenId { get; set; }
        public DateTime BookingDate { get; set; }
        public bool IsActive { get; set; }

        protected Service(string citizenId)
        {
            Id = Guid.NewGuid().ToString()[..8];
            CitizenId = citizenId;
            BookingDate = DateTime.Now;
            IsActive = true;
        }

        public abstract void ProcessService();
        public abstract decimal CalculateCost();

        public virtual void Cancel()
        {
            IsActive = false;
        }

        public bool CanBook()
        {
            return IsActive && DateTime.Now <= BookingDate.AddDays(30);
        }
    }
}
