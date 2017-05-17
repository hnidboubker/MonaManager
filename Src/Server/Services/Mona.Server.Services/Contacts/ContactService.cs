using Mona.Server.Contract.Contacts;
using Mona.Server.Domain.Entities;
using Mona.Server.Infrastructure.EntityFramework;

namespace Mona.Server.Services.Contacts
{
    public interface IContactService : IEntityService<Contact>
    {
       
    }

    public class ContactService : EntityService<Contact>, IContactService
    {
        protected new IContactRepository Repository;

        public ContactService(IUnitOfWork unitOfWork, IContactRepository repository)
            : base(unitOfWork)
        {
            base.Repository = Repository = repository;
        }

    
        
    }
}