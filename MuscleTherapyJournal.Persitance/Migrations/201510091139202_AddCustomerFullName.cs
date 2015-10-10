namespace MuscleTherapyJournal.Persitance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "FullName");
        }
    }
}
