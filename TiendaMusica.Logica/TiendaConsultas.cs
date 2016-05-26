using System;
using System.Collections.Generic;
using System.Linq;
using TiendaMusica.Data;
using TiendaMusica.Data.Repositorio;
using TiendaMusica.Logica.Comun;
using TiendaMusica.Logica.ViewModels;

namespace TiendaMusica.Logica
{
    public class TiendaConsultas
    {
        private readonly ITiendaMusicaRepository db;

        public TiendaConsultas(ITiendaMusicaRepository repositorio)
        {
            db = repositorio;
        }
        public IEnumerable<AlbumsPorArtistaViewModel> Albums(string nombre)
        {
            string nombreConvertido = Utilidades.TransformarNombre(nombre);
            //usando un orm
            //return db.Albums.GetAll()
            //    .Where(a => a.Artist.Name == nombreConvertido)
            //    .Select(o=> new AlbumsPorArtistaViewModel
            //    {
            //        Album = o.Title,
            //        Artista = o.Artist.Name
            //    }).ToList();

            //usando insightdatabase

            return db.ConsultaAdHoc<AlbumsPorArtistaViewModel>("Select a.Title Album, b.Name Artista, a.Portada Portada from dbo.Album a" +
                " inner join dbo.Artist b on a.ArtistId = b.ArtistId "+
                "Where b.Name = @Name ;",
                new {Name = nombreConvertido });

        }

        public EditAlbumViewModel getAlbumId(string idAlbum)
        {
            return db.ConsultaAdHoc<EditAlbumViewModel>("Select a.Portada Portada,a.Title NombreAlbum, a.AlbumId idAlbum from dbo.Album a" +
               " inner join dbo.Artist b on a.ArtistId = b.ArtistId " +
               "Where a.AlbumId = @IdAlbum ;",
               new
               {
                   IdAlbum = idAlbum
               }).Single();
        }

        public void updateAlbum(string idAlbum, string albumnombre, string portada)
        {
            db.ConsultaAdHoc<EditAlbumViewModel>("Update  dbo.Album set Portada = @PPortada, Title = @PTitle " +
               "Where AlbumId = @IdAlbum ;", new
               {
                   IdAlbum = idAlbum,
                   PPortada = portada,
                   PTitle = albumnombre
               });

        }

        public IEnumerable<TracksViewModel> canciones(string cancion, string album)
        {
            string AlbumConvertido = Utilidades.TransformarNombre(album);
            string cancionConvertido = Utilidades.TransformarNombre(cancion);
            return db.ConsultaAdHoc<TracksViewModel>
                ("Select a.Name tituloCancion, a.Milliseconds duracion, a.Archivo archivo,b.Title album from dbo.Track a" +
                " inner join dbo.Album b on a.AlbumId = b.AlbumId"+
                " inner join dbo.Artist c on c.ArtistId = b.ArtistId "+
                " Where a.Name = @CancionName and b.Title = @AlbumNombre",
                new { CancionName = cancionConvertido, AlbumNombre = AlbumConvertido });
        }

        public void updateTrack(EditTrackViewModel model)
        {
            db.ConsultaAdHoc<EditTrackViewModel>
                ("Update dbo.Track set Name= @Name , Archivo = @Archivo Where TrackId = @Id",
                new {Name = model.Name , Archivo=model.Archivo,Id = model.id });
        }

        public EditAlbumViewModel getAlbum(string artista, string album)
        {
            string AlbumConvertido = Utilidades.TransformarNombre(album);
            string artistaConvertido = Utilidades.TransformarNombre(artista);
            return db.ConsultaAdHoc<EditAlbumViewModel>("Select a.Portada Portada,a.Title NombreAlbum, a.AlbumId idAlbum from dbo.Album a" +
                " inner join dbo.Artist b on a.ArtistId = b.ArtistId " +
                "Where b.Name = @ArtistaName and a.Title =@AlbumName ;",
                new { ArtistaName = artistaConvertido,
                  AlbumName = AlbumConvertido
                }).Single();
        }

        public EditTrackViewModel GetTrack(string artista, string album)
        {
            string AlbumConvertido = Utilidades.TransformarNombre(album);
            string artistaConvertido = Utilidades.TransformarNombre(artista);
            return db.ConsultaAdHoc<EditTrackViewModel>("  select t.TrackId id, t.Name Name, t.Archivo Archivo"+
  " from dbo.Track t "+
  "inner join dbo.Album a on a.AlbumId = t.AlbumId "+
  "inner join dbo.Artist r on r.ArtistId = t.ArtistId "+
  "Where a.Title = @pAlbumConvertido and r.Name = @partistaConvertido;",
  new { pAlbumConvertido = AlbumConvertido,
      partistaConvertido = artistaConvertido
  }).Single();
        }
        public EditTrackViewModel GetTrack(int id)
        {
            return db.ConsultaAdHoc<EditTrackViewModel>("  select t.TrackId id, t.Name Name, t.Archivo Archivo" +
  "from dbo.Track t " +
  "Where t.TrackId = @Idtrack;",
  new
  {
      Idtrack = id
  }).Single();
        }
    }
}