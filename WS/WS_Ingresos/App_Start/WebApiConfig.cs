using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WS_Ingresos
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            XmlConfigurator.Configure();
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "PostDatosCotizaNew",
                routeTemplate: "api/PostDatosCotizaNew",
                defaults: new
                {
                    controller = "Cotizaciones",
                    action = "PostDatosCotizaNew"
                }
            );
        }
    }
}
