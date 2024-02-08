namespace ToDoList.Services.Services.Interfaces;

public interface IServiceManager
{
    ITaskService TaskService { get; }
}
