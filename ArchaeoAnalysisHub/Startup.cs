using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArchaeoAnalysisHub.Startup))]
namespace ArchaeoAnalysisHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
