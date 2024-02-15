using AutoMapper;
using System.Collections.Generic;
using ToDoList.Domain.Exceptions;
using ToDoList.Persistance.Repository.Interfaces.Base;
using ToDoList.Services.DTOs.Task;
using ToDoList.Services.Services.Interfaces;

namespace ToDoList.Services.Services.Realizations;

public class TaskService : ITaskService
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly IMapper _mapper;

    public TaskService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }
    public async Task CreateTaskAsync(TaskCreateDto taskCreateDto)
    {
        var task = _mapper.Map<Domain.Entities.Task>(taskCreateDto);
        _repositoryWrapper.TaskRepository.Create(task);
        await _repositoryWrapper.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(int taskId)
    {
        var task = await _repositoryWrapper.TaskRepository.GetOneOrDefaultAsync(x => x.Id == taskId);
        if (task == null)
        {
            throw new TaskNotFoundException(taskId);
        }
        _repositoryWrapper.TaskRepository.Delete(task);
        await _repositoryWrapper.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<TaskDto>> GetAllTasksAsync()
    {
        var tasks = await _repositoryWrapper.TaskRepository.GetAllAsync();
        return  _mapper.Map<IReadOnlyCollection<TaskDto>>(tasks);
    }

    public async Task<TaskDto> GetTaskByIdAsync(int taskId)
    {
        var task = await _repositoryWrapper.TaskRepository.GetOneOrDefaultAsync(x => x.Id==taskId);
        if (task == null)
        {
            throw new TaskNotFoundException(taskId);
        }
        return _mapper.Map<TaskDto>(task);
    }

    public async Task UpdateStatusAsync(int taskId, TaskUpdateStatusDto status)
    {
        var task = await _repositoryWrapper.TaskRepository.GetOneOrDefaultAsync(x => x.Id == taskId);
        if (task == null)
        {
            throw new TaskNotFoundException(taskId);
        }
        task.Status = status.Status;
        _repositoryWrapper.TaskRepository.Update(task);
        await _repositoryWrapper.SaveChangesAsync();
    }

    public async Task UpdateTaskAsync(int taskId, TaskUpdateDto taskUpdateDto)
    {
        var task = await _repositoryWrapper.TaskRepository.GetOneOrDefaultAsync(x => x.Id == taskId);
        if (task == null)
        {
            throw new TaskNotFoundException(taskId);
        }
        _mapper.Map(taskUpdateDto, task);
        _repositoryWrapper.TaskRepository.Update(task);
        await _repositoryWrapper.SaveChangesAsync();
    }


}
