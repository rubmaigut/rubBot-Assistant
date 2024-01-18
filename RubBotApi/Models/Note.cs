using System.Text.Json.Serialization;
using RubBotApi.Util;

namespace RubBotApi.Models;

public class Note
{
    public string Id { get; set; } = ShortGuidGenerator.GenerateShortGuid();
    
    public string Name { get; set; } = string.Empty;
    public string StatusId { get; set; }
    [JsonIgnore]
    public virtual Status Status { get; set; }
    public string LabelId { get; set; }
    [JsonIgnore]
    public virtual Labels Labels { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public DateTime LastEditedTime { get; set; } = DateTime.Now;
    public virtual Area Areas { get; set; }
    public virtual Project Projects { get; set; }
    public string TaskId { get; set; } 
    [JsonIgnore]
    public virtual Tasks Tasks { get; set; }
    public virtual Resource Resources { get; set; }
    public bool IsAchieved { get; set; }
}