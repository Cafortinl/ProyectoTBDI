using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Contrato
    {
        public int noCuenta { get; set; }
        public double cuota { get; set; }
        public int idCliente { get; set; }

        public Contrato(int cue, double cuo, int cli)
        {
            noCuenta = cue;
            cuota = cuo;
            idCliente = cli;
        }

        public Contrato()
        {
        }

    }
}
