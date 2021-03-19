﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Npgsql;


namespace ProyectoTDBI_Grupo4
{
    /// <summary>
    /// Interaction logic for CallCenter.xaml
    /// </summary>
    public partial class CallCenter : Window
    {
        private static string Host = "proyectotdbi.ce6kih4lqvgw.us-east-1.rds.amazonaws.com";
        private static string User = "administrador";
        private static string DBname = "ProyectoTDBI";
        private static string Port = "5432";
        private static string Password = "AdM1n_Pr0yect0#1";
        private static string connString =
        String.Format(
                "Server={0};Port={1};Database={2};User Id={3};Password={4};",
                Host,
                Port,
                DBname,
                User,
                Password);
        private DBAdmin dba = new DBAdmin(connString);

        public CallCenter()
        {
            InitializeComponent();
            try
            { 
                tablaOrden();
                tablaCliente();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }
        }

        private void Cll_BtCompra_Click(object sender, RoutedEventArgs e)
        {
            NpgsqlDataReader dr;
            dba.open();

            int idCliente = Convert.ToInt32(Cll_idCliente.Text);
            int nOrden = Convert.ToInt32(Cll_nOrden.Text);
            int nSeguimiento = Convert.ToInt32(Cll_nSeguimiento.Text);
            string nombreRemitente = Cll_nRemitente.Text;
            string empresaEnvio = Cll_EmpresaEnvio.Text;
            string DireccionEnvio = Cll_DirreccionEnvio.Text;
            
            string query = "INSERT INTO orden VALUES (@nOrden,@nombreRemitente,@empresaEnvio,@DireccionEnvio,@nSeguimiento,@idCliente)";
            dba.defineQuery(query);
            dba.insert(nOrden, nombreRemitente, empresaEnvio, DireccionEnvio, nSeguimiento, idCliente);
            
            dba.close();
            tablaOrden();
            Cll_idCliente.Text = "";
            Cll_nOrden.Text = "";
            Cll_nSeguimiento.Text = "";
            Cll_nRemitente.Text = "";
            Cll_EmpresaEnvio.Text = "";
            Cll_DirreccionEnvio.Text = "";
        }

        private void tablaOrden()
        {
            NpgsqlDataReader dr;
            dba.open();
            List<Orden> listaOrden = new List<Orden>();
            dba.defineQuery("SELECT * FROM orden");
            dr = dba.executeQuery();
            while (dr.Read())
            {
                listaOrden.Add(new Orden(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetInt32(4), dr.GetInt32(5)));
            }

            DataGrid_Orden.ItemsSource = listaOrden;
            dba.close();
            
        }
        private void tablaCliente()
        {
            NpgsqlDataReader dr;
            dba.open();
            List<Cliente> infoClien = new List<Cliente>();
            dba.defineQuery("SELECT * FROM cliente");
            dr = dba.executeQuery();
            while (dr.Read())
            {
                infoClien.Add(new Cliente(dr.GetInt32(0), dr.GetString(1), dr.GetBoolean(2), dr.GetBoolean(3), dr.GetString(4), dr.GetString(5), dr.GetString(6), dr.GetInt32(7), dr.GetString(8), dr.GetInt32(9), dr.GetInt32(10), dr.GetInt32(11)));
            }
            DataGrid_Clientes.ItemsSource = infoClien;
            dba.close();
           
        }
    }
}

/*List<Cliente> lista = new List<Cliente>();
                    int cont = 0;
                    while (dr.Read())
                    {
                        lista.Add(new Cliente(Convert.ToInt32(dr[0]), Convert.ToString(dr[1]), Convert.ToBoolean(dr[2]), Convert.ToBoolean(dr[3]), Convert.ToString(dr[4]), Convert.ToString(dr[5]), Convert.ToString(dr[6]), Convert.ToInt32(dr[7]), Convert.ToString(dr[8]), Convert.ToInt32(dr[9]), Convert.ToInt32(dr[10]), Convert.ToInt32(dr[11])));
                        if (Convert.ToInt32(dr[0]) == idCliente)
                        {
                            posi = cont;
                        }
                        cont++;
                    }
                    if (posi != -1)
                    {


                    }
                    else
                    {
                        MessageBox.Show("No encontro al cliente");
                    }*/


//string query= "INSERT INTO \"orden\" VALUES " + nOrden+",'{"+nombreRemitente+"}','{"+empresaEnvio+"}','{"+DireccionEnvio+"}',"+nSeguimiento+","+idCliente+")";
/*SqlCommand comando = new SqlCommand(string.Format("Insert Into orden (noOrden,nombreRemitente,empresaEnvio,direccionEnvio,noSeguimiento,idCliente) " +
    "values ('{0},'{1}','{2}','{3}','{4}','{5}' ", nOrden, nombreRemitente, empresaEnvio, DireccionEnvio, nSeguimiento, idCliente));
retorno = comando.ExecuteNonQuery();
if (retorno >0 )
{
    MessageBox.Show("Lo hicimosssssss");
}
//NpgsqlCommand ejecutor = new NpgsqlCommand(query, dba.getConn()); //(noOrden,nombreRemitente,empresaEnvio,direccionEnvio,noSeguimiento,idCliente)
//ejecutor.ExecuteNonQuery();*/