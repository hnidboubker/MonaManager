using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Mona.Web.Entities;

namespace Mona.Web.Data
{
    public class DefaultContext : DbContext
    {
        public DefaultContext():base("Default")
        {
            
        }

        public IDbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            ContactMapping(modelBuilder);
        }

        private void ContactMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Contact>()
                .ToTable("Contact")
                .HasKey(o => o.Id);

        }
    }
}