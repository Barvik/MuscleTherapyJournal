using System;

namespace MuscleTherapyJournal.Domain.Model
{
    public class AfflictionArea
    {
        public int AfflictionAreaId { get; set; }
        public double MouseXPosition { get; set; }
        public double MouseYPosition { get; set; }
        public int CrossSize { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TreatmentId { get; set; }

    }
}
