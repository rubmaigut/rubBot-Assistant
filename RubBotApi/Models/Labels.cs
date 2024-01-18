namespace RubBotApi.Models;

public class Labels

{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    
}
