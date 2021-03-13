using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Orden
    {
        private int noOrden;
        private string nombreRemitente;
        private string empresaEnvio;
        private string direccionEnvio;
        private int noSeguimiento;
        private int idCliente;

        public Orden(int n, string nom, string emp, string dir, int seg, int cl)
        {
            noOrden = n;
            nombreRemitente = nom;
            empresaEnvio = emp;
            direccionEnvio = dir;
            noSeguimiento = seg;
            idCliente = cl;
        }

        public void setOrden(int x)
        {
            noOrden = x;
        }

        public int getOrden()
        {
            return noOrden;
        }

        public void setRemitente(string x)
        {
            nombreRemitente = x;
        }

        public string getRemitente()
        {
            return nombreRemitente;
        }

        public void setEnvio(string x)
        {
            empresaEnvio = x;
        }

        public string getEnvio()
        {
            return empresaEnvio;
        }

        public void setDireccion(string x)
        {
            direccionEnvio = x;
        }

        public string getDireccion()
        {
            return direccionEnvio;
        }

        public void setSeguimiento(int x)
        {
            noSeguimiento = x;
        }

        public int getSeguimiento()
        {
            return noSeguimiento;
        }

        public void setCliente(int x)
        {
            idCliente = x;
        }

        public int getCliente()
        {
            return idCliente;
        }

    }
}
