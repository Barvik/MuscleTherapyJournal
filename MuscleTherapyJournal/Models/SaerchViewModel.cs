using MuscleTherapyJournal.Domain.Model;
using MuscleTherapyJournal.Domain.Search;
using PagedList;

namespace MuscleTherapyJournal.Models
{
    public class SearchViewModel
    {
        public SearchCriteria SearchCriteria { get; set; }

        public PagedList<Customer> ResultCustomerSearch { get; set; }
        public PagedList<Treatment> ResultTreatmetSearch { get; set; }
        public int SearchType { get; set; }
    }
}