using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BibliotecaComunitaria.Startup))]
namespace BibliotecaComunitaria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
