using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Abogados.Startup))]
namespace Abogados
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
