﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public int SaveTreatment(Treatment treatment, bool newTreatment)
        {
            _logger.DebugFormat("Entering SaveTreatment with treatment: {0} and newTreatment: {1}", treatment, newTreatment);

            if (newTreatment)
            {
                return SaveNewTreatment(treatment);
            }

            return UpdateTreatment(treatment);
        }

        private int UpdateTreatment(Treatment treatment)
        {
            try
            {
                var request = _mappingEngine.Map<TreatmentEntity>(treatment);
                return _treatmentRepository.UpdateTreatment(request);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when updating treatment: {0}", ex);
                return 0;
            }
        }

        public int SaveNewTreatment(Treatment treatment)
        {
            try
            {
                var request = _mappingEngine.Map<TreatmentEntity>(treatment);
                return _treatmentRepository.CreateTreatment(request);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when creating treatment: {0}", ex);
                return 0;
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

        public OldTreatmentNotes GetOldTreatmentNotesByCustomerId(int customerId, int treatmentId)
        {
            var treatments = new List<Treatment>();
            var result = new OldTreatmentNotes();

            try
            {
                var unmappedTreatments = _treatmentRepository.GetTreatmentsByCustomerId(customerId);
                treatments = _mappingEngine.Map<List<Treatment>>(unmappedTreatments);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when calling GetTreatmentByCustomer with customerId: {0} and Exception: {1}", customerId, ex);
                return null;
            }

            if (!treatments.Any())
            {
                return null;
            }

            treatments.RemoveAll(x => x.TreatmentId == treatmentId);

            foreach (var treatment in treatments)
            {
                result.OldAnamnese += SetTextWithDate(treatment.CreatedDate.GetValueOrDefault(), treatment.Anamnesis);
                result.OldNotes += SetTextWithDate(treatment.CreatedDate.GetValueOrDefault(), treatment.TreatmentNotes);
                result.OldObservations += SetTextWithDate(treatment.CreatedDate.GetValueOrDefault(),
                    treatment.Observations);
            }

            return result;
        }

        private string SetTextWithDate(DateTime treatMentDate, string text)
        {
            var result = "";
            if (!string.IsNullOrWhiteSpace(text))
            {
                result = treatMentDate.ToString("dd.MM.yyyy");
                result += "\r\n";
                result += text;
                result += "\r\n\r\n";
            }
            return result;
        }
    }
}
