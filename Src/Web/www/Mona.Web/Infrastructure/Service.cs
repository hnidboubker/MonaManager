using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Mona.Web.Infrastructure
{
    public interface IService<T, TKey>
    {
        IQueryable<T> GetAll();
        Task<List<T>> GetAllAsync();
        T FindById(TKey id);
        Task<T> FindByIdAsync(T id);
        T Insert(T contact);
        Task<T> InsertAsync(T entity);
        T Update(T contact);
        Task<T> UpdateAsync(T entity);
        T Remove(T contact);
        Task<T> RemoveAsync(T entity);
        int Commit();
        Task<int> CommitAsync();
    }

    public abstract class Service<T, TKey> : IService<T, TKey>
    {
        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public T FindById(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindByIdAsync(T id)
        {
            throw new NotImplementedException();
        }

        public T Insert(T contact)
        {
            throw new NotImplementedException();
        }

        public Task<T> InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T contact)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public T Remove(T contact)
        {
            throw new NotImplementedException();
        }

        public Task<T> RemoveAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }
    }
}