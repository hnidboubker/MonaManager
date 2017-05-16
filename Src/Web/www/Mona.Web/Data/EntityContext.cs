using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mona.Web.Data
{
    public class EntityContext : DataContext<EntityContext>
    {
        public EntityContext(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {
            
        }
    }

    public class DataContext<TContext> : DbContext where TContext : DbContext
    {
        public DataContext(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TContext>());
        }
    }
}