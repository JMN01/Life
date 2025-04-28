using System.Text.Json.Serialization;

namespace Life.Shared.Entities;

public class Location
{
    public int LocationId { get; set; }
    public string Country { get; set; }
    public string? PostalCode { get; set; }
    public string City { get; set; }
    public string? StreetName { get; set; }
    public string? StreetNumber { get; set; }
    [JsonIgnore]
    public ICollection<Team> Teams { get; set; }
}