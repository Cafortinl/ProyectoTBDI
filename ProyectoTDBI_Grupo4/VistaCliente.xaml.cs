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
        private static string user, dirreccionFac, idd;
        private static int idcliente;

        public VistaCliente(string u)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
            dba.clearQuery();
            dr = null;
            dba.defineQuery("SELECT \"idCliente\",\"direccionFacturacion\" FROM cliente WHERE \"nombreUsuario\" = '" + user + "'");
            dr = dba.executeQuery();
            if (dr.HasRows)
            {
                dr.Read();
                idcliente = Convert.ToInt32(dr[0]);
                dirreccionFac = Convert.ToString(dr[1]);
                dba.close();
                tablacarrito();
            }
            else
            {
                dba.close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int canti = Convert.ToInt32(VC_Cantidad.Text);
            int idpro = Convert.ToInt32(VC_idproducto.Text);
            if (canti > 0 )
            {
                NpgsqlDataReader dr;
                dba.open();
                dba.defineQuery("SELECT 1 FROM \"tieneEnCarrito\" WHERE \"idCliente\" = " + idcliente + " AND \"idProducto\" ="+idpro);
                dr= dba.executeQuery();
                if (dr.HasRows)
                {
                    dba.clearQuery();
                    dr = null;
                    dba.defineQuery("SELECT \"cantidadProductoCarrito\" FROM \"tieneEnCarrito\" WHERE \"idCliente\" = " + idcliente + " AND \"idProducto\" =" + idpro);
                    dr = dba.executeQuery();
                    dr.Read();
                    int cantidad = dr.GetInt32(0);
                    cantidad += canti;
                    dba.clearQuery();
                    dba.defineQuery("UPDATE \"tieneEnCarrito\" SET \"cantidadProductoCarrito\"="+cantidad+ "WHERE \"idCliente\" = " + idcliente + " AND \"idProducto\" =" + idpro);
                    dba.executeQuery();
                }
                else
                {
                    dba.clearQuery();
                    dba.defineQuery("INSERT INTO  \"tieneEnCarrito\" VALUES (" + idcliente + "," + idpro + "," + canti + ")");
                    dba.executeQuery();
                }
                dba.close();
                tablacarrito();
            }
            else
            {
                MessageBox.Show("No puede ingresar una cantidad negativa de productos");
            }
        }

        private void TablaProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                int index = TablaProducto.SelectedIndex;
               if (index != -1)
            {
                DataGridRow row = TablaProducto.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                var info = TablaProducto.ItemContainerGenerator.ItemFromContainer(row);
                Producto a = (Producto)info;
                VC_idproducto.Text = Convert.ToString(a.idProducto);
            }
        }

        private void CB_TiendaSeleccionada_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tablaProducto();
        }

        private void tablacarrito()
        {
            NpgsqlDataReader dr;
            dba.open();
            List <TieneEnCarrito> listaOrden = new List<TieneEnCarrito>();
            dba.defineQuery("SELECT * FROM \"tieneEnCarrito\" WHERE \"idCliente\" = " + idcliente);
            dr = dba.executeQuery();
            while (dr.Read())
            {
                listaOrden.Add(new TieneEnCarrito(dr.GetInt32(0), dr.GetInt32(1), dr.GetInt32(2)));
            }
            TablaCarrito.ItemsSource = listaOrden;
            TablaCarrito.CanUserAddRows = false;
            dba.close();
        }

        private void tablaProducto()
        {
            NpgsqlDataReader dr;
            dba.open();
             idd = (Convert.ToString(CB_TiendaSeleccionada.SelectedItem)).Split(",")[0];
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = TablaCarrito.SelectedIndex;
            DataGridRow row = TablaCarrito.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            var info = TablaCarrito.ItemContainerGenerator.ItemFromContainer(row);
            dba.open();
            TieneEnCarrito carr = (TieneEnCarrito)info;
            MessageBox.Show("idcliente g: "+idcliente+" , id: "+ carr.idCliente+" , prod: "+carr.idProducto);
            dba.defineQuery("DELETE FROM \"tieneEnCarrito\" WHERE \"idCliente\"=" + carr.idCliente + " AND \"idProducto\"=" + carr.idProducto);
            dba.executeQuery();
            dba.close();
            tablacarrito();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dba.open();
            dba.defineQuery("DELETE  FROM \"tieneEnCarrito\" WHERE \"idCliente\"="+idcliente );
            dba.executeQuery();
            dba.close();
            tablacarrito();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NpgsqlDataReader dr;
            List<DetalleFactura> detta = new List<DetalleFactura>();
            double subtotal = 0, fijosub = 0;
            string productos="";
            int numFact = 0, nor = 0;
            dba.open();
            dba.defineQuery("SELECT COUNT (\"noFactura\") FROM factura");
            dr = dba.executeQuery();
            if (dr.HasRows)
            {
                dr.Read();
                numFact = dr.GetInt32(0) + 1;
            }
            dba.clearQuery();
            dr = null;
            dba.defineQuery("SELECT precio,\"cantidadProductoCarrito\",\"nombreProducto\",\"idProducto\" FROM producto NATURAL JOIN (SELECT * FROM \"tieneEnCarrito\" WHERE  \"idCliente\" = " + idcliente+") AS carritoo");
            dr = dba.executeQuery();
            while (dr.Read())
            {
                subtotal += dr.GetDouble(0)*dr.GetInt32(1);
                fijosub = dr.GetDouble(0) * dr.GetInt32(1);
                productos +=">"+ dr.GetString(2)+" ("+dr.GetInt32(1)+")...."+ dr.GetDouble(0) * dr.GetInt32(1) + "\n";
                detta.Add(new DetalleFactura(numFact, (fijosub+fijosub*0.15) ,(fijosub*0.15) ,dr.GetInt32(1), dr.GetInt32(3),fijosub));
            }
            dba.clearQuery();
            dr = null;
            DateTime dateTime = DateTime.UtcNow.Date;
            dba.defineQuery("INSERT INTO factura VALUES (" + numFact + "," + Convert.ToInt32(idd) + ",'" + dateTime.ToString("dd/MM/yy") + "','" + dirreccionFac + "'," + idcliente + "," + Convert.ToInt32(idd) + "," + nor + ")");
            dba.executeQuery();
            dr = null;
            for (int i = 0; i < detta.Count; i++)
            {
                dba.clearQuery();
                dba.defineQuery("INSERT INTO \"detalleFactura\" VALUES ("+ detta[i].noFactura + ","+detta[i].total+","+detta[i].isv+","+detta[i].cantidadProducto+","+detta[i].idProducto+","+detta[i].subtotal+")");
                dba.executeQuery();
            }
            dba.clearQuery();
            dba.defineQuery("SELECT COUNT (\"noOrden\") FROM orden");
            dr = dba.executeQuery();
            if (dr.HasRows)
            {
                dr.Read();
                nor = dr.GetInt32(0) + 1;
            }
            dba.clearQuery();
            dba.defineQuery("INSERT INTO orden VALUES(" + nor + ",'" + user + "','FedEx','" + dirreccionFac + "'," + nor + "," + idcliente + ",'En espera')");
            dba.executeQuery();
            dba.clearQuery();
            MessageBox.Show("<-------|MENOSOTIRA|------->\n\nSus Productos:\n" +productos+"\n SUBTOTAL:  "+ subtotal +"\nTOTAL:  "+(subtotal+subtotal*0.15)+ "\n\n< --|Disfrute su compra :D |--->");
            dba.defineQuery("DELETE  FROM \"tieneEnCarrito\" WHERE \"idCliente\"=" + idcliente);
            dba.executeQuery();
            dba.close();
            tablacarrito();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

