using System.Text.Json.Serialization;

namespace Life.Shared.Entities;

public class FoodNutrient
{
    public int NutrientId { get; set; }
    public Nutrient Nutrient { get; set; }

    public int FoodId { get; set; }
    [JsonIgnore]
    public Food Food { get; set; }

    public float Quantity { get; set; }
}