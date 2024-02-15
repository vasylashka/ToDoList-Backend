using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.API.Contracts.Task;
using ToDoList.Services.DTOs.Task;
using ToDoList.Services.Services.Interfaces;

namespace ToDoList.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;

    public TaskController(IServiceManager serviceManager, IMapper mapper)
    {
        _serviceManager = serviceManager;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskCreateContract request)
    {
        var dto = _mapper.Map<TaskCreateDto>(request);
        await _serviceManager.TaskService.CreateTaskAsync(dto);
        return StatusCode(201);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(int id, TaskUpdateContract request)
    {
        var dto = _mapper.Map<TaskUpdateDto>(request);
        await _serviceManager.TaskService.UpdateTaskAsync(id, dto);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _serviceManager.TaskService.DeleteTaskAsync(id);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _serviceManager.TaskService.GetAllTasksAsync();
        return Ok(tasks);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var task = await _serviceManager.TaskService.GetTaskByIdAsync(id);
        return Ok(task);
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<IActionResult> UpdateStatus(int id, TaskUpdateStatusContract request)
    {
        var dto = _mapper.Map<TaskUpdateStatusDto>(request);
        await _serviceManager.TaskService.UpdateStatusAsync(id, dto);
        return Ok();
    }
}
