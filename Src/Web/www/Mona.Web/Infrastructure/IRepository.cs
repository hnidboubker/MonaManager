using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Mona.Web.Entities;

namespace Mona.Web.Infrastructure
{
    public interface IRepository<T, TKey>
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

    public abstract class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected IDbSet<T> DbSet;
        private bool disposed;

        public Repository()
        {
            disposed = false;
        }

        public abstract IQueryable<T> GetQuery { get; }

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

        public abstract T FindById(TKey id);


        public virtual async Task<T> FindByIdAsync(TKey id)
        {
            var query = await Task.FromResult(FindById(id));
            return query;
        }

        public abstract T Insert(T entity);


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

        public abstract T Remove(T contact);

        public virtual async Task<T> RemoveAsync(T entity)
        {
            var query = await Task.FromResult(Remove(entity));
            return query;
        }

        // Todo Move it to Unit work after 
        public abstract int Commit();


        public abstract Task<int> CommitAsync();


    }
}