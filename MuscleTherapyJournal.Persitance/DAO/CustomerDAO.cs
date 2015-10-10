using System.Collections.Generic;
using System.Linq;
using log4net;
using MuscleTherapyJournal.Persitance.DAO.Interfaces;
using MuscleTherapyJournal.Persitance.Entity;

namespace MuscleTherapyJournal.Persitance.DAO
{
    public class CustomerDAO : ICustomerDAO
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof (CustomerDAO));

        public void UpdateExistingCustomer(CustomerEntity customer)
        {
            _logger.DebugFormat("Updating Existing customer with customerId: {0}", customer.CustomerId);

            using (var db = new MuscleTherapyContext())
            {
                db.Customers.Attach(customer);
                db.SaveChanges();
            }
        }

        public void UpdateNewCustomer(CustomerEntity customer)
        {
            _logger.DebugFormat("Updating new customer");
            using (var db = new MuscleTherapyContext())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }

        public CustomerEntity GetCustomerByCustomerId(int customerId)
        {
            _logger.DebugFormat("GetCustomerByCustomerId");
            using (var db = new MuscleTherapyContext())
            {
                return db.Customers.Find(customerId);
            }
        }

        public List<CustomerEntity> GetAllCustomers()
        {
            _logger.DebugFormat("GetAllCustomers");
            using (var db = new MuscleTherapyContext())
            {
                return db.Customers.ToList();
            }
        }
    }
}
