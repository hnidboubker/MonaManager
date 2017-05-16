using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mona.Web.Infrastructure
{
    public interface IEntityRepository<T> : IRepository<T, long>
    {
    }

    public class EntityRepository<T> : Repository<T, long>, IEntityRepository<T>
    {
    }
}