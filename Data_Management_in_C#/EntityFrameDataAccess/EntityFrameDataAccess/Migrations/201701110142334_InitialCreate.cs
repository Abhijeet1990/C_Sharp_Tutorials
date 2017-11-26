namespace EntityFrameDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Blogid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Blogs", t => t.Blogid, cascadeDelete: true)
                .Index(t => t.Blogid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Blogid", "dbo.Blogs");
            DropIndex("dbo.Posts", new[] { "Blogid" });
            DropTable("dbo.Posts");
            DropTable("dbo.Blogs");
        }
    }
}
