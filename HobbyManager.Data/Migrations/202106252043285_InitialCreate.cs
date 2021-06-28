namespace HobbyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Model",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Scale = c.String(),
                        Brand = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ModelId);
            
            CreateTable(
                "dbo.Paint",
                c => new
                    {
                        PaintId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Brand = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Color = c.String(),
                        SKU = c.String(),
                        Workflow_WorkflowId = c.Int(),
                        Workflow_WorkflowId1 = c.Int(),
                        Workflow_WorkflowId2 = c.Int(),
                        Workflow_WorkflowId3 = c.Int(),
                    })
                .PrimaryKey(t => t.PaintId)
                .ForeignKey("dbo.Workflow", t => t.Workflow_WorkflowId)
                .ForeignKey("dbo.Workflow", t => t.Workflow_WorkflowId1)
                .ForeignKey("dbo.Workflow", t => t.Workflow_WorkflowId2)
                .ForeignKey("dbo.Workflow", t => t.Workflow_WorkflowId3)
                .Index(t => t.Workflow_WorkflowId)
                .Index(t => t.Workflow_WorkflowId1)
                .Index(t => t.Workflow_WorkflowId2)
                .Index(t => t.Workflow_WorkflowId3);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Workflow",
                c => new
                    {
                        WorkflowId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Prime_PaintId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkflowId)
                .ForeignKey("dbo.Paint", t => t.Prime_PaintId)
                .Index(t => t.Prime_PaintId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paint", "Workflow_WorkflowId3", "dbo.Workflow");
            DropForeignKey("dbo.Workflow", "Prime_PaintId", "dbo.Paint");
            DropForeignKey("dbo.Paint", "Workflow_WorkflowId2", "dbo.Workflow");
            DropForeignKey("dbo.Paint", "Workflow_WorkflowId1", "dbo.Workflow");
            DropForeignKey("dbo.Paint", "Workflow_WorkflowId", "dbo.Workflow");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.Workflow", new[] { "Prime_PaintId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Paint", new[] { "Workflow_WorkflowId3" });
            DropIndex("dbo.Paint", new[] { "Workflow_WorkflowId2" });
            DropIndex("dbo.Paint", new[] { "Workflow_WorkflowId1" });
            DropIndex("dbo.Paint", new[] { "Workflow_WorkflowId" });
            DropTable("dbo.Workflow");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Project");
            DropTable("dbo.Paint");
            DropTable("dbo.Model");
        }
    }
}
