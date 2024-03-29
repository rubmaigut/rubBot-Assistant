using System.Text.Json.Serialization;
using RubBotApi.Util;

namespace RubBotApi.Models;

public class Area
{
    public Area()
    {
        Projects = new HashSet<Project>();
        Resources = new HashSet<Resource>();
        //Notes = new HashSet<Note>();
    }
    public string Id { get; set; } = ShortGuidGenerator.GenerateShortGuid();
    public string Name { get; set; }
    
    public string LabelId { get; set; }
    
    [JsonIgnore]
    public virtual Labels Labels { get; set; }
    public string AreaCover { get; set; }
    public bool IsAchieved { get; set; }
    public ICollection<Project> Projects { get; set; }
    public ICollection<Resource> Resources { get; set; }
    //public ICollection<Note> Notes { get; set; }
}