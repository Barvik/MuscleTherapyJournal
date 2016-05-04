using System;
using System.Collections.Generic;
using AutoMapper;
using log4net;
using MuscleTherapyJournal.Core.Services.Interfaces;
using MuscleTherapyJournal.Domain.Model;
using MuscleTherapyJournal.Persitance.DAO.Interfaces;

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
            throw new System.NotImplementedException();
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
    }
}
