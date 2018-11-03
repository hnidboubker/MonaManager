using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Threading;
using System.Threading.Tasks;
using Mona.Server.Data.Common;

namespace Mona.Server.Data.Contexts
{
    public class DataContext<TContext> : DbContext, IDataContext where TContext : DbContext
    {
        public DataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public virtual IDbSet<T> DbSet<T>() where T : class
        {
            DbSet<T> result = Set<T>();
            return result;
        }

        public new virtual DbEntityEntry Entry<T>(T entity) where T : class
        {
            DbEntityEntry<T> result = base.Entry(entity);
            return result;
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new FormattedDbEntityValidationException(ex);
            }
        }

        public override Task<int> SaveChangesAsync()
        {
            try
            {
                return base.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                throw new FormattedDbEntityValidationException(ex);
            }
        }

        public virtual int Commit()
        {
            int result = base.SaveChanges();
            return result;
        }

        public virtual async Task<int> CommitAsync()
        {
            int result = await base.SaveChangesAsync();
            return result;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TContext>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public interface IDataContext
    {
        DbChangeTracker ChangeTracker { get; }
        DbContextConfiguration Configuration { get; }
        IDbSet<T> DbSet<T>() where T : class;
        DbSet Set(Type entityType);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        DbEntityEntry Entry<T>(T entity) where T : class;
        DbEntityEntry Entry(object entity);
        void Dispose();
        string ToString();
        bool Equals(object obj);
        int GetHashCode();
        Type GetType();
        int Commit();
        Task<int> CommitAsync();
    }
}