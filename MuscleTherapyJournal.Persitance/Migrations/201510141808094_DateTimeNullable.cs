namespace MuscleTherapyJournal.Persitance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Treatment", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Treatment", "ChangedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Treatment", "ChangedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Treatment", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
