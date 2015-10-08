using System.Collections.Generic;
using MuscleTherapyJournal.Persitance.Entity;

namespace MuscleTherapyJournal.Persitance.DAO.Interfaces
{
    public interface IAreaAfflicationDAO
    {
        List<AfflictionAreaEntity> GetAfflicationAreas(int treatmentId);
    }
}
