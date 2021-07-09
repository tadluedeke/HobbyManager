namespace HobbyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrorSaysTo1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectWorkflow",
                c => new
                    {
                        ProjectWorkflowId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        WorkflowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectWorkflowId)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Workflow", t => t.WorkflowId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.WorkflowId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectWorkflow", "WorkflowId", "dbo.Workflow");
            DropForeignKey("dbo.ProjectWorkflow", "ProjectId", "dbo.Project");
            DropIndex("dbo.ProjectWorkflow", new[] { "WorkflowId" });
            DropIndex("dbo.ProjectWorkflow", new[] { "ProjectId" });
            DropTable("dbo.ProjectWorkflow");
        }
    }
}
