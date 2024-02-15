using ToDoList.Domain.Enums;

namespace ToDoList.Services.DTOs.Task;

public class TaskUpdateStatusDto
{
    public StatusTypes Status { get; set; }
}
