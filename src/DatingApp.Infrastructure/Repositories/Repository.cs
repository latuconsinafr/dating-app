using DatingApp.Core.Repositories;
using DatingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Infrastructure.Repositories;

public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
{
  private readonly AppDbContext _context = context;

  public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
  {
    await _context.Set<T>().AddAsync(entity, cancellationToken);
    await _context.SaveChangesAsync(cancellationToken);

    return entity;
  }

  public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
  {
    return await _context.Set<T>().ToListAsync(cancellationToken);
  }

  public async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
  {
    return await _context.Set<T>().FindAsync(id);
  }

  public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
  {
    _context.Set<T>().Update(entity);
    await _context.SaveChangesAsync(cancellationToken);
  }

  public async Task DeleteAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
  {
    var entity = await _context.Set<T>().FindAsync([id], cancellationToken: cancellationToken);

    if (entity != null)
    {
      _context.Set<T>().Remove(entity);
      await _context.SaveChangesAsync(cancellationToken);
    }
  }
}
