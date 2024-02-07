using ToDoList.Persistance.Repository.Interfaces.Base;
using ToDoList.Persistance.Repository.Interfaces.Task;
using ToDoList.Persistance.Repository.Realizations.Task;

namespace ToDoList.Persistance.Repository.Realizations.Base;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly ToDoListDbContext _dbContext;
    private ITaskRepository _taskRepository;

    public RepositoryWrapper(ToDoListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ITaskRepository TaskRepository
    {
        get
        {
            if (_taskRepository is null)
            {
                _taskRepository = new TaskRepository(_dbContext);
            }

            return _taskRepository;
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
