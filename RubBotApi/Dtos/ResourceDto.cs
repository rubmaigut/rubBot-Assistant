namespace RubBotApi.Models;

public class ResourceDto
{
    public string Id { get; set; } 
    public string Name { get; set; }
    public string StatusIds { get; set; }
    public string LabelsIds { get; set; }
    public string Url { get; set; }
    public ICollection<string> AreasIds { get; set; }
    public ICollection<string> ProjectsIds { get; set; }
    public ICollection<string> TasksIds { get; set; }
    public bool IsAchieved { get; set; }
    public bool Favorite { get; set; }

}