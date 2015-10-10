using MuscleTherapyJournal.Core.Factories.Interfaces;
using MuscleTherapyJournal.Domain.Model;

namespace MuscleTherapyJournal.Core.Factories
{
    public class CustomerFactory : ICustomerFactory
    {
        public Customer BuildNewCustomer()
        {
            return new Customer();
        }
    }
}
