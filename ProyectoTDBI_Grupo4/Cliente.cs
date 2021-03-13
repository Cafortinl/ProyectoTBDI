using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Cliente
    {
        private int idCliente;
        private string nombre;
        private bool isFrecuente;
        private bool isVirtual;
        private string direccionFacturacion;
        private string nombreUsuario;
        private string password;
        private int numeroTarjeta;
        private string tarjetaHabiente;
        private int codigoSeguridad;
        private int mesVencimiento;
        private int yearVencimiento;

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

        public void setCliente(int x)
        {
            idCliente = x;
        }

        public int getCliente()
        {
            return idCliente;
        }

        public void setNombre(string x)
        {
            nombre = x;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setIsFrecuente(bool x)
        {
            isFrecuente = x;
        }

        public bool isIsFrecuente()
        {
            return isFrecuente;
        }

        public void setIsVirtual(bool x)
        {
            isVirtual = x;
        }

        public bool isIsVirtual()
        {
            return isVirtual;
        }

        public void setDireccion(string x)
        {
            direccionFacturacion = x;
        }

        public string getDireccion()
        {
            return direccionFacturacion;
        }

        public void setUsuario(string x)
        {
            nombreUsuario = x;
        }

        public string getUsuario()
        {
            return nombreUsuario;
        }

        public void setPassword(string x)
        {
            password = x;
        }

        public string getPassword()
        {
            return password;
        }

        public void setNumTarjeta(int x)
        {
            numeroTarjeta = x;
        }

        public int getNumTarjeta()
        {
            return numeroTarjeta;
        }

        public void setTarjHab(string x)
        {
            tarjetaHabiente = x;
        }

        public string getTarjHab()
        {
            return tarjetaHabiente;
        }

        public void setCodSeg(int x)
        {
            codigoSeguridad = x;
        }

        public int getCodSeg()
        {
            return codigoSeguridad;
        }

        public void setMes(int x)
        {
            mesVencimiento = x;
        }

        public int getMes()
        {
            return mesVencimiento;
        }

        public void setYear(int x)
        {
            yearVencimiento = x;
        }

        public int getYear()
        {
            return yearVencimiento;
        }

    }
}
