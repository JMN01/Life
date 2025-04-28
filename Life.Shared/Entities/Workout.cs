using Life.Shared.Entities.Enums;

namespace Life.Shared.Entities;

public class Workout
{
    public int WorkoutId { get; set; }
    public string Name { get; set; }
    public WorkoutType WorkoutType { get; set; }
    public string? Description { get; set; }

    public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
}