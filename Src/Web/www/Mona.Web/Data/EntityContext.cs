namespace Mona.Web.Data
{
    public class EntityContext : DataContext<EntityContext>
    {
        public EntityContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
    }
}