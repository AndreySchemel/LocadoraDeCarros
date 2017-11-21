using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LocadoraDeCarros.Startup))]
namespace LocadoraDeCarros
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
