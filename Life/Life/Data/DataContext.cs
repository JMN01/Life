using Life.Shared.Entities;
using Life.Shared.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Life.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
   
    
    public DbSet<Member> Members { get; set; }
    public DbSet<Personal> Personals { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<FoodNutrient> FoodNutrients { get; set; }
    public DbSet<Nutrient> Nutrients { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    ////public DbSet<MealLog> MealLogs { get; set; }
    ////public DbSet<WorkoutLog> WorkoutLogs { get; set; }
    ////public DbSet<ProgressMeasurement> ProgressMeasurements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WorkoutExercise>().HasKey(x => new { x.WorkoutId, x.ExerciseId });
        modelBuilder.Entity<FoodNutrient>().HasKey(y => new { y.FoodId, y.NutrientId });
        
        modelBuilder.Entity<Member>()
            .HasOne(m => m.Personal)
            .WithOne(p => p.Member) 
            .HasForeignKey<Member>(m => m.PersonalId);

        modelBuilder.Entity<Member>().HasData(
            new Member
            {
                MemberId = 1, Name = "No Way", RoleType = RoleType.Athlete, LicenseNumber = "DE001", IsActive = false,
                PersonalId = 1, MealId = 1, WorkoutId = 1, TeamId = 1
            },
            new Member
            {
                MemberId = 2, Name = "This Way", RoleType = RoleType.Athlete, LicenseNumber = "DE002", IsActive = false,
                PersonalId = 2, MealId = 2, WorkoutId = 2, TeamId = 2
            }
        );
        modelBuilder.Entity<Personal>().HasData(
            new Personal
            {
                PersonalId = 1, FirstName = "No", LastName = "Way", BirthDate = new DateTime(2001, 12, 10),
                Email = "Wayout2001@test.com"
            },
            new Personal
            {
                PersonalId = 2, FirstName = "This", LastName = "Way", BirthDate = new DateTime(2000, 02, 15),
                Email = "Wayout2000@test.com"
            }
        );
        modelBuilder.Entity<Team>().HasData(
            new Team { TeamId = 1, Name = "Way Out Now - WON", LocationId = 1 },
            new Team { TeamId = 2, Name = "Way Out Now Academy - A-WON", LocationId = 2 }
        );
        modelBuilder.Entity<Location>().HasData(
            new Location { LocationId = 1, Country = "Hungary", City = "Debrecen" },
            new Location { LocationId = 2, Country = "Korea", City = "Seoul" }
        );
        modelBuilder.Entity<Meal>().HasData(
            new Meal { MealId = 1, Name = "Power Up", MealType = MealType.Snack, Quantity = 1, FoodId = 1 },
            new Meal { MealId = 2, Name = "ThisWay", MealType = MealType.Breakfast, Quantity = 4, FoodId = 2 }
        );
        modelBuilder.Entity<Food>().HasData(
            new Food { FoodId = 1, Name = "Körte", Quantity = 1 },
            new Food { FoodId = 2, Name = "Alma", Quantity = 2 }
        );
        modelBuilder.Entity<FoodNutrient>().HasData(
            new FoodNutrient{FoodId = 1, NutrientId = 1, Quantity = 3}, 
            new FoodNutrient{FoodId = 1, NutrientId = 2, Quantity = 2},
            new FoodNutrient{FoodId = 2, NutrientId = 3, Quantity = 10}
        );
        modelBuilder.Entity<Nutrient>().HasData(
            new Nutrient{NutrientId = 1, Name = "Protein", Unit = "mg", NutrientType = NutrientType.Macro},
            new Nutrient{NutrientId = 2, Name = "Vitamin C", Unit = "mg", NutrientType = NutrientType.Vitamin},
            new Nutrient{NutrientId = 3, Name = "TesztADAT", Unit = "l", NutrientType = NutrientType.Mineral}
        );
        modelBuilder.Entity<Workout>().HasData(
            new Workout{WorkoutId = 1, Name = "SpecialOne", WorkoutType = WorkoutType.Cardio},
            new Workout{WorkoutId = 2, Name = "SpecialOne", WorkoutType = WorkoutType.Endurance}
            );
        modelBuilder.Entity<WorkoutExercise>().HasData(
            new WorkoutExercise{WorkoutId = 1, ExerciseId = 1, Set = 1 , Repetition = 2},
            new WorkoutExercise{WorkoutId = 1, ExerciseId = 2, Set = 2 , Repetition = 3},
            new WorkoutExercise{WorkoutId = 2, ExerciseId = 3, Set = 1 , Repetition = 2}
        );
        modelBuilder.Entity<Exercise>().HasData(
            new Exercise{ExerciseId = 1, Name = "Muscle Up", TargetMuscleMain = "Back", TargetMuscleSecondary = "Arm, Chest", IsRiskOfInjury = true, DifficultyType = DifficultyType.Advanced, EquipmentType = EquipmentType.Bodyweight},
            new Exercise{ExerciseId = 2, Name = "Squat", TargetMuscleMain = "Leg", IsRiskOfInjury = false, DifficultyType = DifficultyType.Intermediate, EquipmentType = EquipmentType.Bodyweight},
            new Exercise{ExerciseId = 3, Name = "Bench press", TargetMuscleMain = "Chest", TargetMuscleSecondary = "Arm", IsRiskOfInjury = false, DifficultyType = DifficultyType.Intermediate, EquipmentType = EquipmentType.Barbell}
            
        );


    }



}