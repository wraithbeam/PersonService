namespace PersonService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        SecondName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        BirstDate = c.DateTime(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        TitleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: true)
                .Index(t => t.TitleId);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "TitleId", "dbo.Titles");
            DropIndex("dbo.People", new[] { "TitleId" });
            DropTable("dbo.Titles");
            DropTable("dbo.People");
        }
    }
}
