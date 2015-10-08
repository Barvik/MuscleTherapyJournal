using System;
using System.Collections.Generic;
using AutoMapper;
using log4net;
using MuscleTherapyJournal.Core.Services.Interfaces;
using MuscleTherapyJournal.Domain.Model;
using MuscleTherapyJournal.Persitance.DAO.Interfaces;
using MuscleTherapyJournal.Persitance.Entity;

namespace MuscleTherapyJournal.Core.Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentDAO _treatmentDao;
        private readonly IAreaAfflicationDAO _areaAfflicationDto;
        private readonly IMappingEngine _mappingEngine;
        private readonly ILog _logger = LogManager.GetLogger(typeof (TreatmentService));

        public TreatmentService(ITreatmentDAO treatmentDao, 
            IAreaAfflicationDAO areaAfflicationDto,
            IMappingEngine mappingEngine)
        {
            if (treatmentDao == null) throw new ArgumentNullException("treatmentDao");
            if (areaAfflicationDto == null) throw new ArgumentNullException("areaAfflicationDto");
            if (mappingEngine == null) throw new ArgumentNullException("mappingEngine");

            _treatmentDao = treatmentDao;
            _areaAfflicationDto = areaAfflicationDto;
            _mappingEngine = mappingEngine;
        }

        public bool SaveTreatment(Treatment treatment)
        {
            _logger.DebugFormat("Entering SaveTreatment with treatMent: {0}", treatment);

            try
            {
                var request = _mappingEngine.Map<TreatmentEntity>(treatment);
                _treatmentDao.CreateTreatment(request);
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
                var treatment = _treatmentDao.GetTreatment(treatmentId);
                var result = _mappingEngine.Map<Treatment>(treatment);
                result.AfflictionAreas = areaAfflications;
                return result;
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when retrieving treatmentId: {0} with exception: {1}", treatmentId, ex);
                return null;
            }
        }
    }
}
