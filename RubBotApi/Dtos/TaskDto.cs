namespace RubBotApi.Dtos;

public class TaskDto
{
    public string Id { get; set; }
    public bool Done { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string ProjectId { get; set; }  
    public string ResourceId { get; set; } 
    public string NoteId { get; set; }
}