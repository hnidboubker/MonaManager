using Mona.Server.Domain.Entities;
using Mona.Server.Infrastructure.EntityFramework;

namespace Mona.Server.Contract.Contacts
{
    public interface IContactRepository : IEntityRepository<Contact>
    {
    }

    public class ContactRepository : EntityRepository<Contact>, IContactRepository
    {
        public ContactRepository(IEntityContextFactory entityContextFactory) : base(entityContextFactory)
        {
        }
    }
}