﻿namespace WebServer.Server.Routing
{
    using System.Collections.Generic;
    using Enums;
    using Handlers;
    using Contracts;
    using System;
    using System.Linq;

    public class AppRouteConfig : IAppRouteConfig
    {
        private Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> routes;

        public AppRouteConfig()
        {
            this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>>();

            var availableMethods = Enum
                .GetValues(typeof(HttpRequestMethod))
                .Cast<HttpRequestMethod>();

            foreach (var method in availableMethods)
            {
                this.routes[method] = new Dictionary<string, RequestHandler>();
            }
        }

        public IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes => this.routes;

        public void AddRoute(string route, RequestHandler handler)
        {
            var handlerName = handler.GetType().Name.ToLower();

            if (handlerName.Contains("get"))
            {
                this.routes[HttpRequestMethod.Get].Add(route,handler);
            }
            else if(handlerName.Contains("post"))
            {
                this.routes[HttpRequestMethod.Post].Add(route, handler);
            }
            else
            {
                throw new InvalidOperationException("Invalid handler.");
            }
        }
    }
}
