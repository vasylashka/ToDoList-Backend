using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Entities;

public class Task
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public required string Title { get; set; }
    [Required]
    [MaxLength(280)]
    public required string Description { get; set; }
    [Required]
    public DateTime CreationDate { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    public StatusTypes Status { get; set; }
}
