using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fabryka4.Startup))]
namespace Fabryka4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
