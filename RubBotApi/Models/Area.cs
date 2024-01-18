namespace RubBotApi.Models;

public class Area
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public virtual Labels Type { get; set; }
    public string AreaCover { get; set; }
    public bool IsAchieved { get; set; }
    public ICollection<Project> Projects { get; set; }
    public ICollection<Resource> Resources { get; set; }
    public ICollection<Note> Notes { get; set; }
}