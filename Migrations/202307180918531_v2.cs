namespace SignalR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Messages", "Group_Id", c => c.Int());
            CreateIndex("dbo.Messages", "Group_Id");
            AddForeignKey("dbo.Messages", "Group_Id", "dbo.Groups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "Group_Id", "dbo.Groups");
            DropIndex("dbo.Messages", new[] { "Group_Id" });
            DropColumn("dbo.Messages", "Group_Id");
            DropTable("dbo.Users");
            DropTable("dbo.Groups");
        }
    }
}
