using Mona.Server.Data.Contexts;

namespace Mona.Server.Infrastructure.EntityFramework
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