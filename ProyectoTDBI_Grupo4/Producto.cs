using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Producto
    {
        public int idProducto { get; set; }
        public string fabricante { get; set; }
        public string modelo { get; set; }
        public string nombreProducto { get; set; }
        public double precio { get; set; }
        public string tipoProducto { get; set; }
        public string descripcion { get; set; }

        public Producto(string fab, int id, string mod, string nombre, string tipo, string desc, double p)
        {
            idProducto = id;
            fabricante = fab;
            modelo = mod;
            nombreProducto = nombre;
            precio = p;
            tipoProducto = tipo;
            descripcion = desc;
        }

        public Producto()
        {
        }

        public bool hasNullElem()
        {
            if (fabricante == "")
                return true;
            if (modelo == "")
                return true;
            if (nombreProducto == "")
                return true;
            if (tipoProducto == "")
                return true;
            if (descripcion == "")
                return true;
            return false;
        }

    }
}
