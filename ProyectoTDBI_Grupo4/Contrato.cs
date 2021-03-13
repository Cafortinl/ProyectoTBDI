using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Contrato
    {
        private int noCuenta;
        private double cuota;
        private int idCliente;

        public Contrato(int cue, double cuo, int cli)
        {
            noCuenta = cue;
            cuota = cuo;
            idCliente = cli;
        }

        public void setCuenta(int x)
        {
            noCuenta = x;
        }

        public int getCuenta()
        {
            return noCuenta;
        }

        public void setCuota(double x)
        {
            cuota = x;
        }

        public double getCuota()
        {
            return cuota;
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
