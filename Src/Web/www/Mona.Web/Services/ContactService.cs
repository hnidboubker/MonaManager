using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Mona.Web.Entities;

namespace Mona.Web.Services
{
    public interface IContactService
    {
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

    public class ContactService : IContactService
    {
        public IQueryable<Contact> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Contact FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> FindByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Contact Insert(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> InsertAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact Update(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> UpdateAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact Remove(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> RemoveAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }
    }
}