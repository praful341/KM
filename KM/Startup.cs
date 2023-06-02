using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KM.Startup))]
namespace KM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
