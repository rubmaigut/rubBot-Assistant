using System.Text.Json.Serialization;
using RubBotApi.Util;

namespace RubBotApi.Models;

public class Tasks
{
    // public Tasks()
    // {
    //     Notes = new HashSet<Note>();
    // }
    
    public string Id { get; set; } = ShortGuidGenerator.GenerateShortGuid();
    public bool Done { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public virtual Project Projects { get; set; }
    public virtual Resource Resources { get; set; }
    //public virtual ICollection<Note> Notes { get; set; }
    public bool IsAchieved { get; set; }
    
}