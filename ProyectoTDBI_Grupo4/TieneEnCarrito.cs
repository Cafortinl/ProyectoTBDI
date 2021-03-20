using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class TieneEnCarrito
    {
        public int idCliente { get; set; }
        public int idProducto { get; set; }
        public int cantidadProductoCarrito { get; set; }

        public TieneEnCarrito(int idc, int idp, int cant)
        {
            idCliente = idc;
            idProducto = idp;
            cantidadProductoCarrito = cant;
        }

        public TieneEnCarrito()
        {
        }

    }
}
