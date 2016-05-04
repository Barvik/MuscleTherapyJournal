using System.Collections.Generic;
using MuscleTherapyJournal.Domain.Model;
using MuscleTherapyJournal.Domain.Search;

namespace MuscleTherapyJournal.Core.Services.Interfaces
{
    public interface ITreatmentService
    {
        int SaveTreatment(Treatment treatment, bool newTreatment);
        Treatment GetTreatmentById(int treatmentId);
        List<TreatmentCustomer> GetTreatmentsBySearchCriteria(SearchParameters searchParameters);
        
    }
}
