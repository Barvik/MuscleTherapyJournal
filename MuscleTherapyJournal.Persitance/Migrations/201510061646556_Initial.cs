namespace MuscleTherapyJournal.Persitance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Surname = c.String(),
                        LastName = c.String(),
                        MobilePhoneNumber = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        Address = c.String(),
                        ZipCode = c.String(),
                        LivingLocation = c.String(),
                        Email = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        MobilePhoneNumber = c.String(),
                        MustChangePassword = c.Boolean(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Blocked = c.Boolean(nullable: false),
                        Activated = c.Boolean(nullable: false),
                        Password = c.String(),
                        Salt = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Customer");
        }
    }
}
