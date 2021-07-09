namespace HobbyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingTablesForViews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectModel",
                c => new
                    {
                        ProjectModelId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectModelId)
                .ForeignKey("dbo.Model", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.ModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectModel", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.ProjectModel", "ModelId", "dbo.Model");
            DropIndex("dbo.ProjectModel", new[] { "ModelId" });
            DropIndex("dbo.ProjectModel", new[] { "ProjectId" });
            DropTable("dbo.ProjectModel");
        }
    }
}
