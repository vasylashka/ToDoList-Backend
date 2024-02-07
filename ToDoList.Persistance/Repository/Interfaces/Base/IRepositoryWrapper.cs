using ToDoList.Persistance.Repository.Interfaces.Task;

namespace ToDoList.Persistance.Repository.Interfaces.Base;

public interface IRepositoryWrapper
{
    ITaskRepository TaskRepository { get; }
    public Task<int> SaveChangesAsync();
}
