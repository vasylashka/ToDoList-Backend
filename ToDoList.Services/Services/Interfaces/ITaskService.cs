using System.Collections.Generic;
using ToDoList.Services.DTOs.Task;

namespace ToDoList.Services.Services.Interfaces;

public interface ITaskService
{
    Task CreateTaskAsync(TaskCreateDto taskCreateDto);
    Task UpdateTaskAsync(int taskId, TaskUpdateDto taskUpdateDto);
    Task DeleteTaskAsync(int taskId);
    Task UpdateStatusAsync(int taskId, TaskUpdateStatusDto status);
    Task<IReadOnlyCollection<TaskDto>> GetAllTasksAsync();
    Task<TaskDto> GetTaskByIdAsync(int id);


}
