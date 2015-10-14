using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using MuscleTherapyJournal.Core.Factories.Interfaces;
using MuscleTherapyJournal.Core.Services.Interfaces;
using MuscleTherapyJournal.Models;

namespace MuscleTherapyJournal.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly ITreatmentFactory _treatmentFactory;
        private readonly ITreatmentService _treatmentService;
        private readonly ICustomerService _customerService;
        private readonly ILog _logger = LogManager.GetLogger(typeof(TreatmentController));

        public TreatmentController(ITreatmentFactory treatmentFactory, ITreatmentService treatmentService, ICustomerService customerService)
        {
            if (treatmentFactory == null) throw new ArgumentNullException("treatmentFactory");
            if (treatmentService == null) throw new ArgumentNullException("treatmentService");
            if (customerService == null) throw new ArgumentNullException("customerService");

            _treatmentFactory = treatmentFactory;
            _treatmentService = treatmentService;
            _customerService = customerService;
        }

        [HttpGet]
        [Route("Behandling/{treatmentId}{customerId}")]
        public ActionResult Treatment(int treatmentId = 0, int customerId = 0)
        {
            _logger.DebugFormat("Enter TreatmentController with behandingId: {0}", treatmentId);
            var model = new TreatmentViewModel();

            if (treatmentId > 0)
            {
                var treatment = _treatmentService.GetTreatmentById(treatmentId);
                treatment.Customer = _customerService.GetCustomer(treatment.CustomerId);
                model = new TreatmentViewModel
                {
                    Treatment = treatment
                };
                model.CreatedDate = DateTime.Now.ToString("dd.MM.yyyy");
                
            }
            else
            {
                model = new TreatmentViewModel
                {
                    Treatment = _treatmentFactory.BuildNewTreatmentModel(),
                };

                if (customerId > 0)
                {
                    model.Treatment.Customer = _customerService.GetCustomer(customerId);
                }
            }

            var today = DateTime.Today;
            var age = today.Year - model.Treatment.Customer.BirthDay.GetValueOrDefault().Year;
            if (model.Treatment.Customer.BirthDay.GetValueOrDefault() > today.AddYears(-age))
            {
                age--;
            }
            model.Treatment.Customer.Age = age;
            

            return View(model);
        }

        [HttpPost]
        public ActionResult Treatment(TreatmentViewModel model)
        {
            return View(model);
        }

    }
}