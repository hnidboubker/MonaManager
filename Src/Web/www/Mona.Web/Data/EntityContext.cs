using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mona.Web.Data
{
    public class EntityContext : DataContext<EntityContext>
    {
    }

    public class DataContext<TContext> : DbContext where TContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TContext>());
        }
    }
}