namespace MuscleTherapyJournal.Persitance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addtreatment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TreatmentEntity",
                c => new
                    {
                        TreatmentId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ChangedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Anamnesis = c.String(),
                        Observations = c.String(),
                    })
                .PrimaryKey(t => t.TreatmentId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TreatmentEntity", "UserId", "dbo.User");
            DropForeignKey("dbo.TreatmentEntity", "CustomerId", "dbo.Customer");
            DropIndex("dbo.TreatmentEntity", new[] { "UserId" });
            DropIndex("dbo.TreatmentEntity", new[] { "CustomerId" });
            DropTable("dbo.TreatmentEntity");
        }
    }
}
