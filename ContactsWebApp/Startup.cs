using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContactsWebApp.Startup))]
namespace ContactsWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
