using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;


namespace ProyectoTDBI_Grupo4
{
    /// <summary>
    /// Interaction logic for VistaCliente.xaml
    /// </summary>
    public partial class VistaCliente : Window
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

        public VistaCliente(string u)
        {
            
            InitializeComponent();
            string user = u;
            NpgsqlDataReader dr;
            dba.open();
            List<String> infoTiend = new List<String>();
            dba.defineQuery("SELECT * FROM tienda");
            dr = dba.executeQuery();
            while (dr.Read())
            {
                infoTiend.Add(Convert.ToString(dr.GetInt32(0)) + " , " + dr.GetString(1));
            }
            CB_TiendaSeleccionada.ItemsSource = infoTiend;


            dba.close();
        }

        private void tablaProducto()
        {

            NpgsqlDataReader dr;
            dba.open();
            string idd = (Convert.ToString(CB_TiendaSeleccionada.SelectedItem)).Split(",")[0];
            List<Producto> listaOrden = new List<Producto>();
            dba.defineQuery("SELECT * FROM producto NATURAL JOIN inventario WHERE \"codigoTienda\" = " + idd);
            dr = dba.executeQuery();
            while (dr.Read())
            {
                listaOrden.Add(new Producto(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetDouble(6)));
            }
            TablaProducto.ItemsSource = listaOrden;
            dba.close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NpgsqlDataReader dr;
            dba.open();
            List<String> infoTiend = new List<String>();
            dba.defineQuery("SELECT * FROM tienda");
            dr = dba.executeQuery();
            while (dr.Read())
            {
                infoTiend.Add(Convert.ToString(dr.GetInt32(0)) + " , " + dr.GetString(1));
            }
            CB_TiendaSeleccionada.ItemsSource = infoTiend;
            dba.close();
        }
    }
    }
}
