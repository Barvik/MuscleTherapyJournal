using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuscleTherapyJournal.Persitance.Entity
{
    public class TreatmentEntity
    {
        [Key]
        public int TreatmentId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public int UserId { get; set; }
        public string Anamnesis { get; set; }
        public string Observations { get; set; }

        [ForeignKey("CustomerId")]
        public CustomerEntity Customer { get; set; }
        [ForeignKey("UserId")]
        public UserEntity User { get; set; }

        public ICollection<AfflictionAreaEntity> AfflictionAreas { get; set; } 
    }
}
