using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mona.Web.Data;

namespace Mona.Web.Infrastructure
{
    public interface IEntityContextFactory
    {
        IDataContext DataContext { get; }
        IDataContext Get();
    }

    public class EntityContextFactory : IEntityContextFactory
    {
        protected IDataContext Context;

        public IDataContext DataContext
        {
            get { return Context ?? (Context = new DefaultContext()); }
        }

        public virtual IDataContext Get()
        {
            return Context ?? (Context = DataContext);
        }
    }
}