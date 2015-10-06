using MuscleTherapyJournal.Domain.Model;

namespace MuscleTherapyJournal.Core.Services.Interfaces
{
    public interface ITreatmentService
    {
        bool SaveTreatment(Treatment threatment);
    }
}
