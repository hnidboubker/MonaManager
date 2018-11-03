using System;
using System.Data.Entity;
using Mona.Server.Common.Domain;

namespace Mona.Server.Infrastructure.EntityFramework
{
    public interface IEntityRepository<T> : IRepository<T, long> where T : class
    {
    }

    public class EntityRepository<T> : Repository<T, long>, IEntityRepository<T> where T : class, IEntity<long>
    {
        
        private  bool _disposed;

        

        // Todo Move this to Context Factory
        public EntityRepository(IEntityContextFactory entityContextFactory)
            : base(entityContextFactory)
        {
         
            _disposed = false;
        }

        

        public override T Update(T entity)
        {
            if (entity != null)
            {
                DataContext.Entry(entity).State = EntityState.Modified;
            }
            return entity;
        }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
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