namespace EnumCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProffessor : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Proffessors",
                c => new
                    {
                        ProffID = c.Int(nullable: false, identity: true),
                        Names = c.Int(nullable: false),
                        Research = c.String(),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProffID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Proffessors");
            
        }
    }
}
