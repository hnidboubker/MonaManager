using System;

namespace Mona.Server.Infrastructure.EntityFramework
{
    public interface IEntityRepository<T> : IRepository<T, long> where T : class
    {
    }

    public class EntityRepository<T> : Repository<T, long>, IEntityRepository<T> where T : class, IEntity<long>
    {
        //protected DefaultContext Context;
        private  bool _disposed;

        //public EntityRepository()
        //{
        //    DbSet = DataContext.Set<T>();
        //    
        //}

        // Todo Move this to Context Factory
        public EntityRepository(IEntityContextFactory entityContextFactory)
            : base(entityContextFactory)
        {
            //DbSet = DataContext.DbSet<T>();
            _disposed = false;
        }

        //public DefaultContext DataContext
        //{
        //    get { return Context ?? (Context = new DefaultContext()); }
        //}


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
        //public override int Commit()
        //{
        //    var query = DataContext.Commit();
        //    return query;
        //}

        // Todo Move this to Unit Of Work
        //public override async Task<int> CommitAsync()
        //{
        //    var query = await DataContext.SaveChangesAsync();
        //    return query;
        //}

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