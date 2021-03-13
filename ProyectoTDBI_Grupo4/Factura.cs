using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Factura
    {
        private int noFactura;
        private int RTN;
        private string fechaEmision;
        private string direccion;
        private int idCliente;
        private int codigoTienda;

        public Factura(int n, int r, string f, string dir, int c, int t)
        {
            noFactura = n;
            RTN = r;
            fechaEmision = f;
            direccion = dir;
            idCliente = c;
            codigoTienda = t;
        }

        public void setFactura(int x)
        {
            noFactura = x;
        }

        public int getFactura()
        {
            return noFactura;
        }

        public void setRTN(int x)
        {
            RTN = x;
        }

        public int getRTN()
        {
            return RTN;
        }

        public void setFecha(string x)
        {
            fechaEmision = x;
        }

        public string getFecha()
        {
            return fechaEmision;
        }

        public void setDireccion(string x)
        {
            direccion = x;
        }

        public string getDireccion()
        {
            return direccion;
        }

        public void setCliente(int x)
        {
            idCliente = x;
        }

        public int getCliente()
        {
            return idCliente;
        }

        public void setTienda(int x)
        {
            codigoTienda = x;
        }

        public int getTienda()
        {
            return codigoTienda;
        }

    }
}
