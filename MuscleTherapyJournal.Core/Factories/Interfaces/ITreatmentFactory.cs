using MuscleTherapyJournal.Domain.Model;

namespace MuscleTherapyJournal.Core.Factories.Interfaces
{
    public interface ITreatmentFactory
    {
        Treatment BuildTreatmentModel();
        Treatment BuildNewTreatmentModel();
    }
}
