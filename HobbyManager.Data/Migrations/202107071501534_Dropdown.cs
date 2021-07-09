namespace HobbyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dropdown : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paint", "PrimeId_WorkflowId", c => c.Int());
            CreateIndex("dbo.Paint", "PrimeId_WorkflowId");
            AddForeignKey("dbo.Paint", "PrimeId_WorkflowId", "dbo.Workflow", "WorkflowId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paint", "PrimeId_WorkflowId", "dbo.Workflow");
            DropIndex("dbo.Paint", new[] { "PrimeId_WorkflowId" });
            DropColumn("dbo.Paint", "PrimeId_WorkflowId");
        }
    }
}
