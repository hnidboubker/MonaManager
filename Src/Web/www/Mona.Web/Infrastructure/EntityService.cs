namespace Mona.Web.Infrastructure
{
    public interface IEntityService<T> : IService<T, long>
    {
    }

    public class EntityService<T> : Service<T, long>, IEntityService<T> where T : class
    {
        public EntityService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}