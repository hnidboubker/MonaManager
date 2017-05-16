using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mona.Web.Infrastructure
{
    public interface IEntityService<T> : IService<T, long>
    {
    }

    public class EntityService<T> : Service<T, long>, IEntityService<T>
    {
    }
}