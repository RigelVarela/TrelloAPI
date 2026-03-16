namespace TrelloAPI.Models;

public class TaskList
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;   
    
    public int BoardId { get; set; }
    public Board Board { get; set; } = null!;
    public ICollection<TasksItem> Tasks { get; set; } = new List<TasksItem>();

}