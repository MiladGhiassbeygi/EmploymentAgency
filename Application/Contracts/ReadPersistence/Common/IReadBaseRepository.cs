using System.Linq.Expressions;

namespace Application.Contracts.ReadPersistence.Common
{
    public interface IReadBaseRepository<TEntity> /*where TEntity : class*/
    {
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetWithFilterAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
        Task DeleteAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);

    }
}
