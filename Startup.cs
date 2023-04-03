using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoardGameListApp.Startup))]
namespace BoardGameListApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
