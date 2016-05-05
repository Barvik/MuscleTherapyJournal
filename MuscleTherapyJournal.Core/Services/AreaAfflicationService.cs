using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using log4net;
using MuscleTherapyJournal.Core.Services.Interfaces;
using MuscleTherapyJournal.Domain.Model;
using MuscleTherapyJournal.Persitance.DAO.Interfaces;
using MuscleTherapyJournal.Persitance.Entity;

namespace MuscleTherapyJournal.Core.Services
{
    public class AreaAfflicationService : IAreaAfflicationService
    {
        private readonly IAreaAfflicationRepository _areaAfflicationRepository;
        private readonly IMappingEngine _mappingEngine;
        private readonly ILog _logger = LogManager.GetLogger(typeof(AreaAfflicationService));

        public AreaAfflicationService(IAreaAfflicationRepository areaAfflicationRepository, IMappingEngine mappingEngine)
        {
            if (areaAfflicationRepository == null) throw new ArgumentNullException("areaAfflicationRepository");
            if (mappingEngine == null) throw new ArgumentNullException("mappingEngine");

            _areaAfflicationRepository = areaAfflicationRepository;
            _mappingEngine = mappingEngine;
        }

        public List<AfflictionArea> GetAfflicationAreasByTreatmentId(int treatmendId)
        {
            try
            {
                var afflicationArea = _areaAfflicationRepository.GetAfflicationAreas(treatmendId);
                return _mappingEngine.Map<List<AfflictionArea>>(afflicationArea);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when calling GetAfflicationAreasByCustomerId for TreatmentId: {0} and Exception: {1}", treatmendId, ex);
            }
            return null;
        }

        public List<AfflictionArea> GetAfflicationAreasByCustomerId(int customerId)
        {
            try
            {
                var afflicationArea = _areaAfflicationRepository.GetAfflicationAreasByCustomerId(customerId);
                return _mappingEngine.Map<List<AfflictionArea>>(afflicationArea);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when calling GetAfflicationAreasByCustomerId for CustomerId: {0} and Exception: {1}", customerId, ex);
            }
            return null;
        }

        public bool DeleteAfflications(List<AfflictionArea> deleteAfflication)
        {
            _logger.Debug("Entering deleteAfflications");
            if (deleteAfflication == null || !deleteAfflication.Any())
            {
                return true;
            }

            var distictAfflicationList = deleteAfflication.Distinct().ToList();
            distictAfflicationList.RemoveAll(x => x.AfflictionAreaId == 0);

            if (!distictAfflicationList.Any())
            {
                _logger.Debug("No more elements present after filtering allicationAreas");
                return true;
            }

            try
            {
                var request = _mappingEngine.Map<List<AfflictionAreaEntity>>(distictAfflicationList);
                return _areaAfflicationRepository.DeleteAfflictions(request);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when calling DeleteAfflicaitons");
                return false;
            }


            return false;
        }
    }
}
