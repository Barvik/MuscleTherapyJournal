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

        public override string ToString()
        {
            return
                string.Format(
                    "TreatmentId: [TreatmentId: {0}, CustomerId: {1}, CreatedDate: {2}, ChangedDate: {3}, UserId:{4}, " +
                    "Anamnesis: {5}, Observations: {6}, [Customer: {7}], [User: {8}], [AfflictionAreas: {9}]]",
                    TreatmentId,
                    CustomerId, CreatedDate, ChangedDate, UserId, Anamnesis, Observations, Customer.ToString(),
                    User.ToString(),
                    AfflictionAreas.ToString())
                ;
        }
    }
}
