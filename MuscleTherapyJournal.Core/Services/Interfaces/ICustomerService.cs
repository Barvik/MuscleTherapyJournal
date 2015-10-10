using System.Collections.Generic;
using MuscleTherapyJournal.Domain.Model;

namespace MuscleTherapyJournal.Core.Services.Interfaces
{
    public interface ICustomerService
    {
        bool UpdateCustomer(Customer customer);
        Customer GetCustomer(int customerId);
        List<Customer> GetAllCustomers();
    }
}
