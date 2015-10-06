using System.Web.Mvc;
using MuscleTherapyJournal.Common.Infrastructure;
using MuscleTherapyJournal.Infrastructure;
using StructureMap;

namespace MuscleTherapyJournal.App_Start
{
    public static class StructuremapMvc
    {
        public static void Start()
        {
            StructureMapBootstrapper.Initialize();
            DependencyResolver.SetResolver(new StructureMapContainer(ObjectFactory.Container));
        }
    }
}