using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BiteMe.Startup))]
namespace BiteMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
