using System.Linq.Expressions;

namespace ScheduleReminder.Core.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task InsertAsync(TEntity entity);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity,bool>> expression);
    IQueryable<TEntity> GetAllPagenatedAsync(Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize);
    Task<int> GetTotalCountAsync(Expression<Func<TEntity, bool>> expression);
    void Remove(TEntity entity);
    Task<int> CommitAsync();
}
