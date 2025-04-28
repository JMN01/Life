using Life.Shared.Entities.Enums;

namespace Life.Shared.Entities;

public class Exercise
{
    public int ExerciseId { get; set; }
    public string Name { get; set; }
    public string TargetMuscleMain { get; set; }
    public string? TargetMuscleSecondary { get; set; }
    public bool IsRiskOfInjury { get; set; }
    public DifficultyType DifficultyType { get; set; }
    public EquipmentType EquipmentType { get; set; }
    public string? Description { get; set; }
}