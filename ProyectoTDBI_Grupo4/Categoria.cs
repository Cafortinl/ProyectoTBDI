using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTDBI_Grupo4
{
    class Categoria
    {
        public int idProducto { get; set; }
        public string nombreCategoria { get; set; }

        public Categoria(int id, string nom)
        {
            idProducto = id;
            nombreCategoria = nom;
        }

        public Categoria()
        {
        }

    }
}
