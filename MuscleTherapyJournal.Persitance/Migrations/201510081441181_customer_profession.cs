namespace MuscleTherapyJournal.Persitance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer_profession : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Profession", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "Profession");
        }
    }
}
