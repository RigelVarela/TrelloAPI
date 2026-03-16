namespace TrelloAPI.Models;

public class Board
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } 
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    
    public ICollection<TaskList> TaskLists { get; set; } = new List<TaskList>();
}