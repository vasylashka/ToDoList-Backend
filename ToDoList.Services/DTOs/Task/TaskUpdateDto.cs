using ToDoList.Domain.Enums;

namespace ToDoList.Services.DTOs.Task;

public class TaskUpdateDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime DueDate { get; set; }
    public StatusTypes Status { get; set; }
}
