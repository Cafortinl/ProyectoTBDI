using System;
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
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            tablaOrden();
            tablaCliente();
            nOrdenYnSeguimiento();
        }

        private void Cll_BtCompra_Click(object sender, RoutedEventArgs e)
        {
            dba.open();
            dba.defineQuery("INSERT INTO orden VALUES("+Convert.ToInt32(Cll_nOrden.Text)+ ",'"+ Cll_nRemitente.Text +"','"+ Cll_EmpresaEnvio.Text+"','"+ Cll_DirreccionEnvio.Text+"',"+ Convert.ToInt32(Cll_nSeguimiento.Text)+","+ Convert.ToInt32(Cll_idCliente.Text)+",'En espera')");
            dba.executeQuery();
            dba.close();
            Cll_idCliente.Text = "";
            Cll_nOrden.Text = "";
            Cll_nSeguimiento.Text = "";
            Cll_nRemitente.Text = "";
            Cll_EmpresaEnvio.Text = "";
            Cll_DirreccionEnvio.Text = "";
            tablaOrden();
            nOrdenYnSeguimiento();
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
                listaOrden.Add(new Orden(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetInt32(4), dr.GetInt32(5), dr.GetString(6)));
            }
            DataGrid_Orden.ItemsSource = listaOrden;
            DataGrid_Orden.CanUserAddRows = false;
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
            DataGrid_Clientes.CanUserAddRows = false;
            dba.close();
           
        }

        private void DataGrid_Clientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = DataGrid_Clientes.SelectedIndex;
            DataGridRow row = DataGrid_Clientes.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            var info = DataGrid_Clientes.ItemContainerGenerator.ItemFromContainer(row);
            Cliente a = (Cliente)info;
            Cll_idCliente.Text = Convert.ToString(a.idCliente);
        }

        private void nOrdenYnSeguimiento()
        {
            dba.open();
            NpgsqlDataReader dr;
            dba.defineQuery("SELECT COUNT (\"noOrden\") FROM orden");
            dr = dba.executeQuery();
            if (dr.HasRows)
            {
                dr.Read();
                Cll_nOrden.Text=Convert.ToString(dr.GetInt32(0)+1);
                Cll_nSeguimiento.Text = Convert.ToString(dr.GetInt32(0)+1);
            }
            dba.close();
        }
    }
}