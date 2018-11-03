using System.Data.Entity;
using Mona.Server.Domain.Entities;

namespace Mona.Server.Data.Contexts
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