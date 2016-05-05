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
        private readonly IAreaAfflicationService _areaAfflicationService;
        private readonly ILog _logger = LogManager.GetLogger(typeof(TreatmentController));

        public TreatmentController(ITreatmentFactory treatmentFactory, 
            ITreatmentService treatmentService, 
            ICustomerService customerService,
            IAreaAfflicationService areaAfflicationService)
        {
            if (treatmentFactory == null) throw new ArgumentNullException("treatmentFactory");
            if (treatmentService == null) throw new ArgumentNullException("treatmentService");
            if (customerService == null) throw new ArgumentNullException("customerService");
            if (areaAfflicationService == null) throw new ArgumentNullException("areaAfflicationService");

            _treatmentFactory = treatmentFactory;
            _treatmentService = treatmentService;
            _customerService = customerService;
            _areaAfflicationService = areaAfflicationService;
        }

        [HttpGet]
        [Route("Behandling/{treatmentId}{customerId}")]
        public ActionResult Treatment(int treatmentId = 0, int customerId = 0)
        {
            _logger.DebugFormat("Enter TreatmentController with behandingId: {0}", treatmentId);
            var model = new TreatmentViewModel();

            var currentCustomerId = customerId;

            if (treatmentId > 0)
            {
                var treatment = _treatmentService.GetTreatmentById(treatmentId);
                treatment.Customer = _customerService.GetCustomer(treatment.CustomerId);

                if (currentCustomerId <= 0)
                {
                    currentCustomerId = treatment.CustomerId;
                }
                //var oldAfflicaitons = _customerService.GetOldAfflicationsByCustomerId(treatment.CustomerId);
                var oldAfflicaitons = _areaAfflicationService.GetAfflicationAreasByCustomerId(treatment.CustomerId);
                oldAfflicaitons.RemoveAll(x => x.TreatmentId == treatmentId);
                foreach (var oldAfflicaiton in oldAfflicaitons)
                {
                    oldAfflicaiton.IsPersisted = true;
                }

                model = new TreatmentViewModel
                {
                    Treatment = treatment,
                    OldAfflications = oldAfflicaitons,
                    CreatedDate = DateTime.Now.ToString("dd.MM.yyyy")
                };
                if (oldAfflicaitons.Any())
                {
                    model.HasOldAfflications = true;
                }
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
                    model.Treatment.CustomerId = model.Treatment.Customer.CustomerId;
                    
                    //var oldAfflicaitons = _customerService.GetOldAfflicationsByCustomerId(customerId);
                    var oldAfflicaitons = _areaAfflicationService.GetAfflicationAreasByCustomerId(customerId);

                    
                    foreach (var oldAfflicaiton in oldAfflicaitons)
                    {
                        oldAfflicaiton.IsPersisted = true;
                    }

                    model.OldAfflications = oldAfflicaitons;

                    if (oldAfflicaitons.Any())
                    {
                        model.HasOldAfflications = true;
                    }
                }
            }

            var today = DateTime.Today;
            var age = today.Year - model.Treatment.Customer.BirthDay.GetValueOrDefault().Year;
            if (model.Treatment.Customer.BirthDay.GetValueOrDefault() > today.AddYears(-age))
            {
                age--;
            }
            model.Treatment.Customer.Age = age;

            var oldNotes = _treatmentService.GetOldTreatmentNotesByCustomerId(currentCustomerId, treatmentId);
            if (oldNotes != null)
            {
                model.Treatment.OldTreatmentNotes = oldNotes.OldNotes;
                model.Treatment.OldObservations = oldNotes.OldObservations;
                model.Treatment.OldAnamnesis = oldNotes.OldAnamnese;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Treatment(TreatmentViewModel model)
        {
            return View(model);
        }

    }
}