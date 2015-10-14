using System;
using System.Collections.Generic;
using AutoMapper;
using log4net;
using MuscleTherapyJournal.Core.Services.Interfaces;
using MuscleTherapyJournal.Domain.Model;
using MuscleTherapyJournal.Domain.Search;
using MuscleTherapyJournal.Persitance.DAO.Interfaces;
using MuscleTherapyJournal.Persitance.Entity;

namespace MuscleTherapyJournal.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMappingEngine _mappingEngine;
        private readonly ICustomerRepository _customerRepository;
        private readonly ILog _logger = LogManager.GetLogger(typeof (CustomerService));

        public CustomerService(IMappingEngine mappingEngine, ICustomerRepository customerRepository)
        {
            if (mappingEngine == null) throw new ArgumentNullException("mappingEngine");
            if (customerRepository == null) throw new ArgumentNullException("customerRepository");

            _mappingEngine = mappingEngine;
            _customerRepository = customerRepository;
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
                var result = _customerRepository.GetCustomerByCustomerId(customerId);
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
                var result = _customerRepository.GetAllCustomers();
                return _mappingEngine.Map<List<Customer>>(result);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when calling GetAllCustomers: {0}", ex);
            }
            return new List<Customer>();
        }

        public List<Customer> GetCustomersBySearchCriteria(SearchParameters searchParameters)
        {
            _logger.DebugFormat("Recieved GetCustomersBySearchCriteria with searchCritera: {0}", searchParameters);

            try
            {
                var result = _customerRepository.GetCustomerBySearchParameters(searchParameters);
                return _mappingEngine.Map<List<Customer>>(result);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when calling GetCustomersBySearchCriteria: {0}", ex);
            }
            return null;
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
                _customerRepository.UpdateExistingCustomer(customer);
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
                _customerRepository.UpdateNewCustomer(customer);
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
