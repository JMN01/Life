namespace Life.Shared.Entities;

public class Food
{
    public int FoodId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }

    public ICollection<FoodNutrient> FoodNutrients { get; set; }
}