using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MuscleTherapyJournal.Persitance.Entity
{
    public class CustomerEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string MobilePhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string LivingLocation { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<TreatmentEntity> Treatments { get; set; } 
    }
}
