namespace DarzinTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductModels", "CreatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductModels", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
