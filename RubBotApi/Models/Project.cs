using System.Text.Json.Serialization;
using Microsoft.VisualBasic;

namespace RubBotApi.Models;

public class Project
{
    public Project()
    {
        Areas = new HashSet<Area>();
        Tasks = new HashSet<Tasks>();
        Resources = new HashSet<Resource>();
        Notes = new HashSet<Note>();
    }
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string StatusId { get; set; }
    [JsonIgnore]
    public virtual Status Status { get; set; }
    public ICollection<Area> Areas { get; set; }
    public ICollection<Tasks> Tasks { get; set; }
    public ICollection<Resource> Resources { get; set; }
    public ICollection<Note> Notes { get; set; }
    public bool IsAchieved { get; set; }
    
}