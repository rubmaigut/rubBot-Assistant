namespace RubBotApi.Models;

public class Status
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
}