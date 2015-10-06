using System;
using System.Collections.Generic;

namespace MuscleTherapyJournal.Domain.Model
{
    public class Treatment
    {
        public int TreatmentId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public int UserId { get; set; }
        public string Anamnesis { get; set; }
        public string Observations { get; set; }
        public Customer Customer { get; set; }
        public User User { get; set; }
        public List<AfflictionArea> AfflictionAreas { get; set; } 
    }
}
