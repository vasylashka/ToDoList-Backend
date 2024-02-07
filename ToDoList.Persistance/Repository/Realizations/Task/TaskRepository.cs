using ToDoList.Persistance.Repository.Interfaces.Task;
using ToDoList.Persistance.Repository.Realizations.Base;

namespace ToDoList.Persistance.Repository.Realizations.Task;

public class TaskRepository : BaseRepository<Domain.Entities.Task>, ITaskRepository
{
    public TaskRepository(ToDoListDbContext context)
            : base(context)
    {
    }
}
