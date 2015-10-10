using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuscleTherapyJournal.Domain.Search
{
    public class SearchCriteria
    {

        [DisplayName("Navn")]
        public string CustomerName { get; set; }

        [DisplayName("Mobilnummer")]
        public string PhoneNumber { get; set; }
    }
}
