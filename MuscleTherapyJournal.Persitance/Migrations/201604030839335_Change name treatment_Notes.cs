namespace MuscleTherapyJournal.Persitance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changenametreatment_Notes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Treatment", "TreatmentNotes", c => c.String());
            DropColumn("dbo.Treatment", "Treatment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Treatment", "Treatment", c => c.String());
            DropColumn("dbo.Treatment", "TreatmentNotes");
        }
    }
}
