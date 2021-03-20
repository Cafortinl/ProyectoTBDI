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
        private static string user;

        public VistaCliente(string u)
        {
            InitializeComponent();
            user = u;
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int canti = Convert.ToInt32(VC_Cantidad.Text);
            int idpro = Convert.ToInt32(VC_idproducto.Text);
            if (canti > 0 )
            { 
                NpgsqlDataReader dr;
                dba.open();
                dba.defineQuery("SELECT \"idCliente\" FROM cliente WHERE \"nombreUsuario\" = '"+user+"'");
                dr = dba.executeQuery();
                if (dr.HasRows)
                {
                    dr.Read();
                    int idcliente = Convert.ToInt32(dr[0]);
                    MessageBox.Show("dsa "+idcliente);
                    dba.close();
                    tablacarrito(idcliente,idpro,canti);
                }
            }
            else
            {
                MessageBox.Show("No puede ingresar una cantidad negativa de productos");
            }
        }

        private void TablaProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                int index = TablaProducto.SelectedIndex;
                DataGridRow row = TablaProducto.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                var info = TablaProducto.ItemContainerGenerator.ItemFromContainer(row);
                Producto a = (Producto)info;
                VC_idproducto.Text = Convert.ToString(a.idProducto);
        }

        private void CB_TiendaSeleccionada_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tablaProducto();
        }

        private void tablacarrito(int idcliente, int idpro, int canti)
        {
            NpgsqlDataReader dr;
            dba.open();
            List<TieneEnCarrito> listaOrden = new List<TieneEnCarrito>();
            dba.defineQuery("SELECT * FROM \"tieneEnCarrito\" WHERE \"idCliente\" = " + idcliente);
            dr = dba.executeQuery();
            while (dr.Read())
            {
                listaOrden.Add(new TieneEnCarrito(dr.GetInt32(1), dr.GetInt32(0), dr.GetInt32(2)));
            }
            TablaCarrito.ItemsSource = listaOrden;
            TablaCarrito.CanUserAddRows = false;
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
                listaOrden.Add(new Producto(dr.GetString(1), dr.GetInt32(0), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetDouble(6)));
            }
            TablaProducto.ItemsSource = listaOrden;
            TablaProducto.CanUserAddRows = false;
            dba.close();
            
        }

    }
}

/* NpgsqlDataReader dr;
            dba.open();
            List<String> infoTiend = new List<String>();
            dba.defineQuery("SELECT * FROM tienda");
            dr = dba.executeQuery();
            while (dr.Read())
            {
                infoTiend.Add(Convert.ToString(dr.GetInt32(0)) + " , " + dr.GetString(1));
            }
            CB_TiendaSeleccionada.ItemsSource = infoTiend;
            dba.close();*/