using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelDemo.Startup))]
namespace TravelDemo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
