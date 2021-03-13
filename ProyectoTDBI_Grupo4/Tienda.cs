using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Tienda
    {
        private int codigoTienda;
        private string ubicacion;

        public Tienda(int cod, string u)
        {
            codigoTienda = cod;
            ubicacion = u;
        }

        public void setTienda(int x)
        {
            codigoTienda = x;
        }

        public int getTienda()
        {
            return codigoTienda;
        }

        public void setUbicacion(string x)
        {
            ubicacion = x;
        }

        public string getUbicacion()
        {
            return ubicacion;
        }

    }
}
