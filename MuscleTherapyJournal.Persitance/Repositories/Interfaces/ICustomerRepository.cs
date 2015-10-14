using System.Collections.Generic;
using MuscleTherapyJournal.Domain.Search;
using MuscleTherapyJournal.Persitance.Entity;

namespace MuscleTherapyJournal.Persitance.DAO.Interfaces
{
    public interface ICustomerRepository
    {
        void UpdateExistingCustomer(CustomerEntity customer);
        void UpdateNewCustomer(CustomerEntity customer);
        CustomerEntity GetCustomerByCustomerId(int customerId);
        List<CustomerEntity> GetAllCustomers();
        List<CustomerEntity> GetCustomerBySearchParameters(SearchParameters searchParameters);
    }
}
