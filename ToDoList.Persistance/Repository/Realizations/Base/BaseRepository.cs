using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using ToDoList.Persistance.Repository.Interfaces.Base;

namespace ToDoList.Persistance.Repository.Realizations.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ToDoListDbContext _dbContext;
    protected BaseRepository(ToDoListDbContext context)
    {
        _dbContext = context;
    }

    public T Create(T entity)
    {
        return _dbContext.Set<T>().Add(entity).Entity;
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public async Task<IList<T>?> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetOneOrDefaultAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbContext.Set<T>().Where(expression).FirstOrDefaultAsync();
    }

    public T Update(T entity)
    {
        return _dbContext.Set<T>().Update(entity).Entity;
    }
}
