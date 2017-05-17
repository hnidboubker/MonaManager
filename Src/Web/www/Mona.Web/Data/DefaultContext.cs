using System.Data.Entity;
using Mona.Web.Entities;

namespace Mona.Web.Data
{
    public class DefaultContext : EntityContext
    {
        public DefaultContext() : base("Default")
        {
        }

        public IDbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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