using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class DetalleFactura
    {
        public int noFactura { get; set; }
        public double total { get; set; }
        public double isv { get; set; }
        public int cantidadProducto { get; set; }
        public int idProducto { get; set; }
        public double subtotal { get; set; }

        public DetalleFactura(int f, double t, double i, int cant, int p, double s)
        {
            noFactura = f;
            total = t;
            isv = i;
            cantidadProducto = cant;
            idProducto = p;
            subtotal = s;
        }

        public DetalleFactura()
        {
        }

        public bool hasNullElem()
        {
            if (cantidadProducto == 0)
                return true;
            return false;
        }

    }
}
