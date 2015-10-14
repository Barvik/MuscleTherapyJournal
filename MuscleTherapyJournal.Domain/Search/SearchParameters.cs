using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuscleTherapyJournal.Domain.Search
{
    public class SearchParameters
    {

        [DisplayName("Navn")]
        public string CustomerName { get; set; }

        [DisplayName("Mobilnummer")]
        public string PhoneNumber { get; set; }

        [DisplayName("Kundenummer")]
        public string CustomerNumber { get; set; }

        [DisplayName("Fra dato")]
        public string TreatmentFromDate { get; set; }

        [DisplayName("Til dato")]
        public string TreatmentToDate { get; set; }

        [DisplayName("Yrke")]
        public string Profession { get; set; }

        public int SearchType { get; set; }

        public SearchParameters()
        {
            SearchType = 0;
        }

        public override string ToString()
        {
            return
                string.Format(
                    "CustomerName: {0}; PhoneNumber: {1}; CustomerNumber: {2}; TreatmentFromDate: {3};, TreatmentToDate: {4};" +
                    "Profession: {5}; SearchType: {6};", CustomerName, PhoneNumber, CustomerNumber, TreatmentFromDate, TreatmentToDate,
                    Profession, SearchType);
        }
    }
}
