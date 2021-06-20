namespace EntityFrameworkTest.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "MyContext.Groups",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "MyContext.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    GroupId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MyContext.Groups", t => t.GroupId)
                .Index(t => t.GroupId);
        }

        public override void Down()
        {
            DropForeignKey("MyContext.Users", "GroupId", "MyContext.Groups");
            DropIndex("MyContext.Users", new[] { "GroupId" });
            DropTable("MyContext.Users");
            DropTable("MyContext.Groups");
        }
    }
}