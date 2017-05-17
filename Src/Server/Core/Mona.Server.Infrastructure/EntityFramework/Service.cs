using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mona.Server.Infrastructure.EntityFramework
{
    public interface IService<T, in TKey>
    {
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

    public abstract class Service<T, TKey> : IService<T, TKey> where T : class
    {
        protected IRepository<T, TKey> Repository;
        protected IUnitOfWork UnitOfWork;

        protected Service(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> result = Repository.GetAll();
            return result;
        }


        public virtual async Task<List<T>> GetAllAsync()
        {
            List<T> result = await Repository.GetAllAsync();
            return result;
        }

        public virtual T FindById(TKey id)
        {
            T result = Repository.FindById(id);
            return result;
        }


        public virtual async Task<T> FindByIdAsync(TKey id)
        {
            T result = await Repository.FindByIdAsync(id);
            return result;
        }

        public virtual T Insert(T entity)
        {
            T result = Repository.Insert(entity);
            return result;
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            T result = await Repository.InsertAsync(entity);
            return result;
        }

        public virtual T Update(T entity)
        {
            T result = Repository.Update(entity);
            return result;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            T result = await Repository.UpdateAsync(entity);
            return result;
        }

        public virtual T Remove(T entity)
        {
            T result = Repository.Remove(entity);
            return result;
        }

        public virtual async Task<T> RemoveAsync(T entity)
        {
            T result = await Repository.RemoveAsync(entity);
            return result;
        }

        public virtual int Commit()
        {
            int result = UnitOfWork.Commit();
            return result;
        }

        public virtual Task<int> CommitAsync()
        {
            Task<int> result = UnitOfWork.CommitAsync();
            return result;
        }
    }
}