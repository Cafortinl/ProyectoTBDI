using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Almacen
    {
        private int codigoAlmacen;
        private string ciudad;
        
        public Almacen(int cod, string ciu)
        {
            codigoAlmacen = cod;
            ciudad = ciu;
        }

        public void setCodigoAlmacen(int x)
        {
            codigoAlmacen = x;
        }

        public int getCodigoAlmacen()
        {
            return codigoAlmacen;
        }

        public void setCiudad(string x)
        {
            ciudad = x;
        }

        public string getCiudad()
        {
            return ciudad;
        }

    }
}
