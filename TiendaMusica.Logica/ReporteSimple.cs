using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMusica.Logica
{
    public class ReporteSimple
    {
        public Stream Reporte()
        {
            HSSFWorkbook libro = new HSSFWorkbook();
            var hoja = libro.CreateSheet("Ejemplo Reporte");
            var fila = hoja.CreateRow(1);
            var celda = fila.CreateCell(1);

            celda.SetCellValue("Reporte de Ejemplo");

            for(int i = 3; i < 6; i++)
            {
                var filan = hoja.CreateRow(i);
                var celda1 = filan.CreateCell(1);
                celda1.SetCellValue($"Presentacion del proyecto final Proyecto {i}");
                celda1.CellStyle.WrapText = true;
                var celda2 = filan.CreateCell(2);
                celda2.SetCellValue(DateTime.Now.AddDays(i).ToLongDateString());
            }
            //var nombreArchivo = NombreArchivo();
            //var fileStream = new FileStream(nombreArchivo, FileMode.CreateNew);
            //libro.Write(fileStream);
            //fileStream.Flush();
            //fileStream.Close();

            var memoryString = new MemoryStream();
            libro.Write(memoryString);
            return memoryString;
        }

        private string NombreArchivo()
        {
            var ruta = Path.GetTempFileName();
            File.Delete(ruta);
            return Path.ChangeExtension(ruta, "xls");
        }
    }
}
