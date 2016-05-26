using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TiendaMusica.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                 name: "TracksEdit",
                 url: "admin/{album}/{cancion}/editar",
                 defaults: new { controller = "Artistas", action = "EditaCancion" }
             );
            routes.MapRoute(
                 name: "Tracks",
                 url: "tienda/{artista}/{album}/tracks",
                 defaults: new { controller = "Artistas", action = "canciones" }
             );
            routes.MapRoute(
                name: "Artistas",
                url: "tienda/{nombre}/{action}",
                defaults: new { controller = "Artistas", action = "perfil"}
            );

            routes.MapRoute(
                name: "EditAlbums",
                url: "Admin/{artista}/{album}/{action}",
                defaults: new { controller = "Artistas", action = "ver" }
            );

            routes.MapRoute(
                name: "archivos",
                url: "Download/{action}/{tipoArchivo}",
                defaults: new { controller = "Download"}
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
