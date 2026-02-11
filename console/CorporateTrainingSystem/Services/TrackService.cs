using CorporateTrainingSystem.Models;

namespace CorporateTrainingSystem.Services;

public class TrackService
{
    private readonly List<TrainingTrack> tracks = new()
    {
        new TrainingTrack { Name = "Backend", PassingScore = 50 },
        new TrainingTrack { Name = "Frontend", PassingScore = 60 },
        new TrainingTrack { Name = "Database", PassingScore = 55 },
        new TrainingTrack { Name = "Cloud", PassingScore = 65 }
    };

    public List<TrainingTrack> GetAll() => tracks;

    public TrainingTrack GetByName(string name)
    {
        return tracks.First(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
