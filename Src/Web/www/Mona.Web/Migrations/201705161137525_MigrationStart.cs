namespace Mona.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MigrationStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Picture = c.String(),
                        ContactType = c.Int(nullable: false),
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
