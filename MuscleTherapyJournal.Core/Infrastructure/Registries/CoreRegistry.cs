using MuscleTherapyJournal.Core.Services;
using MuscleTherapyJournal.Core.Services.Interfaces;
using StructureMap.Configuration.DSL;

namespace MuscleTherapyJournal.Core.Infrastructure.Registries
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            For<ITreatmentService>().Use<TreatmentService>();
        }
    }
}
