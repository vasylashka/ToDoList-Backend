namespace ToDoList.Domain.Exceptions;

public class TaskNotFoundException : NotFoundException
{
    public TaskNotFoundException(int taskId) : base($"Task with identifier {taskId} not found") { }
}
