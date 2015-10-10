using System.Collections.Generic;
using MuscleTherapyJournal.Persitance.Entity;

namespace MuscleTherapyJournal.Persitance.DAO.Interfaces
{
    public interface ICustomerDAO
    {
        void UpdateExistingCustomer(CustomerEntity customer);
        void UpdateNewCustomer(CustomerEntity customer);
        CustomerEntity GetCustomerByCustomerId(int customerId);
        List<CustomerEntity> GetAllCustomers();
    }
}
