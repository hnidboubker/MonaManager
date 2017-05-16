namespace Mona.Web.Infrastructure
{
    public interface IEntityService<T> : IService<T, long>
    {
    }

    public class EntityService<T> : Service<T, long>, IEntityService<T>
    {
    }
}