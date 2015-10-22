using System;
using System.Collections.Generic;

namespace MuscleTherapyJournal.Domain.Model
{
    public class OldAfflications
    {
        public DateTime TreatmentDate { get; set; }
        public int TreatmentId { get; set; }
        public List<AfflictionArea> Afflications { get; set; } 
    }
}
