namespace HobbyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Project", "StartDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Project", "FinishDate", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Project", "FinishDate", c => c.DateTime());
            AlterColumn("dbo.Project", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
