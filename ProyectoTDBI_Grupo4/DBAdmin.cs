using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace ProyectoTDBI_Grupo4
{
    class DB
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader dr;
        public DB(string connString)
        {
            conn = new NpgsqlConnection(connString);
        }

        public void open()
        {
            conn.Open();
        }
        public void close()
        {
            conn.Close();
        }
        public void defineQuery(string query)
        {
            cmd = new NpgsqlCommand(query, conn);
        }

        public NpgsqlDataReader executeQuery()
        {
            return dr = cmd.ExecuteReader();
        }
        
    }
}
