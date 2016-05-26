using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using TiendaMusica.Infraestructura;
using TiendaMusica.Logica;
using TiendaMusica.Logica.ViewModels;
using TiendaMusica.Web.Utilidades;

namespace TiendaMusica.Web.Controllers
{
    public class ArtistasController : Controller
    {
        private readonly TiendaConsultas tienda;
        
        public ArtistasController()
        {
            tienda = ConstructorServicios.TiendaConsulta();
        }
        // GET: Buscar
        public ActionResult Albums(string nombre)
        {
            IEnumerable<AlbumsPorArtistaViewModel> albums = tienda.Albums(nombre);
            return View(albums);
        }

        public ActionResult editar(string artista, string album)
        {
            EditAlbumViewModel model = tienda.getAlbum(artista,album);
            return View(model);

        }

        [HttpPost]
        public ActionResult editar(EditAlbumViewModel modelo, HttpPostedFileBase portada)
        {

            MemoryStream ms = new MemoryStream();
            portada.InputStream.CopyTo(ms);
            Imagen imagen = new Imagen(ms,
                portada.FileName,
                portada.ContentType,
                Server.MapPath("~/Albums"));

            imagen.Grabar(portada.FileName, Server.MapPath("~/Albums/thumbnails"));


            tienda.updateAlbum(""+modelo.idAlbum, modelo.NombreAlbum, portada.FileName);
            EditAlbumViewModel model = tienda.getAlbumId(""+modelo.idAlbum);
            return View(model);
            //return RedirectToAction("Index", "Home");

        }

        public ActionResult perfil(string nombre)
        {
            IEnumerable<AlbumsPorArtistaViewModel> albums = tienda.Albums(nombre);
            return View(albums);
        }

        public ActionResult canciones(string artista,string album)
        { 
            IEnumerable<TracksViewModel> canciones = tienda.canciones(artista, album);
            return View(canciones);
        }


        public ActionResult EditaCancion(string cancion,string album)
        {
            EditTrackViewModel model = tienda.GetTrack(cancion, album);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditaCancion(EditTrackViewModel model, HttpPostedFileBase file)
        {

            string narchivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + file.FileName).ToLower();
            file.SaveAs(Server.MapPath("~/Uploads/" + narchivo));
            model.Archivo = narchivo;
            tienda.updateTrack(model);

            EditTrackViewModel modelr = tienda.GetTrack(model.id);

            return View(modelr);
        }





    }
}