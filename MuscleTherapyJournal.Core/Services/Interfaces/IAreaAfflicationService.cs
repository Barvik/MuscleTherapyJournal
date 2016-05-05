using System.Collections.Generic;
using MuscleTherapyJournal.Domain.Model;

namespace MuscleTherapyJournal.Core.Services.Interfaces
{
    public interface IAreaAfflicationService
    {
        List<AfflictionArea> GetAfflicationAreasByTreatmentId(int treatmendId);
        List<AfflictionArea> GetAfflicationAreasByCustomerId(int customerId);
        bool DeleteAfflications(List<AfflictionArea> deleteAfflication);
    }
}
