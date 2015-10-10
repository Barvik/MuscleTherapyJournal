namespace MuscleTherapyJournal.Persitance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetBirthDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "BirthDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "BirthDay", c => c.DateTime(nullable: false));
        }
    }
}
