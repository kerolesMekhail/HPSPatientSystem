using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Patient_Systems.Startup))]
namespace Patient_Systems
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
