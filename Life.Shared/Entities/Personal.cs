using System.Text.Json.Serialization;

namespace Life.Shared.Entities;

public class Personal
{
    public int PersonalId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? Gender { get; set; }
    public ushort? Weight { get; set; }
    public ushort? Height { get; set; }
    [JsonIgnore]
    public Member Member{ get; set; }
}