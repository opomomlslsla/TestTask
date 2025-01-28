using Captcha.Domain.Entities;
using Captcha.Domain.Interfaces;
using Captcha.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Captcha.Infrastructure.Repositories.Common;

public abstract class BaseRepository<T>(Context context) : IRepository<T> where T : BaseEntity
{
    protected readonly Context Context = context;

    public virtual async Task AddEntity(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
        await SaveChangesAsync();
    }

    public virtual async Task DeleteEntity(T entity)
    {
        Context.Set<T>().Remove(entity);
        await SaveChangesAsync();
    }

    public virtual async Task UpdateEntity(T entity)
    {
        Context.Set<T>().Update(entity);
        await SaveChangesAsync();
    }

    public virtual async Task<ICollection<T>> GetAllEntitiesAsync()
    {
        return await Context.Set<T>().AsNoTracking().ToListAsync();
    }

    public virtual async Task<ICollection<T>> GetEntitiesByAsync(Expression<Func<T, bool>> predicate)
    {
        return await Context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<T?> GetEntityByIdAsync(Guid id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public virtual async Task<T?> GetEntityByAsync(Expression<Func<T, bool>> predicate)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<bool> IsEntityExist(Guid id)
    {
        return await Context.Set<T>().AnyAsync(p => p.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}
