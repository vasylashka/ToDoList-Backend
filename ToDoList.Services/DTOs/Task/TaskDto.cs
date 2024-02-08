using System.ComponentModel.DataAnnotations;
using ToDoList.Domain.Enums;

namespace ToDoList.Services.DTOs.Task;

public class TaskDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime DueDate { get; set; }
    public StatusTypes Status { get; set; }
}
