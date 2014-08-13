using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(kattienhatt.Startup))]
namespace kattienhatt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
