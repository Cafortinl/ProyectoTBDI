using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Almacen
    {
        public int codigoAlmacen { get; set; }
        public string ciudad { get; set; }
        
        public Almacen(int cod, string ciu)
        {
            codigoAlmacen = cod;
            ciudad = ciu;
        }

        public void SetCodigoAlmacen(int x)
        {
            codigoAlmacen = x;
        }

        public int GetCodigoAlmacen()
        {
            return codigoAlmacen;
        }

        public void SetCiudad(string x)
        {
            ciudad = x;
        }

        public string GetCiudad()
        {
            return ciudad;
        }

    }
}
