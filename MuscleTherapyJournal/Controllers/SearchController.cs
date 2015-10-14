using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using log4net;
using MuscleTherapyJournal.Core.Services.Interfaces;
using MuscleTherapyJournal.Domain.Enum;
using MuscleTherapyJournal.Domain.Model;
using MuscleTherapyJournal.Domain.Search;
using MuscleTherapyJournal.Models;
using PagedList;

namespace MuscleTherapyJournal.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ITreatmentService _treatmentService;

        private readonly ILog _logger = LogManager.GetLogger(typeof (SearchController));

        public SearchController(ICustomerService customerService, ITreatmentService treatmentService)
        {
            if (customerService == null) throw new ArgumentNullException("customerService");
            if (treatmentService == null) throw new ArgumentNullException("treatmentService");

            _customerService = customerService;
            _treatmentService = treatmentService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            _logger.DebugFormat("Saerch GET Index");
            var model = new SearchViewModel
            {
                SearchParameters = new SearchParameters()
            };
            model.SearchParameters.SearchType = (int) SearchType.CustomerSearch;

            return View("Search", model);
        }

         

        [HttpGet]
        public ActionResult SearchResult(SearchViewModel model,
            int page = 1, int pagesize = 10, bool changedPage = false, int pageSearchType = 0, string customerName = null, string phoneNumber = null,
            string customerNumber = null, string treatmentFromDate = null, string treatmentToDate = null, string profession = null)
        {
            _logger.DebugFormat("Search GET SearchResult  with page: {0}, pageSize: {1}, changedPage: {2}, customerName: {3}," +
                                " phoneNumber: {4}, customerNumber: {5}, treatmentFromDate:{6}, treatmentToDate: {7}, profession: {8}", 
                                page, pagesize, changedPage, customerName, phoneNumber, customerNumber, 
                                treatmentFromDate, treatmentToDate, profession);

            if (changedPage && model.SearchParameters == null)
            {
                model.SearchParameters = new SearchParameters
                {
                    CustomerName = customerName,
                    CustomerNumber = customerNumber,
                    PhoneNumber = phoneNumber,
                    Profession = profession,
                    TreatmentFromDate = treatmentFromDate,
                    TreatmentToDate = treatmentToDate,
                    SearchType = pageSearchType
                };
            }

            if (model.SearchParameters == null)
            {
                _logger.ErrorFormat("SearchViewModel is null");
                throw new ArgumentNullException("parameters");
            }

            switch (model.SearchParameters.SearchType)
            {
                case (int) SearchType.CustomerSearch:
                    _logger.Info("Performing Customer Search");
                    model.ResultCustomerSearch = PerformCustomerSearch(model.SearchParameters, page, pagesize);
                    break;

                case (int) SearchType.TreatmentSearch:
                    _logger.Info("Performing Treatmetn Search");
                    model.ResultTreatmentSearch = PerformTreatmentSearch(model.SearchParameters, page, pagesize);
                    break;
            }

            return View("Search", model);
        }

        private PagedList<Customer> PerformCustomerSearchPageChange(SearchViewModel model, int page, int pagesize)
        {
            var customerList = model.ResultCustomerSearch.ToList();
            return new PagedList<Customer>(customerList, page, pagesize);
        }

        private PagedList<TreatmentCustomer> PerformTreatmentSearch(SearchParameters searchParameters, int page, int pageSize)
        {
            var treatments = _treatmentService.GetTreatmentsBySearchCriteria(searchParameters);
            return new PagedList<TreatmentCustomer>(treatments, page, pageSize);
        }

        private PagedList<Customer> PerformCustomerSearch(SearchParameters searchParameters, int page, int pageSize)
        {
            var customers = _customerService.GetCustomersBySearchCriteria(searchParameters);
            return new PagedList<Customer>(customers, page, pageSize);
        }
    }
}