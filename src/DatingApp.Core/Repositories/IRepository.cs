namespace DatingApp.Core.Repositories;

public interface IRepository<T> where T : class
{
  Task<T> AddAsync(T entity);
  Task<List<T>> GetAllAsync();
  Task<T?> GetByIdAsync(Guid id);
  Task UpdateAsync(T entity);
  Task DeleteAsync(Guid id);
}
