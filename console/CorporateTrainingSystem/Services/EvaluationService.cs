using CorporateTrainingSystem.Models;

namespace CorporateTrainingSystem.Services;

public class EvaluationService
{
    public void RunEvaluations(List<Employee> employees)
    {
        Random rand = new();

        Parallel.ForEach(employees, emp =>
        {
            try
            {
                emp.Status = ProgressStatus.InProgress;

                emp.Activities.Add(new ActivityLog
                {
                    TimeStamp = DateTime.Now,
                    Message = "Evaluation started",
                    Severity = SeverityLevel.Medium
                });

                Thread.Sleep(1000);

                int score = rand.Next(0, 100);

                if (score >= emp.Track.PassingScore)
                    emp.Status = ProgressStatus.Passed;
                else
                    emp.Status = ProgressStatus.Failed;

                emp.Activities.Add(new ActivityLog
                {
                    TimeStamp = DateTime.Now,
                    Message = $"Score: {score}",
                    Severity = SeverityLevel.Low
                });
            }
            catch
            {
                emp.Status = ProgressStatus.Failed;
            }
        });
    }
}
