namespace MuscleTherapyJournal.Persitance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Treatment", newName: "__mig_tmp__0");
            RenameTable(name: "dbo.TreatmentEntity", newName: "Treatment");
            RenameTable(name: "__mig_tmp__0", newName: "Customer");
        }
        
        public override void Down()
        {
            RenameTable(name: "Customer", newName: "__mig_tmp__0");
            RenameTable(name: "dbo.Treatment", newName: "TreatmentEntity");
            RenameTable(name: "dbo.__mig_tmp__0", newName: "Treatment");
        }
    }
}
