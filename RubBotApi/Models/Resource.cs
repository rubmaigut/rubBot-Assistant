using System.Text.Json.Serialization;
using RubBotApi.Util;

namespace RubBotApi.Models;

public class Resource
{
    public Resource()
    {
        Projects = new HashSet<Project>();
        Areas = new HashSet<Area>();
        Tasks = new HashSet<Tasks>();
    }
    public string Id { get; set; } =ShortGuidGenerator.GenerateShortGuid();
    public string Name { get; set; }
    public string StatusId { get; set; }
    [JsonIgnore]
    public virtual Status Status { get; set; }
    public string LabelId { get; set; }
    [JsonIgnore]
    public virtual Labels Labels { get; set; }
    
    public string Url { get; set; } = string.Empty;
    public ICollection<Area> Areas { get; set; }
    public ICollection<Project> Projects { get; set; }
    public ICollection<Tasks> Tasks { get; set; }
    public bool IsAchieved { get; set; }
    public bool Favorite { get; set; }

}