using System;

namespace SCMS.Domain.Entities
{
    public class EducationService : Service
    {
        public string CourseLevel { get; set; }

        public EducationService(string citizenId, string courseLevel) : base(citizenId)
        {
            CourseLevel = courseLevel;
        }

        public override void ProcessService()
        {
            Console.WriteLine($"Processing {CourseLevel} education service for citizen {CitizenId}");
        }

        public override decimal CalculateCost()
        {
            return CourseLevel == "Secondary" ? 1200m : 600m;
        }
    }
}
