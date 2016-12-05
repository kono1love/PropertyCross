namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewParameters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlatDB", "ImgUrl", c => c.String());
            AddColumn("dbo.FlatDB", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FlatDB", "Title");
            DropColumn("dbo.FlatDB", "ImgUrl");
        }
    }
}
