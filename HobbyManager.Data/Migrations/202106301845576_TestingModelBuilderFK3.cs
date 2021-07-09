namespace HobbyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingModelBuilderFK3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Workflow", "HighlightTwoId");
            AddForeignKey("dbo.Workflow", "HighlightTwoId", "dbo.Paint", "PaintId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workflow", "HighlightTwoId", "dbo.Paint");
            DropIndex("dbo.Workflow", new[] { "HighlightTwoId" });
        }
    }
}
