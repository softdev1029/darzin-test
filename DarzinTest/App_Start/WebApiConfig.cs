﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace DarzinTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
	        var jsonFormatter = config.Formatters.JsonFormatter;
	        jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
	        config.Formatters.Remove(config.Formatters.XmlFormatter);
	        jsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            jsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
