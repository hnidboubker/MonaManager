namespace Mona.Server.Data.Contexts
{
    public class EntityContext : DataContext<EntityContext>
    {
        public EntityContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
    }
}