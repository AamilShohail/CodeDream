using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Email.Startup))]
namespace Email
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
