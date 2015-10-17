using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using MuscleTherapyJournal.Core.Factories.Interfaces;
using MuscleTherapyJournal.Core.Services.Interfaces;
using MuscleTherapyJournal.Domain.Model;
using MuscleTherapyJournal.Models;

namespace MuscleTherapyJournal.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerFactory _customerFactory;

        private readonly ILog _logger = LogManager.GetLogger(typeof (CustomerController));

        public CustomerController(ICustomerService customerService, ICustomerFactory customerFactory)
        {
            if (customerService == null) throw new ArgumentNullException("customerService");
            if (customerFactory == null) throw new ArgumentNullException("customerFactory");

            _customerService = customerService;
            _customerFactory = customerFactory;
        }

        [HttpGet]
        public ActionResult UpdateCustomer(int customerId = 0)
        {
            _logger.DebugFormat("Entering UpdateCustomer with customerId: {0}", customerId);
            var model = new CustomerViewModel();
            model.IsPostBack = false;

            if (customerId > 0)
            {
                _logger.InfoFormat("Existing customer with customerId: {0}", customerId);
                var existingCustomer = _customerService.GetCustomer(customerId);

                if (existingCustomer == null)
                {
                    throw new ArgumentNullException("existingCustomer");
                }

                model.BirthDay = existingCustomer.BirthDay.GetValueOrDefault().ToString("dd.MM.yyyy");

                model.Customer = existingCustomer;
                return View(model);
            }

            model.Customer = _customerFactory.BuildNewCustomer();
            
            return View(model);
            
        }

        [HttpPost]
        public ActionResult UpdateCustomer(CustomerViewModel model)
        {
            _logger.DebugFormat("UpdateCustomer POST called");
            model.IsPostBack = true;

            DateTime birthdate;
            var dateParesed = DateTime.TryParse(model.BirthDay, out birthdate);

            model.Customer.BirthDay = null;

            if (dateParesed)
            {
                model.Customer.BirthDay = DateTime.Parse(model.BirthDay);
            }

            if (model.Customer.CustomerId == 0)
            {
                model.Customer.CreatedDate = DateTime.Now;
            }
            model.UpdateCustomerSuccess = _customerService.UpdateCustomer(model.Customer);


            return View(model);
        }
    }
}