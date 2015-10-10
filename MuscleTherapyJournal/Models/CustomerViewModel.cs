using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MuscleTherapyJournal.Domain.Model;

namespace MuscleTherapyJournal.Models
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        [DisplayName("Fødselsdato")]
        public string BirthDay { get; set; }
        public bool UpdateCustomerSuccess { get; set; }
        public bool IsPostBack { get; set; }
    }
}