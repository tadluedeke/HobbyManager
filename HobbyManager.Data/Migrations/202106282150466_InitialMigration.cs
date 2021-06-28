namespace HobbyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Project", "FinishDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Project", "FinishDate", c => c.DateTime(nullable: false));
        }
    }
}
