using Life.Shared.Entities.Enums;

namespace Life.Shared.Entities;

public class Nutrient
{
    public int NutrientId { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }
    public NutrientType NutrientType { get; set; }
}
