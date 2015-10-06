namespace MuscleTherapyJournal.Persitance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetreatment : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customer", newName: "Treatment");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Treatment", newName: "Customer");
        }
    }
}
