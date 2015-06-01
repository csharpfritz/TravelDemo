using Microsoft.Owin;
using Owin;
using TravelDemo.Secret;

[assembly: OwinStartupAttribute(typeof(TravelDemo.Startup))]
namespace TravelDemo
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {

      app.AddUserSecrets();

      ConfigureAuth(app);
    }
  }
}
