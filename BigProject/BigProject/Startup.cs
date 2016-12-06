using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BigProject.Startup))]
namespace BigProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
