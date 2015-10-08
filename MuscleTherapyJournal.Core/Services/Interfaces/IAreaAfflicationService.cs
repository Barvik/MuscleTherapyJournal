using System.Collections.Generic;
using MuscleTherapyJournal.Domain.Model;

namespace MuscleTherapyJournal.Core.Services.Interfaces
{
    public interface IAreaAfflicationService
    {
        List<AfflictionArea> GetAfflicationAreasByTreatmentId(int treatmendId);
    }
}
