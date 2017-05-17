using System.Data.Entity.Migrations;

namespace Mona.Server.Data.Migrations
{
    public partial class MigrationStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                {
                    Id = c.Long(false, true),
                    Code = c.Int(false),
                    Picture = c.String(),
                    ContactType = c.Int(false),
                    FirstName = c.String(),
                    LastName = c.String(),
                    PhoneNumber = c.String(),
                    Email = c.String(),
                    TwiterAddress = c.String(),
                    FaceBookAddress = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Contact");
        }
    }
}