namespace DatingApp.Core.Common.Repositories;

public interface IBaseRepository<T> where T : class
{
  Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
  Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
  Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;
  Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
  Task DeleteAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;
}
