namespace ToDoList.Persistance.Repository.Interfaces.Base;

public interface IBaseRepository<T> where T : class
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T?> GetOneOrDefaultAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression);
    Task<IReadOnlyCollection<T>> GetAllAsync();
}
