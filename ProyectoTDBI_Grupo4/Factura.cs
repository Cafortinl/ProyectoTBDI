using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Factura
    {
        public int noFactura { get; set; }
        public int RTN { get; set; }
        public string fechaEmision { get; set; }
        public string direccion { get; set; }
        public int idCliente { get; set; }
        public int codigoTienda { get; set; }

        public Factura(int n, int r, string f, string dir, int c, int t)
        {
            noFactura = n;
            RTN = r;
            fechaEmision = f;
            direccion = dir;
            idCliente = c;
            codigoTienda = t;
        }

    }
}
