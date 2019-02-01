using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace NW.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Eliminate all formatters and re-add JSON, will force response in JSON
            //config.Formatters.Clear();
            //config.Formatters.Add(new JsonMediaTypeFormatter());

            // Add QueryStringMappings
            //      http://localhost:8000/api/HelloWorld?format=json
            //      http://localhost:8000/api/HelloWorld?format=xml
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("format", "json", "application/json"));
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("format", "xml", "application/xml"));

            // Display Currently Installed Formatters to Debug Output Window
            foreach (MediaTypeFormatter formatter in config.Formatters)
            {
                Debug.WriteLine(formatter.GetType().Name);
                Debug.WriteLine("   Media Types: " + String.Join(", ", formatter.SupportedMediaTypes));
            }

            // Web API routes

            // Enable Attribute Routing
            config.MapHttpAttributeRoutes();

            // Convention Based Routing - Default Route
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
