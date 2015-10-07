using System.Collections.Generic;
using MuscleTherapyJournal.Core.Factories.Interfaces;
using MuscleTherapyJournal.Domain.Model;

namespace MuscleTherapyJournal.Core.Factories
{
    public class TreatmentFactory : ITreatmentFactory
    {
        public Treatment BuildTreatmentModel()
        {
            throw new System.NotImplementedException();
        }

        public Treatment BuildNewTreatmentModel()
        {
            return new Treatment { AfflictionAreas = new List<AfflictionArea>() };
        }
    }
}
