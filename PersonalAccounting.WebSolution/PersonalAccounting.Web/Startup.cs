using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PersonalAccounting.Web.Startup))]
namespace PersonalAccounting.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
