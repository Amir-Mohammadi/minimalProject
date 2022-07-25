using Microsoft.EntityFrameworkCore;
using minimalProject.Core.Data;
using System.Linq.Expressions;

namespace minimalProject.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext dbContext;
        private DbSet<TEntity> entities { get; }
        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            entities = this.dbContext.Set<TEntity>();
        }

        #region AsyncMethod
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            await entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            if (saveNow)
                await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
        #endregion


        public void Add(TEntity entity, bool saveNow = true)
        {
            throw new NotImplementedException();
        }



        public void AddRange(IQueryable<TEntity> entities, bool saveNow = true)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IQueryable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            throw new NotImplementedException();
        }

        public void Attach(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity, bool saveNow = true)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate, bool saveNow = true)
        {
            throw new NotImplementedException();
        }

        public void Delete(IQueryable<TEntity> entities, bool saveNow = true)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken, bool saveNow = true)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IQueryable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            throw new NotImplementedException();
        }

        public void Detach(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public void Update(TEntity entity, bool saveNow = true)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IQueryable<TEntity> entities, bool saveNow = true)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRangeAsync(IQueryable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, IInclude<TEntity> include = null)
        {
            var query = GetQuery(include);
            query = query.Where(predicate);
            return query.FirstOrDefault();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken, IInclude<TEntity> include = null)
        {
            var query = GetQuery(include);
            query = query.Where(predicate);
            return query.FirstOrDefaultAsync(cancellationToken);
        }

        public IQueryable<TEntity> GetQuery(IInclude<TEntity> include = null)
        {
            var query = entities.AsQueryable();
            if (include != null)
                query = include.Execute(query);
            return query;
        }


    }
}
