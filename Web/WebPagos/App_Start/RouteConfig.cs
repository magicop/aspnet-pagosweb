using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebPagos
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            #region Rutas
            // Rutas que ejecutan cierta acción de cada controlador

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BuscarPago",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Pago", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Resultado",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Pago", action = "Resultado", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Regularizar",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Pago", action = "Regularizar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DetallesDeuda",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Deuda", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "DetallesDeuda",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Deuda", action = "Resultado", id = UrlParameter.Optional }
            //);

            #endregion

        }
    }
}
