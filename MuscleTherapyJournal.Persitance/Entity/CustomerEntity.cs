using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuscleTherapyJournal.Persitance.Entity
{
    public class CustomerEntity
    {
        [Key]
        public int CustomerId { get; set; }
        [MaxLength(255), Column(TypeName = "VARCHAR")]
        public string FirstName { get; set; }
        [MaxLength(255), Column(TypeName = "VARCHAR")]
        public string Surname { get; set; }
        [MaxLength(255), Column(TypeName = "VARCHAR")]
        public string LastName { get; set; }
        [MaxLength(255), Column(TypeName = "VARCHAR")]
        public string CustomerName { get; set; }
        [MaxLength(255), Column(TypeName = "VARCHAR")]
        public string MobilePhoneNumber { get; set; }
        public DateTime? BirthDay { get; set; }
        [MaxLength(255), Column(TypeName = "VARCHAR")]
        public string Address { get; set; }
        [MaxLength(255), Column(TypeName = "VARCHAR")]
        public string ZipCode { get; set; }
        [MaxLength(255), Column(TypeName = "VARCHAR")]
        public string LivingLocation { get; set; }
        [MaxLength(255), Column(TypeName = "VARCHAR")]
        public string Email { get; set; }
        [MaxLength(255), Column(TypeName = "VARCHAR")]
        public string Profession { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<TreatmentEntity> Treatments { get; set; } 
    }
}
