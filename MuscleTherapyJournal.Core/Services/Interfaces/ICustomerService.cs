using System.Collections.Generic;
using System.Linq;
using MuscleTherapyJournal.Domain.Model;
using MuscleTherapyJournal.Domain.Search;

namespace MuscleTherapyJournal.Core.Services.Interfaces
{
    public interface ICustomerService
    {
        bool UpdateCustomer(Customer customer);
        Customer GetCustomer(int customerId);
        List<Customer> GetAllCustomers();
        List<Customer> GetCustomersBySearchCriteria(SearchParameters searchParameters);
        List<OldAfflications> GetOldAfflicationsByCustomerId(int customerId);
    }
}
