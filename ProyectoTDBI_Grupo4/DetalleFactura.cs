using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class DetalleFactura
    {
        private int noFactura;
        private double total;
        private double isv;
        private int cantidadProducto;
        private int idProducto;
        private double subtotal;

        public DetalleFactura(int f, double t, double i, int cant, int p, double s)
        {
            noFactura = f;
            total = t;
            isv = i;
            cantidadProducto = cant;
            idProducto = p;
            subtotal = s;
        }

        public void setFactura(int x)
        {
            noFactura = x;
        }

        public int getFactura()
        {
            return noFactura;
        }

        public void setTotal(double x)
        {
            total = x;
        }

        public double getTotal()
        {
            return total;
        }

        public void setISV(double x)
        {
            isv = x;
        }

        public double getISV()
        {
            return isv;
        }

        public void setCant(int x)
        {
            cantidadProducto = x;
        }

        public int getCant()
        {
            return cantidadProducto;
        }

        public void setProducto(int x)
        {
            idProducto = x;
        }

        public int getProducto()
        {
            return idProducto;
        }

        public void setSub(double x)
        {
            subtotal = x;
        }

        public double getSub()
        {
            return subtotal;
        }

    }
}
