using System.Text.Json.Serialization;

namespace Life.Shared.Entities;

public class Team
{
    public int TeamId { get; set; }
    public string Name { get; set; }

    public int LocationId { get; set; }
    public Location Location { get; set; }
    
    [JsonIgnore]
    public ICollection<Member> Members { get; set; }
}