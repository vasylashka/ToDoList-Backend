using ToDoList.Persistance.Repository.Interfaces.Task;
using ToDoList.Persistance.Repository.Realizations.Task;
using ToDoList.Persistance;
using ToDoList.Services.Services.Interfaces;
using AutoMapper;
using ToDoList.Persistance.Repository.Interfaces.Base;

namespace ToDoList.Services.Services.Realizations;

public sealed class ServiceManager : IServiceManager
{
    public ITaskService _taskService;

    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ServiceManager(IMapper mapper,IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }

    public ITaskService TaskService
    {
        get
        {
            if (_taskService is null)
            {
                _taskService = new TaskService(_repositoryWrapper, _mapper);
            }

            return _taskService;
        }
    }
}
