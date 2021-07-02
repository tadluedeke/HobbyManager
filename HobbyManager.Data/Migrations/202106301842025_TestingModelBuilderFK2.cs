namespace HobbyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingModelBuilderFK2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Workflow", "ShadeId");
            CreateIndex("dbo.Workflow", "HightlightOneId");
            AddForeignKey("dbo.Workflow", "HightlightOneId", "dbo.Paint", "PaintId");
            AddForeignKey("dbo.Workflow", "ShadeId", "dbo.Paint", "PaintId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workflow", "ShadeId", "dbo.Paint");
            DropForeignKey("dbo.Workflow", "HightlightOneId", "dbo.Paint");
            DropIndex("dbo.Workflow", new[] { "HightlightOneId" });
            DropIndex("dbo.Workflow", new[] { "ShadeId" });
        }
    }
}
