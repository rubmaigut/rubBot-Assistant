using RubBotApi.Util;

namespace RubBotApi.Models;

public class Status
{
    public string Id { get; set; } = ShortGuidGenerator.GenerateShortGuid();
    public string Name { get; set; }
    //public ICollection<Note> Notes { get; set; }
    public ICollection<Project> Projects { get; set; }
    public ICollection<Resource> Resources { get; set; }
    
    
}