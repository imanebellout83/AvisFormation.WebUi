using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AvisFormation.WebUi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "ToutesLesFormations",
            //    url: "toutes-les-formations",
            //    defaults: new { controller = "Formation", action = "ToutesLesFormations", id = UrlParameter.Optional });


            //routes.MapRoute(
            //    name: "DetailsFormations",
            //    url: "formation/{nomSeo}",
            //    defaults: new { controller = "Formation", action = "DetailsFormations" });

            //routes.MapRoute(
            //    name: "Contact",
            //    url: "contact",
            //    defaults: new { controller = "Contact", action = "index" });
            //routes.MapRoute(
            //   name: "AjouterUnAvis",
            //   url: "avis/{nomSeo}",
            //   defaults: new { controller = "Avis", action = "AjouterUnAvis" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Accueil", id = UrlParameter.Optional }
            );
        }
    }
}
