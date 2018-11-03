using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mona.Server.Common.Domain;
using Mona.Server.Data.Contexts;

namespace Mona.Server.Infrastructure.EntityFramework
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
       
    }

    public abstract class Repository<T, TKey> : IDisposable, IRepository<T, TKey> where T : class, IEntity<TKey>
    {
        protected IDataContext Context;
        protected IDbSet<T> DbSet;
        protected IEntityContextFactory EntityContextFactory;
       

        protected Repository(IEntityContextFactory entityContextFactory)
        {
            EntityContextFactory = entityContextFactory;
            DbSet = DataContext.DbSet<T>();
            
        }

        public IDataContext DataContext
        {
            get { return Context ?? (Context = EntityContextFactory.Get()); }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
        public abstract void Dispose();

        public virtual IQueryable<T> GetQuery
        {
            get { return DbSet; }
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = GetQuery;
            return query;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            List<T> query = await GetQuery.ToListAsync();
            return query;
        }

        public virtual T FindById(TKey id)
        {
            T query = DbSet.Find(id);
            return query;
        }


        public virtual async Task<T> FindByIdAsync(TKey id)
        {
            T query = await Task.FromResult(FindById(id));
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
            T query = await Task.FromResult(Insert(entity));
            return query;
        }

        public abstract T Update(T entity);


        public virtual async Task<T> UpdateAsync(T entity)
        {
            T query = await Task.FromResult(Update(entity));
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
            T query = await Task.FromResult(Remove(entity));
            return query;
        }

        // Code Origine ABP Boilerplate 
        protected static Expression<Func<T, bool>> CreateEqualityExpressionForId(TKey id)
        {
            ParameterExpression lambdaParam = Expression.Parameter(typeof (TKey));

            BinaryExpression lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof (TKey))
                );

            return Expression.Lambda<Func<T, bool>>(lambdaBody, lambdaParam);
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
        public abstract void Dispose(bool disposing);
    }
}