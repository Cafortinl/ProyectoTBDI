using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Inventario
    {
        private int codigoTienda;
        private int codigoAlmacen;
        private int idProducto;
        private int cantidadInventario;

        public Inventario(int t, int a, int p, int c)
        {
            codigoTienda = t;
            codigoAlmacen = a;
            idProducto = p;
            cantidadInventario = c;
        }

        public void setTienda(int x)
        {
            codigoTienda = x;
        }

        public int getTienda()
        {
            return codigoTienda;
        }

        public void setAlmacen(int x)
        {
            codigoAlmacen = x;
        }

        public int getAlmacen()
        {
            return codigoAlmacen;
        }

        public void setProducto(int x)
        {
            idProducto = x;
        }

        public int getProducto()
        {
            return idProducto;
        }

        public void setCant(int x)
        {
            cantidadInventario = x;
        }

        public int getCant()
        {
            return cantidadInventario;
        }

    }
}
