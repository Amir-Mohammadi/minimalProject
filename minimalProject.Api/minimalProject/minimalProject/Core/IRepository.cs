using System.Linq.Expressions;

namespace minimalProject.Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity, bool saveNow = true);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
        void AddRange(IQueryable<TEntity> entities, bool saveNow = true);
        Task AddRangeAsync(IQueryable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
        void Attach(TEntity entity);
        void Delete(TEntity entity, bool saveNow = true);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
        void Delete(Expression<Func<TEntity, bool>> predicate, bool saveNow = true);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken, bool saveNow = true);
        void Delete(IQueryable<TEntity> entities, bool saveNow = true);
        Task DeleteAsync(IQueryable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
        void Detach(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> predicate, IInclude<TEntity> include = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken, IInclude<TEntity> include = null);
        IQueryable<TEntity> GetQuery(IInclude<TEntity> include = null);
        void Update(TEntity entity, bool saveNow = true);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
        void UpdateRange(IQueryable<TEntity> entities, bool saveNow = true);
        Task UpdateRangeAsync(IQueryable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);



    }
}
