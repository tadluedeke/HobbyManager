namespace HobbyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingModelBuilderFK : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Workflow", "PrimeId");
            CreateIndex("dbo.Workflow", "BaseCoatId");
            AddForeignKey("dbo.Workflow", "BaseCoatId", "dbo.Paint", "PaintId");
            AddForeignKey("dbo.Workflow", "PrimeId", "dbo.Paint", "PaintId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workflow", "PrimeId", "dbo.Paint");
            DropForeignKey("dbo.Workflow", "BaseCoatId", "dbo.Paint");
            DropIndex("dbo.Workflow", new[] { "BaseCoatId" });
            DropIndex("dbo.Workflow", new[] { "PrimeId" });
        }
    }
}
