using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Producto
    {
        private int idProducto;
        private string fabricante;
        private string modelo;
        private string nombreProducto;
        private double precio;
        private string tipoProducto;
        private string descripcion;

        public Producto(int id, string fab, string mod, string nombre, double p, string tipo, string desc)
        {
            idProducto = id;
            fabricante = fab;
            modelo = mod;
            nombreProducto = nombre;
            precio = p;
            tipoProducto = tipo;
            descripcion = desc;
        }

        public void setID(int x)
        {
            idProducto = x;
        }

        public int getID()
        {
            return idProducto;
        }

        public void setFabricante(string x)
        {
            fabricante = x;
        }

        public string getFabricante()
        {
            return fabricante;
        }

        public void setModelo(string x)
        {
            modelo = x;
        }

        public string getModelo()
        {
            return modelo;
        }

        public void setNombre(string x)
        {
            nombreProducto = x;
        }

        public string getNombre()
        {
            return nombreProducto;
        }

        public void setPrecio(double x)
        {
            precio = x;
        }

        public double getPrecio()
        {
            return precio;
        }

        public void setTipo(string x)
        {
            tipoProducto = x;
        }

        public string getTipo()
        {
            return tipoProducto;
        }

        public void setDescripcion(string x)
        {
            descripcion = x;
        }

        public string getDescripcion()
        {
            return descripcion;
        }

    }
}
