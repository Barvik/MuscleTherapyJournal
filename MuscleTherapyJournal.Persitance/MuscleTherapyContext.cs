using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MuscleTherapyJournal.Persitance.Entity;

namespace MuscleTherapyJournal.Persitance
{
    public class MuscleTherapyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<TreatmentEntity> Treatments { get; set; }
        public DbSet<AfflictionAreaEntity> AfflictionAreas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>().ToTable("User");
            modelBuilder.Entity<CustomerEntity>().ToTable("Customer");
            modelBuilder.Entity<TreatmentEntity>().ToTable("Treatment");
            modelBuilder.Entity<AfflictionAreaEntity>().ToTable("AfflictionArea");

            modelBuilder.Entity<AfflictionAreaEntity>()
                .HasRequired<TreatmentEntity>(x => x.Treatment)
                .WithMany(x => x.AfflictionAreas)
                .HasForeignKey(x => x.TreatmentId);

            modelBuilder.Entity<TreatmentEntity>()
                .HasMany<AfflictionAreaEntity>(x => x.AfflictionAreas)
                .WithRequired(x => x.Treatment)
                .HasForeignKey(x => x.TreatmentId);
        }

        public MuscleTherapyContext()
            : base("MuscleTherapy")
        {

        }
    }
}
