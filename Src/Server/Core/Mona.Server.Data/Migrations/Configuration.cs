using System.Data.Entity.Migrations;
using Mona.Server.Data.Contexts;

namespace Mona.Server.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DefaultContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DefaultContext context)
        {
           
        }
    }
}