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

        public Almacen() 
        { 
        }
    }
}
