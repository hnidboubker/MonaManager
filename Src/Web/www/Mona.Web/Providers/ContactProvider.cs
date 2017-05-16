using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Mona.Web.ViewModels.Contacts;

namespace Mona.Web.Providers
{
    public interface IContactProvider
    {
        Task<List<ContactModel>> GetContacts();
        Task<ContactDeleteOrDetailsModel> GetContactDetails(long id);
        Task<ContactAddOrUpdateModel> GetContact(long id);
        Task CreateContact(ContactAddOrUpdateModel model, HttpPostedFileBase file);
        Task UpdateContact(long id, ContactAddOrUpdateModel model, HttpPostedFileBase file);
        Task DeleteContact(long id);

    }

    public class ContactProvider : IContactProvider
    {
        public virtual Task<List<ContactModel>> GetContacts()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ContactDeleteOrDetailsModel> GetContactDetails(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ContactAddOrUpdateModel> GetContact(long id)
        {
            throw new NotImplementedException();
        }

        public Task CreateContact(ContactAddOrUpdateModel model, HttpPostedFileBase file)
        {
            throw new NotImplementedException();
        }

        public Task UpdateContact(long id, ContactAddOrUpdateModel model, HttpPostedFileBase file)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContact(long id)
        {
            throw new NotImplementedException();
        }
    }
}