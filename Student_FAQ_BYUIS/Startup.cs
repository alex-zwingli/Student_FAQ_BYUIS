using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Student_FAQ_BYUIS.Startup))]
namespace Student_FAQ_BYUIS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
