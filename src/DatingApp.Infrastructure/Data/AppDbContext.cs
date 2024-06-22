using System.Reflection;
using DatingApp.Core.Profiles.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  public DbSet<Profile> Profiles => Set<Profile>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // By using ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()), we instruct EF Core to scan the assembly for any classes that implement IEntityTypeConfiguration<T> and automatically apply their configurations.
  }
}
