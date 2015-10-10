namespace MuscleTherapyJournal.Persitance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeVarCharMaxToVarChar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "Surname", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Customer", "LastName", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Customer", "CustomerName", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Customer", "MobilePhoneNumber", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Customer", "Address", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Customer", "ZipCode", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Customer", "LivingLocation", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Customer", "Email", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Customer", "Profession", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.User", "FirstName", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.User", "LastName", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.User", "Email", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.User", "MobilePhoneNumber", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.User", "UserName", c => c.String(maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "UserName", c => c.String());
            AlterColumn("dbo.User", "MobilePhoneNumber", c => c.String());
            AlterColumn("dbo.User", "Email", c => c.String());
            AlterColumn("dbo.User", "LastName", c => c.String());
            AlterColumn("dbo.User", "FirstName", c => c.String());
            AlterColumn("dbo.Customer", "Profession", c => c.String());
            AlterColumn("dbo.Customer", "Email", c => c.String());
            AlterColumn("dbo.Customer", "LivingLocation", c => c.String());
            AlterColumn("dbo.Customer", "ZipCode", c => c.String());
            AlterColumn("dbo.Customer", "Address", c => c.String());
            AlterColumn("dbo.Customer", "MobilePhoneNumber", c => c.String());
            AlterColumn("dbo.Customer", "CustomerName", c => c.String());
            AlterColumn("dbo.Customer", "LastName", c => c.String());
            AlterColumn("dbo.Customer", "Surname", c => c.String());
        }
    }
}
