using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WAMPChat.App_Start;
using WampSharp.AspNet.WebSockets.Server;
using WampSharp.Binding;
using WampSharp.V2;

namespace WAMPChat
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //WampHost host = new WampHost();

            //// Listens at http://localhost:49875/ws where 49875 is the relevant port
            //host.RegisterTransport(new AspNetWebSocketTransport("ws"),
            //                       new JTokenJsonBinding());

            //host.Open();

            WampConfig.StartRouter().ContinueWith(x => WampConfig.StartServer());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
