using System;
using System.Collections.Generic;

namespace AuthServer.Server.Services.ReverseProxy.Configuration
{
    public class MemorySingletonProxyConfigProvider
    {
        private List<Route> Routes = new List<Route>();

        internal List<Route> GetRoutes()
        {
            return Routes;
        }

        internal void AddRoute(Route route)
        {
            Routes.Add(route);
        }

        public class Route
        {
            public readonly string InternalHostname;
            public readonly string PublicHostname;
            public readonly Guid ProxySettingId;

            public Route(Guid proxySettingId, string internalHostName, string publicHostName)
            {
                ProxySettingId = proxySettingId;
                InternalHostname = internalHostName;
                PublicHostname = publicHostName;
            }
        }
    }
}