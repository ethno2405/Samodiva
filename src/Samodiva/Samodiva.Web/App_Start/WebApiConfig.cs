using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Http;

namespace Samodiva.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            Contract.Requires<ArgumentNullException>(config != null);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
