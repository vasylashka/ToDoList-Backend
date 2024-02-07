namespace ToDoList.Persistance.Repository.Interfaces.Base;

public interface IBaseRepository<T> where T : class
{
    T Create(T entity);
    T Update(T entity);
    void Delete(T entity);
    Task<T?> GetOneOrDefaultAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression);
    Task<IList<T>?> GetAllAsync();
}
