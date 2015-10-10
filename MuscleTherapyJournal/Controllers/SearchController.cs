using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MuscleTherapyJournal.Core.Services.Interfaces;
using MuscleTherapyJournal.Domain.Model;
using MuscleTherapyJournal.Models;
using PagedList;

namespace MuscleTherapyJournal.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ITreatmentService _treatmentService;

        public SearchController(ICustomerService customerService, ITreatmentService treatmentService)
        {
            if (customerService == null) throw new ArgumentNullException("customerService");
            if (treatmentService == null) throw new ArgumentNullException("treatmentService");

            _customerService = customerService;
            _treatmentService = treatmentService;
        }

        [HttpGet]
        public ActionResult Index(int searchType = 1)
        {
            var model = new SearchViewModel();

            return View("Search", model);
        }

        [HttpGet]
        public ActionResult SearchResult(SearchViewModel model, int page = 1, int pagesize = 10)
        {

            var customers = _customerService.GetAllCustomers();
            model.ResultCustomerSearch = new PagedList<Customer>(customers, page, pagesize);
            //model.ResultTreatmetSearch = new List<Treatment>{new Treatment(), new Treatment() };

            return View("Search", model);
        }
    }
}