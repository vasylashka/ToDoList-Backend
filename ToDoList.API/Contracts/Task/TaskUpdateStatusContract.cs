using ToDoList.Domain.Enums;

namespace ToDoList.API.Contracts.Task;

public class TaskUpdateStatusContract
{
    public StatusTypes Status { get; set; }
}
