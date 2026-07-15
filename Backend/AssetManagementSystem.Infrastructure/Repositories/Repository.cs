using AssetManagementSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Infrastructure.Repositories;

public class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : class
{
    // protected readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<T>().FindAsync(id, cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        context.Set<T>().Update(entity);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await context.Set<T>().FindAsync(id, cancellationToken);
        
        if (entity != null)
        {
            context.Set<T>().Remove(entity);
        }
    }
}