using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DailyJobStarterPack.Startup))]
namespace DailyJobStarterPack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
