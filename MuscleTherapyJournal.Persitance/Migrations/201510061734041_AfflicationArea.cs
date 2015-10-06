namespace MuscleTherapyJournal.Persitance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfflicationArea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AfflictionAreaEntity",
                c => new
                    {
                        AfflictionAreaId = c.Int(nullable: false, identity: true),
                        MouseXPosition = c.Double(nullable: false),
                        MouseYPosition = c.Double(nullable: false),
                        CrossSize = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        TreatmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AfflictionAreaId)
                .ForeignKey("dbo.Treatment", t => t.TreatmentId, cascadeDelete: true)
                .Index(t => t.TreatmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AfflictionAreaEntity", "TreatmentId", "dbo.Treatment");
            DropIndex("dbo.AfflictionAreaEntity", new[] { "TreatmentId" });
            DropTable("dbo.AfflictionAreaEntity");
        }
    }
}
