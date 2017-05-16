using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Mona.Web.Data;

namespace Mona.Web.Infrastructure
{
    public interface IEntityRepository<T> : IRepository<T, long>
    {
    }

    public class EntityRepository<T> : Repository<T, long>, IEntityRepository<T> where T : class
    {
        protected DefaultContext Context;
        private readonly bool _disposed;

        public EntityRepository()
        {
            DbSet = DataContext.Set<T>();
            _disposed = false;
        }

        // Todo Move this to Context Factory
        public DefaultContext DataContext
        {
            get { return Context ?? (Context = new DefaultContext()); }
        }

        

        //public override T Insert(T entity)
        //{
        //    if (entity != null)
        //    {
        //        DbSet.Add(entity);
        //    }
        //    return entity;
        //}

        public override T Update(T entity)
        {
            if (entity != null)
            {
                DataContext.Entry(entity).State = EntityState.Modified;
            }
            return entity;
        }

        //public override T Remove(T entity)
        //{
        //    if (entity != null)
        //    {
        //        DbSet.Remove(entity);
        //    }
        //    return entity;
        //}

        // Todo Move this to Unit Of Work
        public override int Commit()
        {
            var query = DataContext.Commit();
            return query;
        }

        // Todo Move this to Unit Of Work
        public override async Task<int> CommitAsync()
        {
            var query = await DataContext.SaveChangesAsync();
            return query;
        }

        public override void Dispose()
        {
           Dispose(true);
            GC.SuppressFinalize(this);
        }

        public override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DataContext.Dispose();
                }
            }

        }
    }
}