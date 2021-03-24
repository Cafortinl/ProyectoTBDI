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
        private string var=" ";
        private Inventario inv;

        public Bodega()
        {
            dba.open();
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            NpgsqlDataReader dr;
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
            dba.open();
            string ojayoporco = (Convert.ToString(CB_Bodega.SelectedItem).Split(","))[2];
            if(ojayoporco.StartsWith(' '))
            {
                ojayoporco = ojayoporco.Remove(0, 1);
            }
            NpgsqlDataReader dr;
            List<int> codigoAlmacen = new List<int>();
            dba.defineQuery("SELECT \"codigoAlmacen\" FROM almacen WHERE ciudad='"+ojayoporco+"'");
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
            dba.open();
            NpgsqlDataReader dr;
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
                NpgsqlDataReader dr;
                string ojayoporco = ((string)CB_Bodega.SelectedItem).Split(",")[0];
                idProducto.Text = Convert.ToString(a.idProducto);
                dba.open();
                dba.defineQuery("SELECT \"codigoAlmacen\", \"cantidadInventario\" FROM inventario WHERE \"codigoTienda\" = " + ojayoporco + " AND \"idProducto\"=" + a.idProducto);
                dr = dba.executeQuery();
                if (dr.HasRows)
                {
                    dr.Read();
                    cantidadProducto.Text= Convert.ToString(dr.GetInt32(1));
                    var = Convert.ToString(dr.GetInt32(0));
                    dba.close();
                    int cont = 0;
                    for (int i = 0; i < CB_codigoAlmacen.Items.Count; i++)
                    {
                        if ((int)CB_codigoAlmacen.Items[i]==Convert.ToInt32(var))
                        {
                            break;
                        }
                        cont++;
                    }
                    CB_codigoAlmacen.SelectedIndex = cont;
                    inv = new Inventario(Convert.ToInt32(codigoTienda.Text), Convert.ToInt32(CB_codigoAlmacen.Text), Convert.ToInt32(idProducto.Text), Convert.ToInt32(cantidadProducto.Text));
                }
                else
                {
                    dba.close();
                }
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(cantidadProducto.Text)>0)
            {
                dba.open();
                dba.defineQuery("INSERT INTO inventario VALUES ("+ Convert.ToInt32(codigoTienda.Text) + ","+ (int)CB_codigoAlmacen.SelectedItem +","+ Convert.ToInt32(idProducto.Text) +","+ Convert.ToInt32(cantidadProducto.Text) + ")");
                dba.executeQuery();
                dba.close();
                tablaProducto();
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad valida");
            }
        }

        private void tablaGenerales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dba.open();
            bool abriendo = true;
            int index = tablaGenerales.SelectedIndex;
            DataGridRow row = tablaGenerales.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            var info = tablaGenerales.ItemContainerGenerator.ItemFromContainer(row);
            Producto a = (Producto)info;
            idProducto.Text = Convert.ToString(a.idProducto);
            NpgsqlDataReader dr;
            dba.defineQuery("SELECT \"codigoAlmacen\" FROM inventario WHERE \"idProducto\" = " + a.idProducto + "AND \"codigoTienda\" = " + ultiTienda);
            dr = dba.executeQuery();
            dr.Read();
            if (dr.HasRows)
            {
                abriendo = false;
                dba.close();
                ElMetodoQueFortinJodeParaQueHaga();
            }
            if (abriendo == true)
            {
                dba.close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dba.open();
            dba.defineQuery("DELETE FROM inventario WHERE \"codigoTienda\" ="+Convert.ToInt32(codigoTienda.Text)+" AND \"idProducto\" = "+Convert.ToInt32(idProducto.Text));
            dba.executeQuery();
            dba.close();
            tablaProducto();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (var != " ")
            {
                var = Convert.ToString( CB_codigoAlmacen.SelectedItem);
                dba.open();
                dba.defineQuery("UPDATE inventario SET \"codigoTienda\"=" + Convert.ToInt32(codigoTienda.Text)  + ",\"codigoAlmacen\"=" + Convert.ToInt32(var) + ",\"idProducto\"=" + Convert.ToInt32(idProducto.Text) + ",\"cantidadInventario\"=" +
                Convert.ToInt32(cantidadProducto.Text) + " WHERE \"codigoTienda\"=" + inv.codigoTienda + " AND \"codigoAlmacen\"=" + inv.codigoAlmacen  + " AND \"idProducto\"=" + inv.idProducto +
                "AND \"cantidadInventario\" ="+ inv.cantidadInventario);
                dba.executeQuery();
                dba.close();
                tablaProducto();
            }
        }

        private void CB_codigoAlmacen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }
    }
}