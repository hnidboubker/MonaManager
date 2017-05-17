using Mona.Server.Contract.Contacts;
using Mona.Server.Domain.Entities;
using Mona.Server.Infrastructure.EntityFramework;

namespace Mona.Server.Services.Contacts
{
    public interface IContactService : IEntityService<Contact>
    {
        //IQueryable<Contact> GetAll();
        //Task<List<Contact>> GetAllAsync();
        //Contact FindById(long id);
        //Task<Contact> FindByIdAsync(long id);
        //Contact Insert(Contact contact);
        //Task<Contact> InsertAsync(Contact contact);
        //Contact Update(Contact contact);
        //Task<Contact> UpdateAsync(Contact contact);
        //Contact Remove(Contact contact);
        //Task<Contact> RemoveAsync(Contact contact);
        //int Commit();
        //Task<int> CommitAsync();
    }

    public class ContactService : EntityService<Contact>, IContactService
    {
        protected new IContactRepository Repository;

        public ContactService(IUnitOfWork unitOfWork, IContactRepository repository)
            : base(unitOfWork)
        {
            base.Repository = Repository = repository;
        }

        //public ContactService(IContactRepository repository)
        //{
        //    Repository = repository;
        //}

        //public virtual IQueryable<Contact> GetAll()
        //{
        //    IQueryable<Contact> result = Repository.GetAll();
        //    return result;
        //}

        //public virtual async Task<List<Contact>> GetAllAsync()
        //{
        //    List<Contact> result = await Repository.GetAllAsync();
        //    return result;
        //}

        //public virtual Contact FindById(long id)
        //{
        //    Contact result = Repository.FindById(id);
        //    return result;
        //}

        //public virtual async Task<Contact> FindByIdAsync(long id)
        //{
        //    Contact result = await Repository.FindByIdAsync(id);
        //    return result;
        //}

        //public virtual Contact Insert(Contact contact)
        //{
        //    Contact result = Repository.Insert(contact);
        //    return result;
        //}

        //public virtual async Task<Contact> InsertAsync(Contact contact)
        //{
        //    Contact result = await Repository.InsertAsync(contact);
        //    return result;
        //}

        //public virtual Contact Update(Contact contact)
        //{
        //    Contact result = Repository.Update(contact);
        //    return result;
        //}

        //public virtual async Task<Contact> UpdateAsync(Contact contact)
        //{
        //    Contact result = await Repository.UpdateAsync(contact);
        //    return result;
        //}

        //public virtual Contact Remove(Contact contact)
        //{
        //    Contact result = Repository.Remove(contact);
        //    return result;
        //}

        //public virtual Task<Contact> RemoveAsync(Contact contact)
        //{
        //    Task<Contact> result = Repository.RemoveAsync(contact);
        //    return result;
        //}

        //public virtual int Commit()
        //{
        //    int result = Repository.Commit();
        //    return result;
        //}

        //public virtual async Task<int> CommitAsync()
        //{
        //    int result = await Repository.CommitAsync();
        //    return result;
        //}
    }
}