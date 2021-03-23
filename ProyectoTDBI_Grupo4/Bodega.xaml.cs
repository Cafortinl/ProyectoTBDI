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

namespace ProyectoTDBI_Grupo4
{
    /// <summary>
    /// Interaction logic for Bodega.xaml
    /// </summary>
    public partial class Bodega : Window
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
        private int ultiTienda = -1;

        public Bodega()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            NpgsqlDataReader dr;
            dba.open();
            List<String> infoTiend = new List<String>();
            dba.defineQuery("SELECT * FROM tienda");
            dr = dba.executeQuery();
            while (dr.Read())
            {
                infoTiend.Add(Convert.ToString(dr.GetInt32(0)) + " , " + dr.GetString(1));
            }
            CB_Bodega.ItemsSource = infoTiend;
            dba.clearQuery();
            dr = null;
            List<Producto> listaOrden = new List<Producto>();
            dba.defineQuery("SELECT * FROM producto");
            dr = dba.executeQuery();
            while (dr.Read())
            {
                listaOrden.Add(new Producto(dr.GetString(0), dr.GetInt32(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetDouble(6)));
            }
            tablaGenerales.ItemsSource = listaOrden;
            tablaGenerales.CanUserAddRows = false;
            dba.close();
        }
        private void ElMetodoQueFortinJodeParaQueHaga()
        {
            string ojayoporco = ((string)CB_Bodega.SelectedItem).Split(",")[2];
            if (ojayoporco[0].Equals(" "))
            {
                ojayoporco = ojayoporco.Substring(1);
            }
            dba.open();
            NpgsqlDataReader dr;
            List<int> codigoAlmacen = new List<int>();
            dba.defineQuery("SELECT \"codigoAlmacen\" FROM almacen WHERE ciudad = '"+ojayoporco+"'");
            dr = dba.executeQuery();
            while (dr.Read())
            {
                codigoAlmacen.Add(dr.GetInt32(0));
            }
            CB_codigoAlmacen.ItemsSource = codigoAlmacen;
            dba.close();
        }

        private void CB_Bodega_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tablaProducto();
            ElMetodoQueFortinJodeParaQueHaga();
            string ojayoporco = ((string)CB_Bodega.SelectedItem).Split(",")[0];
            codigoTienda.Text = ojayoporco;
        }

        private void tablaProducto()
        {
            NpgsqlDataReader dr;
            dba.open();
            string idd = (Convert.ToString(CB_Bodega.SelectedItem)).Split(",")[0];
            List<Producto> listaOrden = new List<Producto>();
            dba.defineQuery("SELECT * FROM producto NATURAL JOIN inventario WHERE \"codigoTienda\" = " + idd);
            dr = dba.executeQuery();
            while (dr.Read())
            {
                listaOrden.Add(new Producto(dr.GetString(1), dr.GetInt32(0), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetDouble(6)));
            }
            DG_Bodega.ItemsSource = listaOrden;
            DG_Bodega.CanUserAddRows = false;
            dba.close();

        }

        private void DG_Bodega_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = DG_Bodega.SelectedIndex;
            if (index > -1)
            {
                DataGridRow row = DG_Bodega.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                var info = DG_Bodega.ItemContainerGenerator.ItemFromContainer(row);
                Producto a = (Producto)info;
                idProducto.Text = Convert.ToString(a.idProducto);
                NpgsqlDataReader dr;
                dba.open();
                string ojayoporco = ((string)CB_Bodega.SelectedItem).Split(",")[0];
                //codigoTienda.Text = ojayoporco;
                //ultiTienda = Convert.ToInt32(ojayoporco);
                dba.defineQuery("SELECT \"codigoAlmacen\" FROM inventario WHERE \"codigoTienda\" = " + ojayoporco);
                dr = dba.executeQuery();
                if (dr.HasRows)
                {
                    dr.Read();
                    ElMetodoQueFortinJodeParaQueHaga();
                    dba.close();
                }
            }
            else
            {
                ElMetodoQueFortinJodeParaQueHaga();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tablaGenerales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = tablaGenerales.SelectedIndex;
            DataGridRow row = tablaGenerales.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            var info = tablaGenerales.ItemContainerGenerator.ItemFromContainer(row);
            Producto a = (Producto)info;
            idProducto.Text = Convert.ToString(a.idProducto);
            NpgsqlDataReader dr;
            dba.open();
            dba.defineQuery("SELECT \"codigoAlmacen\" FROM inventario WHERE \"idProducto\" = " + a.idProducto + "AND \"codigoTienda\" = " + ultiTienda);
            dr = dba.executeQuery();
            dr.Read();
            if (dr.HasRows)
            {
                ElMetodoQueFortinJodeParaQueHaga();
            }
            dba.close();
        }
    }
}