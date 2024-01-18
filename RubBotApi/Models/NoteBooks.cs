namespace RubBotApi.Models;

public class NoteBooks
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public ICollection<Note> Notes { get; set; }
}