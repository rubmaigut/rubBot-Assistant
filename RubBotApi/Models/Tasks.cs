namespace RubBotApi.Models;

public class Tasks
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public bool Done { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public virtual Project Projects { get; set; }
    public virtual Resource Resources { get; set; }
    public virtual Note Notes { get; set; }
    public bool IsAchieved { get; set; }
    
}