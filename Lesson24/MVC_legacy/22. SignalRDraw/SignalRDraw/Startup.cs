using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRDraw.Startup))]

namespace SignalRDraw
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
