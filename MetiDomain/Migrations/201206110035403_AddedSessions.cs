namespace MetiDomain.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedSessions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Sessions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IP = c.String(),
                        UserId = c.Long(nullable: false),
                        UUID = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("Sessions", new[] { "UserId" });
            DropForeignKey("Sessions", "UserId", "Users");
            DropTable("Sessions");
        }
    }
}
