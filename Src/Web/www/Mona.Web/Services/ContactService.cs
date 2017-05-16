using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Mona.Web.Contracts;
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
        protected IContactRepository Repository;

        public ContactService(IContactRepository repository)
        {
            Repository = repository;
        }

        public virtual IQueryable<Contact> GetAll()
        {
            var result = Repository.GetAll();
            return result;
        }

        public virtual async Task<List<Contact>> GetAllAsync()
        {
            var result = await Repository.GetAllAsync();
            return result;
        }

        public virtual Contact FindById(long id)
        {
            var result = Repository.FindById(id);
            return result;
        }

        public virtual async Task<Contact> FindByIdAsync(long id)
        {
            var result = await Repository.FindByIdAsync(id);
            return result;
        }

        public virtual Contact Insert(Contact contact)
        {
            var result = Repository.Insert(contact);
            return result;
        }

        public virtual async Task<Contact> InsertAsync(Contact contact)
        {
            var result = await Repository.InsertAsync(contact);
            return result;
        }

        public virtual Contact Update(Contact contact)
        {
            var result = Repository.Update(contact);
            return result;
        }

        public virtual async Task<Contact> UpdateAsync(Contact contact)
        {
            var result = await Repository.UpdateAsync(contact);
            return result;
        }

        public virtual Contact Remove(Contact contact)
        {
            var result = Repository.Remove(contact);
            return result;
        }

        public virtual Task<Contact> RemoveAsync(Contact contact)
        {
            var result = Repository.RemoveAsync(contact);
            return result;
        }

        public virtual int Commit()
        {
            var result = Repository.Commit();
            return result;
        }

        public virtual async Task<int> CommitAsync()
        {
            var result = await Repository.CommitAsync();
            return result;
        }
    }
}