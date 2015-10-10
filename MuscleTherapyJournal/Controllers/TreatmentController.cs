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
        private readonly ILog _logger = LogManager.GetLogger(typeof(TreatmentController));

        public TreatmentController(ITreatmentFactory treatmentFactory, ITreatmentService treatmentService)
        {
            if (treatmentFactory == null) throw new ArgumentNullException("treatmentFactory");
            if (treatmentService == null) throw new ArgumentNullException("treatmentService");

            _treatmentFactory = treatmentFactory;
            _treatmentService = treatmentService;
        }

        [HttpGet]
        [Route("Behandling/{behandlingId}{customerId}")]
        public ActionResult Treatment(int behandlingId = 0, string customerId = null)
        {
            _logger.DebugFormat("Enter TreatmentController with behandingId: {0}", behandlingId);
            var model = new TreatmentViewModel();

            if (behandlingId > 0)
            {
                var treatment = _treatmentService.GetTreatmentById(behandlingId);

                model = new TreatmentViewModel
                {
                    Treatment = treatment
                };
                model.CreatedDate = DateTime.Now.ToString("yyyy-MM-dd");


                return View(model);
            }

            model = new TreatmentViewModel
            {
                Treatment = _treatmentFactory.BuildNewTreatmentModel(),
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Treatment(TreatmentViewModel model)
        {
            return View(model);
        }

    }
}