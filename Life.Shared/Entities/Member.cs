using Life.Shared.Entities.Enums;

namespace Life.Shared.Entities;

public class Member
{
    public int MemberId { get; set; }
    public string Name { get; set; }
    public RoleType RoleType { get; set; }
    public string? LicenseNumber { get; set; }
    public bool IsActive { get; set; }
    
    public int? PersonalId { get; set; }
    public Personal? Personal { get; set; }

    public int? MealId { get; set; }
    public Meal? Meal { get; set; }

    public int? WorkoutId { get; set; }
    public Workout? Workout { get; set; }

    public int? TeamId { get; set; }
    public Team? Team { get; set; }
}