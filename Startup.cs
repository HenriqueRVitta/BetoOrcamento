using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Orcamento.Startup))]
namespace Orcamento
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
