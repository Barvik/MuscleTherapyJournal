using StructureMap;
using StructureMap.Graph;

namespace MuscleTherapyJournal.Common.Infrastructure
{
    public static class StructureMapBootstrapper
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Configure(x => x.Scan(scan =>
            {
                scan.LookForRegistries();
                scan.TheCallingAssembly();
                scan.AssembliesFromApplicationBaseDirectory(y => y.FullName.StartsWith("MuscleTherapyJournal"));
                scan.WithDefaultConventions();
            }
                ));
            return ObjectFactory.Container;
        }
    }
}
