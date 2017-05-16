using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Mona.Web.Entities;
using Mona.Web.Helpers;
using Mona.Web.Services;
using Mona.Web.ViewModels.Contacts;

namespace Mona.Web.Providers
{
    public interface IContactProvider
    {
        Task<List<ContactModel>> GetContacts();
        Task<ContactDeleteOrDetailsModel> GetContactDetails(long id);
        Task<ContactAddOrUpdateModel> GetContact(long id);
        Task CreateContact(ContactAddOrUpdateModel model);
        Task UpdateContact(long id, ContactAddOrUpdateModel model);
        Task DeleteContact(long id);

    }

    public class ContactProvider : IContactProvider
    {
        protected IContactService Service;

        public ContactProvider(IContactService service)
        {
            Service = service;
        }

        public virtual async Task<List<ContactModel>> GetContacts()
        {
            var result = await Service.GetAll().OrderBy(o => o.FirstName).ToListAsync();
            var model = new List<ContactModel>();
            if (result.Any())
            {
                foreach (var c in result)
                {
                    var builder = new ContactModel
                    {
                        Id = c.Id,
                        Picture = c.Picture,
                        FullName = c.FullName,
                        PhoneNumber = c.PhoneNumber,
                        Email = c.Email
                    };
                    model.Add(builder);
                }
            }
            return model;
        }

        public virtual async Task<ContactDeleteOrDetailsModel> GetContactDetails(long id)
        {
            var contact = await Service.FindByIdAsync(id);
            var model = new ContactDeleteOrDetailsModel()
            {
                Code = contact.Code,
                Picture = contact.Picture,
                ContactType = contact.ContactType,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email,
                TwiterAddress = contact.TwiterAddress,
                FaceBookAddress = contact.FaceBookAddress
            };
            return model;
            
        }

        public virtual async Task<ContactAddOrUpdateModel> GetContact(long id)
        {
            var contact = await Service.FindByIdAsync(id);
            var model = new ContactAddOrUpdateModel()
            {
                Code = contact.Code,
                Picture = contact.Picture,
                ContactType = contact.ContactType,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email,
                TwiterAddress = contact.TwiterAddress,
                FaceBookAddress = contact.FaceBookAddress
            };
            return model;
        }

        public virtual async Task CreateContact(ContactAddOrUpdateModel model)
        {
           
            var contact = new Contact
            {
                Id = new long(),
                Code = CodeGeneratorHelper.GenerateCode(),
                ContactType = model.ContactType,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                TwiterAddress = model.TwiterAddress,
                FaceBookAddress = model.FaceBookAddress

            };

           await Service.InsertAsync(contact);
            // Todo do test if it works if not implement commit directly in the controller
            await Service.CommitAsync();
           
        }

        public virtual async Task UpdateContact(long id, ContactAddOrUpdateModel model)
        {
            var contact = await Service.FindByIdAsync(id);
             if (model != null)
                {
                    
                    contact.ContactType = model.ContactType;
                    contact.FirstName = model.FirstName;
                    contact.LastName = model.LastName;
                    contact.PhoneNumber = model.PhoneNumber;
                    contact.Email = model.Email;
                    contact.TwiterAddress = model.TwiterAddress;
                    contact.FaceBookAddress = model.FaceBookAddress;
                }
            await Service.UpdateAsync(contact);
            // Todo do test if it works if not implement commit directly in the controller
            await Service.CommitAsync();
            
        }

        public virtual async Task DeleteContact(long id)
        {
            var contact = await Service.FindByIdAsync(id);

            await Service.RemoveAsync(contact);
            await Service.CommitAsync();
           
        }
    }
}