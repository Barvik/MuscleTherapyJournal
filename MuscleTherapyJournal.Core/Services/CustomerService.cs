using System;
using System.Collections.Generic;
using AutoMapper;
using log4net;
using MuscleTherapyJournal.Core.Services.Interfaces;
using MuscleTherapyJournal.Domain.Model;
using MuscleTherapyJournal.Persitance.DAO.Interfaces;
using MuscleTherapyJournal.Persitance.Entity;

namespace MuscleTherapyJournal.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMappingEngine _mappingEngine;
        private readonly ICustomerDAO _customerDao;
        private readonly ILog _logger = LogManager.GetLogger(typeof (CustomerService));

        public CustomerService(IMappingEngine mappingEngine, ICustomerDAO customerDao)
        {
            if (mappingEngine == null) throw new ArgumentNullException("mappingEngine");
            if (customerDao == null) throw new ArgumentNullException("customerDao");

            _mappingEngine = mappingEngine;
            _customerDao = customerDao;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _logger.DebugFormat("Recieved UpdateCustomer with customer: {0}", customer);

            if (customer == null)
            {
                _logger.Error("Customer cannot be null");
                throw new ArgumentNullException("customer");
            }

            customer.CustomerName = BuildFullName(customer);

            var customerRequest = _mappingEngine.Map<CustomerEntity>(customer);

            if (customer.CustomerId > 0)
            {
                return UpdateExistingCustomer(customerRequest);
            }

            return UpdateNewCustomer(customerRequest);
        }

        

        public Customer GetCustomer(int customerId)
        {
            _logger.DebugFormat("Recieved GetCustomer with customerId: {0}", customerId);

            try
            {
                var result = _customerDao.GetCustomerByCustomerId(customerId);
                return _mappingEngine.Map<Customer>(result);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when calling GetCustomer: {0}", ex);
            }

            return null;
        }

        public List<Customer> GetAllCustomers()
        {
            _logger.DebugFormat("Recieved GetAllCustomers");

            try
            {
                var result = _customerDao.GetAllCustomers();
                return _mappingEngine.Map<List<Customer>>(result);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when calling GetAllCustomers: {0}", ex);
            }
            return new List<Customer>();
        }

        #region "Private_Methods"

        private string BuildFullName(Customer customer)
        {
            var customerName = customer.FirstName;

            if (!string.IsNullOrWhiteSpace(customer.Surname))
            {
                customerName += " " + customer.Surname;
            }

            if (!string.IsNullOrWhiteSpace(customer.LastName))
            {
                customerName += " " + customer.LastName;
            }

            return customerName;
        }

        private bool UpdateExistingCustomer(CustomerEntity customer)
        {
            try
            {
                _customerDao.UpdateExistingCustomer(customer);
                return true;
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when updating existing customer: {0}", ex);
                return false;
            }
        }

        private bool UpdateNewCustomer(CustomerEntity customer)
        {
            try
            {
                _customerDao.UpdateNewCustomer(customer);
                return true;
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when creating new existing customer: {0}", ex);
                return false;
            }
        }

        #endregion
    }
}
