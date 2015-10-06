
using AutoMapper;
using StructureMap.Configuration.DSL;

namespace MuscleTherapyJournal.Common.Infrastructure.Registries
{
    public class GeneralRegistry : Registry
    {
        public GeneralRegistry()
        {
            For<IMappingEngine>().Use(Mapper.Engine);
        }
    }
}
