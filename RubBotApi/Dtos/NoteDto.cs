namespace RubBotApi.Models;

public class NoteDto
{
    public string Id { get; set; } 
    public string Name { get; set; }
    public string StatusId { get; set; }
    public string LabelsId { get; set; }
    public DateTime CreatedTime { get; set; } 
    public DateTime LastEditedTime { get; set; }
    public  ICollection<string> AreasIds { get; set; }
    public  ICollection<string> ProjectsIds { get; set; }
    public  ICollection<string> TasksIds { get; set; }
    public ICollection<string> ResourcesIds { get; set; }
    public bool IsAchieved { get; set; }
}