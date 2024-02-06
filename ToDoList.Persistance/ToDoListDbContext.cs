using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;

namespace ToDoList.Persistance;

public class ToDoListDbContext : DbContext
{
    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
    {

    }

    public DbSet<Domain.Entities.Task> Tasks => Set<Domain.Entities.Task>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Entities.Task>()
            .Property(b => b.Status)
            .HasDefaultValue(StatusTypes.ToDo);

        modelBuilder.Entity<Domain.Entities.Task>()
            .Property(b => b.CreationDate)
            .HasDefaultValueSql("getdate()");
    }
}
