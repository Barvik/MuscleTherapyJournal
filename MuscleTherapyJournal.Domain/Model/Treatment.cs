using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuscleTherapyJournal.Domain.Model
{
    public class Treatment
    {
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public int TreatmentId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ChangedDate { get; set; }
        public int UserId { get; set; }
        [DisplayName("Behandling:")]
        public string TreatmentNotes { get; set; }
        [DisplayName("Anamnese:")]
        public string Anamnesis { get; set; }
        [DisplayName("Observasjoner:")]
        public string Observations { get; set; }
        public Customer Customer { get; set; }
        public User User { get; set; }

        [DisplayName("Bilde over smerteområde:")]
        public List<AfflictionArea> AfflictionAreas { get; set; }
        public List<OldAfflications> OldAfflications { get; set; }

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
