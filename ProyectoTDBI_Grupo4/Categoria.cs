using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Categoria
    {
        private int idProducto;
        private string nombreCategoria;

        public Categoria(int id, string nom)
        {
            idProducto = id;
            nombreCategoria = nom;
        }

        public void setID(int x)
        {
            idProducto = x;
        }

        public int getID()
        {
            return idProducto;
        }

        public void setCateg(string x)
        {
            nombreCategoria = x;
        }

        public string getCateg()
        {
            return nombreCategoria;
        }
    }
}
