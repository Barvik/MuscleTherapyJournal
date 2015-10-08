using System.Collections.Generic;
using log4net;
using MuscleTherapyJournal.Core.Services.Interfaces;
using MuscleTherapyJournal.Domain.Model;

namespace MuscleTherapyJournal.Core.Services
{
    public class AreaAfflicationService : IAreaAfflicationService
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(AreaAfflicationService));

        public AreaAfflicationService()
        {
            
        }

        public List<AfflictionArea> GetAfflicationAreasByTreatmentId(int treatmendId)
        {
            throw new System.NotImplementedException();
        }
    }
}
