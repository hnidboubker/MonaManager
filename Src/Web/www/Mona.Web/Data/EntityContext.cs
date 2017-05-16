using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mona.Web.Data
{
    public class EntityContext : DataContext<EntityContext>
    {
        public EntityContext(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {
            
        }
    }
}