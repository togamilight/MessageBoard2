using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MessageBoard2.Startup))]
namespace MessageBoard2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
