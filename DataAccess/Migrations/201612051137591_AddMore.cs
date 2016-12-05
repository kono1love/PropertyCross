namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlatDB", "Latitude", c => c.String());
            AddColumn("dbo.FlatDB", "Longitude", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FlatDB", "Longitude");
            DropColumn("dbo.FlatDB", "Latitude");
        }
    }
}
