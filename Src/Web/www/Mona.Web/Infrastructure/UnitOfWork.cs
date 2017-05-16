using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Mona.Web.Data;

namespace Mona.Web.Infrastructure
{
    public interface IUnitOfWork
    {
        IDataContext DataContext { get; }
        int Commit();
        Task<int> CommitAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        protected IDataContext Context;
        protected IEntityContextFactory EntityContextFactory;

        public UnitOfWork(IEntityContextFactory entityContextFactory)
        {
            EntityContextFactory = entityContextFactory;
        }

        public IDataContext DataContext
        {
            get { return Context ?? (Context = EntityContextFactory.Get()); }
        }

        public virtual int Commit()
        {
            var result = DataContext.Commit();
            return result;
        }

        public virtual async Task<int> CommitAsync()
        {
            var result = await DataContext.CommitAsync();
            return result;
        } 
    }
}