using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuscleTherapyJournal.Persitance.Entity
{
    public class AfflictionAreaEntity
    {
        [Key]
        public int AfflictionAreaId { get; set; }
        public double MouseXPosition { get; set; }
        public double MouseYPosition { get; set; }
        public int CrossSize { get; set; }
        public DateTime CreatedDate { get; set; }

        public int CustomerId { get; set; }
        public int TreatmentId { get; set; }

        [ForeignKey("TreatmentId")]
        public TreatmentEntity Treatment { get; set; }
    }
}
