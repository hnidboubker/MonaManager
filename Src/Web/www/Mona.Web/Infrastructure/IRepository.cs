using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mona.Web.Infrastructure
{
    public interface IRepository<T, in TKey> where T : class 
    {
        IQueryable<T> GetQuery { get; }
        IQueryable<T> GetAll();
        Task<List<T>> GetAllAsync();
        T FindById(TKey id);
        Task<T> FindByIdAsync(TKey id);
        T Insert(T contact);
        Task<T> InsertAsync(T entity);
        T Update(T contact);
        Task<T> UpdateAsync(T entity);
        T Remove(T contact);
        Task<T> RemoveAsync(T entity);
        int Commit();
        Task<int> CommitAsync();
    }

    public abstract class Repository<T, TKey> :IDisposable, IRepository<T, TKey> where T : class, IEntity<TKey>
    {
        protected IDbSet<T> DbSet;
        //private bool disposed;

        protected Repository()
        {
            //disposed = false;
        }

        public virtual IQueryable<T> GetQuery { get { return DbSet; } }

        public virtual IQueryable<T> GetAll()
        {
            var query = GetQuery;
            return query;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            var query = await GetQuery.ToListAsync();
            return query;
        }

        public virtual T FindById(TKey id)
        {
            var query = DbSet.Find(id);
            return query;
        }


        public virtual async Task<T> FindByIdAsync(TKey id)
        {
            var query = await Task.FromResult(FindById(id));
            return query;
        }

        public virtual T Insert(T entity)
        {
            if (entity != null)
            {
                DbSet.Add(entity);
            }
            return entity;

        }


        public virtual async Task<T> InsertAsync(T entity)
        {
            var query = await Task.FromResult(Insert(entity));
            return query;
        }

        public abstract T Update(T entity);


        public virtual async Task<T> UpdateAsync(T entity)
        {
            var query = await Task.FromResult(Update(entity));
            return query;
        }

        public virtual T Remove(T entity)
        {
            if (entity != null)
            {
                DbSet.Remove(entity);
            }
            return entity;
        }

        public virtual async Task<T> RemoveAsync(T entity)
        {
            var query = await Task.FromResult(Remove(entity));
            return query;
        }

        // Code Origine ABP Boilerplate 
        protected static Expression<Func<T, bool>> CreateEqualityExpressionForId(TKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TKey));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TKey))
                );

            return Expression.Lambda<Func<T, bool>>(lambdaBody, lambdaParam);
        }
        // Todo Move it to Unit work after 
        public abstract int Commit();


        public abstract Task<int> CommitAsync();

        public abstract void Dispose();
        public abstract void Dispose(bool disposing);


    }
}