using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Mona.Web.Data;
using Mona.Web.Entities;
using Mona.Web.Infrastructure;

namespace Mona.Web.Contracts
{
    public interface IContactRepository : IEntityRepository<Contact>
    {
     
    }

    public class ContactRepository : EntityRepository<Contact>, IContactRepository
    {
      
    }
}