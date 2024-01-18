using System.Text.Json.Serialization;

namespace RubBotApi.Models;

public class Note
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
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
    public virtual Tasks Tasks { get; set; }
    public virtual Resource Resources { get; set; }
    public bool IsAchieved { get; set; }
}