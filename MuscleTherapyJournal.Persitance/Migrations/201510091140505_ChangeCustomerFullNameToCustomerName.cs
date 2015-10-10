namespace MuscleTherapyJournal.Persitance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomerFullNameToCustomerName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "CustomerName", c => c.String());
            DropColumn("dbo.Customer", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "FullName", c => c.String());
            DropColumn("dbo.Customer", "CustomerName");
        }
    }
}
