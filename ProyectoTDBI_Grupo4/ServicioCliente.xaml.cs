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
    /// Interaction logic for ServicioCliente.xaml
    /// </summary>
    public partial class ServicioCliente : Window
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

        public ServicioCliente()
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
            SC_TiendaSeleccionada.ItemsSource = infoTiend;
            dba.close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dba.open();
            NpgsqlDataReader dr;
            List<Producto> listaOrden = new List<Producto>();
            List<Tienda> listaTienda = new List<Tienda>();
            bool flag = false;
            string idd = (Convert.ToString(SC_TiendaSeleccionada.SelectedItem)).Split(",")[2];
            if (idd[0].Equals(" "))
            {
                idd = idd.Substring(1);
            }
            dba.defineQuery("select * from producto natural join (select * from inventario natural join (select * from tienda where ubicacion like '%"+idd+"') " +
                "as cercanas where \"cantidadInventario\" > 0) as tiendas where \"idProducto\"= "+Convert.ToInt32(tx_idproducto.Text));
            dr = dba.executeQuery();
            while (dr.Read())
            {
                Producto var = new Producto(dr.GetString(1), dr.GetInt32(0), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetDouble(6));
                if (!flag)
                {
                    listaOrden.Add(var);
                    flag = true;
                }
                listaTienda.Add(new Tienda(dr.GetInt32(7),dr.GetString(10)));

            }
            Tablaproducto.ItemsSource = listaOrden;
            tablaTiendas.ItemsSource = listaTienda;
            tablaTiendas.CanUserAddRows = false;
            Tablaproducto.CanUserAddRows = false;
            dba.close();
        }

    }
}
