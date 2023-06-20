using Microsoft.EntityFrameworkCore;
using ScheduleReminder.Core.Repositories;
using System.Linq.Expressions;

namespace ScheduleReminder.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DataContext _dataContext;

    public Repository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<int> CommitAsync()
    {
        return await _dataContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dataContext.Set<TEntity>().Where(expression).ToListAsync();
    }

    public IQueryable<TEntity> GetAllPagenatedAsync(Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize)
    {
        return _dataContext.Set<TEntity>().Where(expression).Skip((pageIndex - 1) * pageSize).Take(pageSize);
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dataContext.Set<TEntity>().FirstOrDefaultAsync(expression);
    }

    public async Task<int> GetTotalCountAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dataContext.Set<TEntity>().CountAsync(expression);
    }

    public async Task InsertAsync(TEntity entity)
    {
        await _dataContext.Set<TEntity>().AddAsync(entity);
    }

    public void Remove(TEntity entity)
    {
        _dataContext.Set<TEntity>().Remove(entity);
    }
}
