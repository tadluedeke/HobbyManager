namespace HobbyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWorkflow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workflow", "BaseCoat_PaintId", "dbo.Paint");
            DropForeignKey("dbo.Workflow", "HighlightTwo_PaintId", "dbo.Paint");
            DropForeignKey("dbo.Workflow", "HightlightOne_PaintId", "dbo.Paint");
            DropForeignKey("dbo.Workflow", "Prime_PaintId", "dbo.Paint");
            DropForeignKey("dbo.Workflow", "Shade_PaintId", "dbo.Paint");
            DropIndex("dbo.Workflow", new[] { "BaseCoat_PaintId" });
            DropIndex("dbo.Workflow", new[] { "HighlightTwo_PaintId" });
            DropIndex("dbo.Workflow", new[] { "HightlightOne_PaintId" });
            DropIndex("dbo.Workflow", new[] { "Prime_PaintId" });
            DropIndex("dbo.Workflow", new[] { "Shade_PaintId" });
            AddColumn("dbo.Workflow", "PrimeId", c => c.Int(nullable: false));
            AddColumn("dbo.Workflow", "BaseCoatId", c => c.Int(nullable: false));
            AddColumn("dbo.Workflow", "ShadeId", c => c.Int(nullable: false));
            AddColumn("dbo.Workflow", "HightlightOneId", c => c.Int(nullable: false));
            AddColumn("dbo.Workflow", "HighlightTwoId", c => c.Int(nullable: false));
            DropColumn("dbo.Workflow", "BaseCoat_PaintId");
            DropColumn("dbo.Workflow", "HighlightTwo_PaintId");
            DropColumn("dbo.Workflow", "HightlightOne_PaintId");
            DropColumn("dbo.Workflow", "Prime_PaintId");
            DropColumn("dbo.Workflow", "Shade_PaintId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workflow", "Shade_PaintId", c => c.Int());
            AddColumn("dbo.Workflow", "Prime_PaintId", c => c.Int());
            AddColumn("dbo.Workflow", "HightlightOne_PaintId", c => c.Int());
            AddColumn("dbo.Workflow", "HighlightTwo_PaintId", c => c.Int());
            AddColumn("dbo.Workflow", "BaseCoat_PaintId", c => c.Int());
            DropColumn("dbo.Workflow", "HighlightTwoId");
            DropColumn("dbo.Workflow", "HightlightOneId");
            DropColumn("dbo.Workflow", "ShadeId");
            DropColumn("dbo.Workflow", "BaseCoatId");
            DropColumn("dbo.Workflow", "PrimeId");
            CreateIndex("dbo.Workflow", "Shade_PaintId");
            CreateIndex("dbo.Workflow", "Prime_PaintId");
            CreateIndex("dbo.Workflow", "HightlightOne_PaintId");
            CreateIndex("dbo.Workflow", "HighlightTwo_PaintId");
            CreateIndex("dbo.Workflow", "BaseCoat_PaintId");
            AddForeignKey("dbo.Workflow", "Shade_PaintId", "dbo.Paint", "PaintId");
            AddForeignKey("dbo.Workflow", "Prime_PaintId", "dbo.Paint", "PaintId");
            AddForeignKey("dbo.Workflow", "HightlightOne_PaintId", "dbo.Paint", "PaintId");
            AddForeignKey("dbo.Workflow", "HighlightTwo_PaintId", "dbo.Paint", "PaintId");
            AddForeignKey("dbo.Workflow", "BaseCoat_PaintId", "dbo.Paint", "PaintId");
        }
    }
}
