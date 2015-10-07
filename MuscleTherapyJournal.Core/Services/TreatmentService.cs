using System;
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
        private readonly IMappingEngine _mappingEngine;
        private readonly ILog _logger = LogManager.GetLogger(typeof (TreatmentService));

        public TreatmentService(ITreatmentDAO treatmentDao, IMappingEngine mappingEngine)
        {
            if (treatmentDao == null) throw new ArgumentNullException("treatmentDao");
            if (mappingEngine == null) throw new ArgumentNullException("mappingEngine");

            _treatmentDao = treatmentDao;
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

            try
            {
                var result = _treatmentDao.GetTreatment(treatmentId);
                return _mappingEngine.Map<Treatment>(result);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Exception when retrieving treatmentId: {0} with exception: {1}", treatmentId, ex);
                return null;
            }
        }
    }
}
