using System;

namespace TiendaMusica.Logica.Comun
{
    public  class Utilidades
    {
        public  static string TransformarNombre(string nombre)
        {
            string nuevonombre = nombre.Replace("_", " ");
            //nuevonombre = nombre.Replace("%", ".");

            return nuevonombre.Replace("-", "/");
        }

        public static string TransformarNombre2(string nombre)
        {
            string nuevonombre = nombre.Replace(" ", "_");
            //nuevonombre = nombre.Replace(".", "%");

            return nuevonombre.Replace("/", "-");
        }
    }
}