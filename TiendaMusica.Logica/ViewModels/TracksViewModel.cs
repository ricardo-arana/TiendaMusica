using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMusica.Logica.ViewModels
{
    public class TracksViewModel
    {
        public string tituloCancion { get; set; }
        public decimal duracion { get; set; }
        public string archivo { get; set; }
        public string album { get; set; }
    }
}
