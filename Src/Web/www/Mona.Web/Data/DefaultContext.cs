using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using Mona.Web.Common;
using Mona.Web.Entities;

namespace Mona.Web.Data
{
    public class DefaultContext : DbContext
    {
        public DefaultContext() : base("Default")
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
    }
}