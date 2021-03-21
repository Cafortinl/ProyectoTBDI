using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Tienda
    {
        public int codigoTienda { get; set; }
        public string ubicacion { get; set; }

        public Tienda(int cod, string u)
        {
            codigoTienda = cod;
            ubicacion = u;
        }

        public Tienda()
        {
        }

        public bool hasNullElem()
        {
            if (ubicacion == "")
                return true;
            return false;
        }

    }
}
