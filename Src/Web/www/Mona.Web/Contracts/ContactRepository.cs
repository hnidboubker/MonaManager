using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Mona.Web.Data;
using Mona.Web.Entities;

namespace Mona.Web.Contracts
{
    public interface IContactRepository
    {
        IQueryable<Contact> GetQuery { get; } 
        IQueryable<Contact> GetAll();
        Task<List<Contact>> GetAllAsync();
        Contact FindById(long id);
        Task<Contact> FindByIdAsync(long id);
        Contact Insert(Contact contact);
        Task<Contact> InsertAsync(Contact contact);
        Contact Update(Contact contact);
        Task<Contact> UpdateAsync(Contact contact);
        Contact Remove(Contact contact);
        Task<Contact> RemoveAsync(Contact contact);
        int Commit();
        Task<int> CommitAsync();
    }

    public class ContactRepository : IDisposable, IContactRepository
    {
        protected DefaultContext Context;
        protected IDbSet<Contact> DbSet;
        private bool disposed;

        public ContactRepository()
        {
            DbSet = DataContext.Set<Contact>();
            disposed = false;
        }

        public DefaultContext DataContext
        {
            get { return Context ?? (Context = new DefaultContext()); }
        }

        public IQueryable<Contact> GetQuery
        {
            get
            {
                var query = DbSet;
                return query;
            }
        }
        public virtual IQueryable<Contact> GetAll()
        {
            var query = GetQuery;
            return query;
        }

        public virtual async Task<List<Contact>> GetAllAsync()
        {
            var query = await GetQuery.ToListAsync();
            return query;
        }

        public virtual Contact FindById(long id)
        {
            var query = DbSet.FirstOrDefault(o => o.Id == id);
            return query;
        }

        public virtual async Task<Contact> FindByIdAsync(long id)
        {
            var query = await Task.FromResult(FindById(id));
            return query;
        }

        public virtual Contact Insert(Contact contact)
        {
            if (contact != null)
            {
                DbSet.Add(contact);
            }
            return contact;
        }

        public virtual async Task<Contact> InsertAsync(Contact contact)
        {
            var query = await Task.FromResult(Insert(contact));
            return query;
        }

        public virtual Contact Update(Contact contact)
        {
            if (contact != null)
            {
                DataContext.Entry(contact).State = EntityState.Modified;
            }
            return contact;
        }

        public virtual async Task<Contact> UpdateAsync(Contact contact)
        {
            var query = await Task.FromResult(Update(contact));
            return query;
        }

        public virtual Contact Remove(Contact contact)
        {
            if (contact != null)
            {
                DbSet.Remove(contact);
            }
            return contact;
        }

        public virtual async Task<Contact> RemoveAsync(Contact contact)
        {
            var query = await Task.FromResult(contact);
            return query;
        }

        public virtual int Commit()
        {
            var query = DataContext.Commit();
            return query;
        }

        public virtual async Task<int> CommitAsync()
        {
            var query = await DataContext.CommitAsync();
            return query;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DataContext.Dispose();
                }
            }
        }
    }
}