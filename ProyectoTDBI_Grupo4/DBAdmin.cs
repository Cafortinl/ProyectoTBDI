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

        public NpgsqlDataReader executeQuery()
        {
            return dr = cmd.ExecuteReader();
        }
        public void insert(int nOrden, string nombreRemitente,string empresaEnvio, string DireccionEnvio, int nSeguimiento, int idCliente)
        {
            cmd.Parameters.AddWithValue("@nOrden", nOrden);
            cmd.Parameters.AddWithValue("@nombreRemitente", nombreRemitente);
            cmd.Parameters.AddWithValue("@empresaEnvio", empresaEnvio);
            cmd.Parameters.AddWithValue("@DireccionEnvio", DireccionEnvio);
            cmd.Parameters.AddWithValue("@nSeguimiento", nSeguimiento);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);
            cmd.ExecuteNonQuery();
        }


        public NpgsqlConnection getConn()
        {
            return conn;
        }

    }
}
