using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class TieneEnCarrito
    {
        private int idCliente;
        private int idProducto;
        private int cantidadProductoCarrito;

        public TieneEnCarrito(int idc, int idp, int cant)
        {
            idCliente = idc;
            idProducto = idp;
            cantidadProductoCarrito = cant;
        }

        public void setCliente(int x)
        {
            idCliente = x;
        }

        public int getCliente()
        {
            return idCliente;
        }

        public void setProducto(int x)
        {
            idProducto = x;
        }

        public int getProducto()
        {
            return idProducto;
        }

        public void setCantidad(int x)
        {
            cantidadProductoCarrito = x;
        }

        public int getCantidad()
        {
            return cantidadProductoCarrito;
        }
    }
}
