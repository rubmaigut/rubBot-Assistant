using System.Text.Json.Serialization;

namespace RubBotApi.Models;

public class Resource
{
    public Resource()
    {
        Projects = new HashSet<Project>();
        Areas = new HashSet<Area>();
        Tasks = new HashSet<Tasks>();
    }
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string StatusId { get; set; }
    [JsonIgnore]
    public virtual Status Status { get; set; }
    public string LabelId { get; set; }
    [JsonIgnore]
    public virtual Labels Labels { get; set; }
    public string Url { get; set; }
    public ICollection<Area> Areas { get; set; }
    public ICollection<Project> Projects { get; set; }
    public ICollection<Tasks> Tasks { get; set; }
    public bool IsAchieved { get; set; }
    public bool Favorite { get; set; }

}