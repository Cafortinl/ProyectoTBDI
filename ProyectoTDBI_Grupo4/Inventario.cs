using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Inventario
    {
        public int codigoTienda { get; set; }
        public int codigoAlmacen { get; set; }
        public int idProducto { get; set; }
        public int cantidadInventario { get; set; }

        public Inventario(int t, int a, int p, int c)
        {
            codigoTienda = t;
            codigoAlmacen = a;
            idProducto = p;
            cantidadInventario = c;
        }

        public Inventario()
        {
        }

    }
}
