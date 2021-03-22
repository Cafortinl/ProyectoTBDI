using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Orden
    {
        public int noOrden { get; set; }
        public string nombreRemitente { get; set; }
        public string empresaEnvio { get; set; }
        public string direccionEnvio { get; set; }
        public int noSeguimiento { get; set; }
        public int idCliente { get; set; }
        public string estadoEnvio { get; set; }

        public Orden(int n, string nom, string emp, string dir, int seg, int cl, string e)
        {
            noOrden = n;
            nombreRemitente = nom;
            empresaEnvio = emp;
            direccionEnvio = dir;
            noSeguimiento = seg;
            idCliente = cl;
            estadoEnvio = e;
        }

        public Orden()
        {
        }

        public bool hasNullElem()
        {
            if (nombreRemitente == "")
                return true;
            if (empresaEnvio == "")
                return true;
            if (direccionEnvio == "")
                return true;
            return false;
        }

    }
}
