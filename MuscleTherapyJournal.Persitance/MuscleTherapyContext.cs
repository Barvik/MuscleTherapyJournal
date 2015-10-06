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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>().ToTable("User");
            modelBuilder.Entity<CustomerEntity>().ToTable("Customer");
            modelBuilder.Entity<TreatmentEntity>().ToTable("Treatment");
        }


        public MuscleTherapyContext()
            : base("MuscleTherapy")
        {

        }
    }
}
