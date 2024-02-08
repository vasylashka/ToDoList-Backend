using ToDoList.Domain.Enums;

namespace ToDoList.API.Contracts.Task;

public class TaskCreateContract
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime DueDate { get; set; }
    public StatusTypes Status { get; set; }
}
