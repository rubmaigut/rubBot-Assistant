namespace RubBotApi.Models;

public class AreaDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string LabelId { get; set; }
    public string AreaCover { get; set; }
    public bool IsAchieved { get; set; }
    public ICollection<string> ProjectIds { get; set; }  
    public ICollection<string> ResourceIds { get; set; } 
    public ICollection<string> NoteIds { get; set; }   

}