using System.Text.Json.Serialization;

namespace Life.Shared.Entities;

public class WorkoutExercise
{
    public int WorkoutId { get; set; }
    [JsonIgnore]
    public Workout Workout { get; set; }

    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }

    public int Set { get; set; }
    public int Repetition { get; set; }
}