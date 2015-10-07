namespace MuscleTherapyJournal.Persitance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AfflictionAreaEntity", newName: "AfflictionArea");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AfflictionArea", newName: "AfflictionAreaEntity");
        }
    }
}
