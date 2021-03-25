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
using Npgsql;

namespace ProyectoTDBI_Grupo4
{
    /// <summary>
    /// Interaction logic for Reportes.xaml
    /// </summary>
    public partial class Reportes : Window
    {
        private static string Host = "proyectotdbi.ce6kih4lqvgw.us-east-1.rds.amazonaws.com";
        private static string User = "administrador";
        private static string DBname = "ProyectoTDBI";
        private static string Port = "5432";
        private static string Password = "AdM1n_Pr0yect0#1";
        private static string connString = String.Format(
                "Server={0};Port={1};Database={2};User Id={3};Password={4};",
                Host,
                Port,
                DBname,
                User,
                Password);
        private static DBAdmin dba = new DBAdmin(connString);
        public Reportes()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> reportes = new List<string> { "Envios destruidos", "Cliente estrella", "Principales Dolares", "Principales Ventas", "Agotados Tegucigalpa", "Facturas ultimo mes"};
            cbReportes.ItemsSource = reportes;
        }

        struct ClienteEstrella
        {
            public int idCliente { get; set; }
            public string nombre { get; set; }
            public bool isFrecuente { get; set; }
            public bool isVirtual { get; set; }
            public string direccionFacturacion { get; set; }
            public string nombreUsuario { get; set; }
            public string password { get; set; }
            public int numeroTarjeta { get; set; }
            public string tarjetaHabiente { get; set; }
            public int codigoSeguridad { get; set; }
            public int mesVencimiento { get; set; }
            public int yearVencimiento { get; set; }
            public double total { get; set; }

            public ClienteEstrella(int id, string n, bool f, bool v, string dir, string u, string p, int t, string th, int seg, int mv, int yv, double tot)
            {
                idCliente = id;
                nombre = n;
                isFrecuente = f;
                isVirtual = v;
                direccionFacturacion = dir;
                nombreUsuario = u;
                password = p;
                numeroTarjeta = t;
                tarjetaHabiente = th;
                codigoSeguridad = seg;
                mesVencimiento = mv;
                yearVencimiento = yv;
                total = tot;
            }
        }

        struct ProdDest
        {
            public int idCliente { get; set; }
            public string nombre { get; set; }
            public string nombreUsuario { get; set; }
            public string direccion { get; set; }
            public int noOrden { get; set; }
            public int noSeguimiento { get; set; }

            public ProdDest(int id, string n, string u, string dir, int o, int s)
            {
                idCliente = id;
                nombre = n;
                nombreUsuario = u;
                direccion = dir;
                noOrden = o;
                noSeguimiento = s;
            }

        }

        struct principalDolares
        {
            public int idProducto { get; set; }
            public string nombreProducto { get; set; }
            public string fabricante { get; set; }
            public double total { get; set; }

            public principalDolares(int i, string n, string f, double t)
            {
                idProducto = i;
                nombreProducto = n;
                fabricante = f;
                total = t;
            }
        }
        struct principalVentas
        {
            public int idProducto { get; set; }
            public string nombreProducto { get; set; }
            public string fabricante { get; set; }
            public int cantidad { get; set; }

            public principalVentas(int i, string n, string f, int c)
            {
                idProducto = i;
                nombreProducto = n;
                fabricante = f;
                cantidad = c;
            }
        }

        private void cbReportes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dba.open();
            NpgsqlDataReader dr;
            switch (cbReportes.SelectedItem)
            {
                case "Envios destruidos":
                    List<ProdDest> dest = new List<ProdDest>();
                    dba.defineQuery("SELECT * FROM destruidos");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        dest.Add(new ProdDest(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetInt32(4), dr.GetInt32(5)));
                    }
                    dgReportes.ItemsSource = dest;
                    break;
                case "Cliente estrella":
                    List<ClienteEstrella> clien = new List<ClienteEstrella>();
                    dba.defineQuery("SELECT * FROM \"clienteEstrella\"");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        clien.Add(new ClienteEstrella(dr.GetInt32(0), dr.GetString(1), dr.GetBoolean(2), dr.GetBoolean(3), dr.GetString(4), dr.GetString(5), dr.GetString(6), dr.GetInt32(7), dr.GetString(8), dr.GetInt32(9), dr.GetInt32(10), dr.GetInt32(11), dr.GetDouble(12)));
                    }
                    dgReportes.ItemsSource = clien;
                    break;
                case "Agotados Tegucigalpa":
                    List<Producto> prod = new List<Producto>();
                    dba.defineQuery("SELECT * FROM \"agotadosTegus\"");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        prod.Add(new Producto(dr.GetString(0), dr.GetInt32(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetDouble(6)));
                    }
                    dgReportes.ItemsSource = prod;
                    break;
                case "Facturas ultimo mes":
                    List<Factura> fact = new List<Factura>();
                    dba.defineQuery("SELECT * FROM \"facturasMensuales\"");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        fact.Add(new Factura(dr.GetInt32(0), dr.GetInt32(1), dr.GetString(2), dr.GetString(3), dr.GetInt32(4), dr.GetInt32(5), dr.GetInt32(6)));
                    }
                    dgReportes.ItemsSource = fact;
                    break;
                case "Principales Dolares":
                    List<principalDolares> pd = new List<principalDolares>();
                    dba.defineQuery("SELECT * FROM \"principalesDolares\"");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        pd.Add(new principalDolares(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetDouble(3)));
                    }
                    dgReportes.ItemsSource = pd;
                    break;
                case "Principales Ventas":
                    List<principalVentas> pv = new List<principalVentas>();
                    dba.defineQuery("SELECT * FROM \"principalCant\"");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        pv.Add(new principalVentas(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetInt32(3)));
                    }
                    dgReportes.ItemsSource = pv;
                    break;
            }
            dba.close();
            dgReportes.IsReadOnly = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
