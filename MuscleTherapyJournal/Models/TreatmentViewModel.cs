using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MuscleTherapyJournal.Domain.Model;

namespace MuscleTherapyJournal.Models
{
    public class TreatmentViewModel
    {
        public Treatment Treatment { get; set; }
        public string AfflictionAreas { get; set; }
        [Column(TypeName = "date"), DataType(DataType.Date), 
        Display(Name = "Behandling dato")]
        public string CreatedDate { get; set; }
        public string FullAddress { get; set; }
        public List<OldAfflications> OldAfflications { get; set; }
        public bool HasOldAfflications { get; set; }
    }
}