using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HobbyManager.WebMVC.Startup))]
namespace HobbyManager.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
