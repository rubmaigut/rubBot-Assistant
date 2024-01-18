using Microsoft.VisualBasic;

namespace RubBotApi.Models;

public class Project
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public virtual Status Status { get; set; }
    public virtual ICollection<Area> Areas { get; set; }
    public ICollection<Task> Tasks { get; set; }
    public ICollection<Resource> Resources { get; set; }
    public ICollection<Note> Notes { get; set; }
    public bool IsAchieved { get; set; }
    
}