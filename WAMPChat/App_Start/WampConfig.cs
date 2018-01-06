using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WAMPChat.Wamp;
using WampSharp.V2;

namespace WAMPChat.App_Start
{
    internal class WampConfig
    {
        public static Task StartRouter() => Task.Run(() =>
        {
            var host = new DefaultWampHost("localhost:49875/ws");
            host.Open();
        });


        public static Task StartServer() => Task.Run(async () =>
        {
            var factory = new DefaultWampChannelFactory();
            var channel = factory.CreateJsonChannel("localhost:49875/ws", "realm1");

            await channel.Open();

            var realm = channel.RealmProxy;
            var subject = realm.Services.GetSubject<int>("wamp.test.count.changed");

            WampTestCallee.CountChanged += count => subject.OnNext(count);

            await realm.Services.RegisterCallee(new WampTestCallee());
        });
    }
}