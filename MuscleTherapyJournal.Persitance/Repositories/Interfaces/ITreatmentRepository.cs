using System;
using System.Collections.Generic;
using MuscleTherapyJournal.Domain.Search;
using MuscleTherapyJournal.Persitance.Entity;
using MuscleTherapyJournal.Persitance.RelationshipEntities;

namespace MuscleTherapyJournal.Persitance.DAO.Interfaces
{
    public interface ITreatmentRepository
    {
        int CreateTreatment(TreatmentEntity treatment);
        TreatmentEntity GetTreatment(int treatmentId);
        List<TreatmentCustomerEntity> GetTreatmentsBySearchCriteria(SearchParameters searchParameters, DateTime fromDate, DateTime toDate);
        List<TreatmentEntity> GetTreatmentsByCustomerId(int customerId);
        int UpdateTreatment(TreatmentEntity treatment);
    }
}
