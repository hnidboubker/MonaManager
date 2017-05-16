using Mona.Web.Entities;
using Mona.Web.Infrastructure;

namespace Mona.Web.Contracts
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