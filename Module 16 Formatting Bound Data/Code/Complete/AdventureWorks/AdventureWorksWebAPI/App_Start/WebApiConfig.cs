using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace AdventureWorksWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("format", "json", "application/json"));
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("format", "xml", "application/xml"));

            // Display info about media type formatters
            foreach (MediaTypeFormatter fmt in config.Formatters)
            {
                Debug.WriteLine(fmt.GetType().Name);
                Debug.WriteLine("   Media Types: " + String.Join(", ", fmt.SupportedMediaTypes));
            }

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
