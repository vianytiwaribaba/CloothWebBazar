using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClothBajar.WebNew.Startup))]
namespace ClothBajar.WebNew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
