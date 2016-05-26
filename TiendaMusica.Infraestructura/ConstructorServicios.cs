using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaMusica.Data.InsightDB;
using TiendaMusica.Data.Repositorio;
using TiendaMusica.Data.Repositorio.EF;
using TiendaMusica.Logica;

namespace TiendaMusica.Infraestructura
{
    public class ConstructorServicios
    {
        public static TiendaConsultas TiendaConsulta()
        {
            //return new TiendaConsultas(new EFTiendaMusicaRepository());

            return new TiendaConsultas(new TiendaMusicaDB("ChinookDominio"));
        }
    }
}
