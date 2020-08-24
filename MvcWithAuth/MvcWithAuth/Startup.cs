using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcWithAuth.Startup))]
namespace MvcWithAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
