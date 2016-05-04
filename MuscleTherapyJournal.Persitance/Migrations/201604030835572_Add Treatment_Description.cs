namespace MuscleTherapyJournal.Persitance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTreatment_Description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Treatment", "Treatment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Treatment", "Treatment");
        }
    }
}
