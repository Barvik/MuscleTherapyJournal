using MuscleTherapyJournal.Core.Factories;
using MuscleTherapyJournal.Core.Factories.Interfaces;
using MuscleTherapyJournal.Core.Services;
using MuscleTherapyJournal.Core.Services.Interfaces;
using MuscleTherapyJournal.Persitance.DAO;
using MuscleTherapyJournal.Persitance.DAO.Interfaces;
using StructureMap.Configuration.DSL;

namespace MuscleTherapyJournal.Core.Infrastructure.Registries
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            For<ITreatmentService>().Use<TreatmentService>();

            For<ITreatmentDAO>().Use<TreatmentDAO>();

            For<ITreatmentFactory>().Use<TreatmentFactory>();
        }
    }
}
