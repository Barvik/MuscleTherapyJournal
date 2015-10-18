using System;
using System.Collections.Generic;
using AutoMapper;
using log4net;
using MuscleTherapyJournal.Core.Services.Interfaces;
using MuscleTherapyJournal.Core.Utility;
using MuscleTherapyJournal.Domain.Model;
using MuscleTherapyJournal.Domain.Search;
using MuscleTherapyJournal.Persitance.DAO.Interfaces;
using MuscleTherapyJournal.Persitance.Entity;

namespace MuscleTherapyJournal.Core.Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IAreaAfflicationRepository _areaAfflicationDto;
        private readonly IMappingEngine _mappingEngine;
        private readonly ILog _logger = LogManager.GetLogger(typeof (TreatmentService));

        public TreatmentService(ITreatmentRepository treatmentRepository, 
            IAreaAfflicationRepository areaAfflicationDto,
            IMappingEngine mappingEngine)
        {
            if (treatmentRepository == null) throw new ArgumentNullException("treatmentRepository");
            if (areaAfflicationDto == null) throw new ArgumentNullException("areaAfflicationDto");
            if (mappingEngine == null) throw new ArgumentNullException("mappingEngine");

            _treatmentRepository = treatmentRepository;
            _areaAfflicationDto = areaAfflicationDto;
            _mappingEngine = mappingEngine;
        }

        public bool SaveTreatment(Treatment treatment)
        {
            _logger.DebugFormat("Entering SaveTreatment with treatMent: {0}", treatment);

            try
            {
                var request = _mappingEngine.Map<TreatmentEntity>(treatment);
                _treatmentRepository.CreateTreatment(request);
                return true;
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when creating treatment: {0}", ex);
                return false;
            }
        }

        public Treatment GetTreatmentById(int treatmentId)
        {
            _logger.DebugFormat("Entering SaveTreatment with treatMent: {0}", treatmentId);

            var areaAfflications = new List<AfflictionArea>();
            var oldAreaAfflications = new List<OldAfflications>();
            Treatment result = null;

            try
            {
                var afflications = _areaAfflicationDto.GetAfflicationAreas(treatmentId);
                areaAfflications = _mappingEngine.Map<List<AfflictionArea>>(afflications);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when retrieving afflication for treatmentId: {0} with exception: {1}", treatmentId, ex);
            }

            try
            {
                var treatment = _treatmentRepository.GetTreatment(treatmentId);
                result = _mappingEngine.Map<Treatment>(treatment);
                result.AfflictionAreas = areaAfflications;
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when retrieving treatmentId: {0} with exception: {1}", treatmentId, ex);
                return null;
            }

            
            return result;

        }

        

        public List<TreatmentCustomer> GetTreatmentsBySearchCriteria(SearchParameters searchParameters)
        {
            _logger.DebugFormat("Recieved GetTreatmentsBySearchCriteria with searchCritera: {0}", searchParameters);

            var fromDate = DateTimeParser.ParseDateTimeFromDateToString(searchParameters.TreatmentFromDate);
            var toDate = DateTimeParser.ParseDateTimeToDateToString(searchParameters.TreatmentToDate);

            try
            {
                var result = _treatmentRepository.GetTreatmentsBySearchCriteria(searchParameters, fromDate, toDate);
                return _mappingEngine.Map<List<TreatmentCustomer>>(result);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when calling GetTreatmentsBySearchCriteria: {0}", ex);
                
            }
            return null;
        }
    }
}
