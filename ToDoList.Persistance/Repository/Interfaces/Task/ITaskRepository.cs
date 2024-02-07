using ToDoList.Persistance.Repository.Interfaces.Base;
using ToDoList.Domain.Entities;

namespace ToDoList.Persistance.Repository.Interfaces.Task;

public interface ITaskRepository : IBaseRepository<Domain.Entities.Task>
{

}
