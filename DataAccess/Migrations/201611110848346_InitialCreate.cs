namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlatDB",
                c => new
                    {
                        FlatId = c.Int(nullable: false, identity: true),
                        FlatLocation = c.String(),
                        Summary = c.String(),
                        Price = c.String(),
                        BedNum = c.String(),
                        BathNum = c.String(),
                    })
                .PrimaryKey(t => t.FlatId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FlatDB");
        }
    }
}
