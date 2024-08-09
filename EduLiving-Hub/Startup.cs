using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EduLiving_Hub.Startup))]
namespace EduLiving_Hub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
