using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MuscleTherapyJournal.Startup))]
namespace MuscleTherapyJournal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
