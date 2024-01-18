using RubBotApi.Util;

namespace RubBotApi.Models;

public class Labels

{
    public Labels()
    {
        Id = Guid.NewGuid().ToString(); 
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public ICollection<Area> Areas { get; set; }
    //public ICollection<Note> Notes { get; set; }
    public ICollection<Resource> Resources { get; set; }
    
}
