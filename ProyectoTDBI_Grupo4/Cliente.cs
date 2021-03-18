using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Cliente
    {
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public bool isFrecuente { get; set; }
        public bool isVirtual { get; set; }
        public string direccionFacturacion { get; set; }
        public string nombreUsuario { get; set; }
        public string password { get; set; }
        public int numeroTarjeta { get; set; }
        public string tarjetaHabiente { get; set; }
        public int codigoSeguridad { get; set; }
        public int mesVencimiento { get; set; }
        public int yearVencimiento { get; set; }

        public Cliente(int id, string n, bool f, bool v, string dir, string u, string p, int t, string th, int seg, int mv, int yv)
        {
            idCliente = id;
            nombre = n;
            isFrecuente = f;
            isVirtual = v;
            direccionFacturacion = dir;
            nombreUsuario = u;
            password = p;
            numeroTarjeta = t;
            tarjetaHabiente = th;
            codigoSeguridad = seg;
            mesVencimiento = mv;
            yearVencimiento = yv;
        }

    }
}
