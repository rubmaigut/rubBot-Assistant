using RubBotApi.Util;

namespace RubBotApi.Models;

public class NoteBooks
{
    // public NoteBooks()
    // {
    //     //Notes = new HashSet<Note>();
    // }
    public string Id { get; set; } = ShortGuidGenerator.GenerateShortGuid();
    public string Name { get; set; }
    //public ICollection<Note> Notes { get; set; }
}