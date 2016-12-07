using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCKunskapskoll.Startup))]
namespace MVCKunskapskoll
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
