using Life.Shared.Entities.Enums;

namespace Life.Shared.Entities;

public class Meal
{
    public int MealId { get; set; }
    public string Name { get; set; }
    public MealType MealType { get; set; }
    public string? Description { get; set; }
    public ushort Quantity { get; set; }

    public int FoodId { get; set; }
    public Food Food { get; set; }
}