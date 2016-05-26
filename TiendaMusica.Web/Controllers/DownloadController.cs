using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMusica.Logica;

namespace TiendaMusica.Web.Controllers
{
    public class DownloadController : Controller
    {
        // GET: Download
        public ActionResult Reporte()
        {
            //string archivoExcel = new ReporteSimple().Reporte();
            Stream archivoExcel = new ReporteSimple().Reporte();
            archivoExcel.Position = 0;
            //FilePathResult download = new FilePathResult(archivoExcel, "application/excel");
            FileStreamResult download = new FileStreamResult(archivoExcel, "application/excel");

            download.FileDownloadName = "Reporte_2016.xls";
            return download;
        }

        public ActionResult Descargar(string tipoArchivo)
        {
            string carperta = @"C:\Downloads\";


            try
            {
                DirectoryInfo infoDir = new DirectoryInfo(carperta);


                FileInfo[] ficheros = infoDir.GetFiles("*." + tipoArchivo);
                string ruta = ficheros[0].FullName;
                string mimeType = MimeMapping.GetMimeMapping(ficheros[0].FullName);
                FilePathResult download = new FilePathResult(ruta, mimeType);
                download.FileDownloadName = ficheros[0].Name;
                return download;


            }
            catch (DirectoryNotFoundException)
            {
                return new HttpStatusCodeResult(500);
                //return new HttpNotFoundResult("No existe o no se tiene acceso a la carpeta: " + carperta);
            }
            catch (IOException)
            {
                return new HttpNotFoundResult("el archivo está siendo utilizado en otro proceso ");
            }    

            catch (IndexOutOfRangeException)
            {
                return new HttpNotFoundResult("No existen archivos con la extención: " + tipoArchivo);
            }
            catch (NullReferenceException)
            {
                return new HttpNotFoundResult("la extención es desconocida actualmente: " + tipoArchivo);
            }
            

            





        }
    }
}