using System.Collections.Generic;
using System.Linq;
using log4net;
using MuscleTherapyJournal.Persitance.DAO.Interfaces;
using MuscleTherapyJournal.Persitance.Entity;

namespace MuscleTherapyJournal.Persitance.DAO
{
    public class AreaAfflicationRepository : IAreaAfflicationRepository
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TreatmentRepository));

        public List<AfflictionAreaEntity> GetAfflicationAreas(int treatmentId)
        {
            _logger.Debug("GetAfflicationAreas");

            using (var db = new MuscleTherapyContext())
            {
                var result = from AfflictionAreaEntity aae in db.AfflictionAreas
                    where (aae.TreatmentId == treatmentId)
                    select aae;

                return result.ToList();
            }   
        }

        public List<AfflictionAreaEntity> GetAfflicationAreasByCustomerId(int customerId)
        {
            _logger.Debug("GetAfflicationAreas by customerId");

            using (var db = new MuscleTherapyContext())
            {
                var result = from AfflictionAreaEntity aae in db.AfflictionAreas
                             where (aae.CustomerId == customerId)
                             select aae;

                return result.ToList();
            } 
        }
    }
}
