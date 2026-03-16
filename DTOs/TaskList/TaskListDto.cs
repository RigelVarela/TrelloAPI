namespace TrelloAPI.DTOs.TaskList;

public class TaskListDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int BoardId { get; set; }
}