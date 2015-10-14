using MuscleTherapyJournal.Domain.Model;
using MuscleTherapyJournal.Domain.Search;
using PagedList;

namespace MuscleTherapyJournal.Models
{
    public class SearchViewModel
    {
        public SearchParameters SearchParameters { get; set; }

        public PagedList<Customer> ResultCustomerSearch { get; set; }
        public PagedList<TreatmentCustomer> ResultTreatmentSearch { get; set; }

        public override string ToString()
        {
            return string.Format("SearchParameters: [{0}];", SearchParameters);
        }
    }
}