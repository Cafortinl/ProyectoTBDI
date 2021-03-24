using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace ProyectoTDBI_Grupo4
{
    class DBAdmin
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader dr;
        public DBAdmin(string connString)
        {
            conn = new NpgsqlConnection(connString);
            Console.WriteLine("Conected");
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

        public void clearQuery()
        {
            cmd = null;
            dr.Close();
            dr = null;
        }

        public NpgsqlDataReader executeQuery()
        {
            return dr = cmd.ExecuteReader();
        }

        public NpgsqlCommand getcmd()
        {
            return cmd;
        }

        public NpgsqlConnection getConn()
        {
            return conn;
        }

    }
}
