using DatingApp.Core.Repositories;
using DatingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Infrastructure.Repositories;

public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
{
  private readonly AppDbContext _context = context;

  public async Task<T> AddAsync(T entity)
  {
    await _context.Set<T>().AddAsync(entity);
    await _context.SaveChangesAsync();

    return entity;
  }

  public async Task<List<T>> GetAllAsync()
  {
    return await _context.Set<T>().ToListAsync();
  }

  public async Task<T?> GetByIdAsync(Guid id)
  {
    return await _context.Set<T>().FindAsync(id);
  }

  public async Task UpdateAsync(T entity)
  {
    _context.Set<T>().Update(entity);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteAsync(Guid id)
  {
    var entity = await _context.Set<T>().FindAsync(id);

    if (entity != null)
    {
      _context.Set<T>().Remove(entity);
      await _context.SaveChangesAsync();
    }
  }
}
