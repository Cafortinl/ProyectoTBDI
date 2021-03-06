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
using System.Collections.ObjectModel;

namespace ProyectoTDBI_Grupo4
{
    /// <summary>
    /// Interaction logic for adminView.xaml
    /// </summary>
    public partial class adminView : Window
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
        public adminView()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> tablas = new List<string> {"Almacen", "Categoria", "Cliente", "Contrato", "DetalleFactura", "Factura", "Inventario", "Orden", "Producto", "Tienda", "TieneEnCarrito"};
            cbTablaSelec.ItemsSource = tablas;
        }

        private void btLogoff_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
         
        private void cbTablaSelec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateTable();
        }

        public void updateTable()
        {
            NpgsqlDataReader dr;
            dba.open();
            switch (cbTablaSelec.SelectedItem)
            {
                case "Almacen":
                    List<Almacen> infoAlmacen = new List<Almacen>();
                    dba.defineQuery("SELECT * FROM almacen");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        infoAlmacen.Add(new Almacen(dr.GetInt32(0), dr.GetString(1)));
                    }
                    dgInfo.ItemsSource = infoAlmacen;
                    break;
                case "Categoria":
                    List<Categoria> infoCateg = new List<Categoria>();
                    dba.defineQuery("SELECT * FROM categoria");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        infoCateg.Add(new Categoria(dr.GetInt32(0), dr.GetString(1)));
                    }
                    dgInfo.ItemsSource = infoCateg;
                    break;
                case "Cliente":
                    List<Cliente> infoClien = new List<Cliente>();
                    dba.defineQuery("SELECT * FROM cliente");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        infoClien.Add(new Cliente(dr.GetInt32(0), dr.GetString(1), dr.GetBoolean(2), dr.GetBoolean(3), dr.GetString(4), dr.GetString(5), dr.GetString(6), dr.GetInt32(7), dr.GetString(8), dr.GetInt32(9), dr.GetInt32(10), dr.GetInt32(11)));
                    }
                    dgInfo.ItemsSource = infoClien;

                    break;
                case "Contrato":
                    List<Contrato> infoContrat = new List<Contrato>();
                    dba.defineQuery("SELECT * FROM contrato");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        infoContrat.Add(new Contrato(dr.GetInt32(0), dr.GetDouble(1), dr.GetInt32(2)));
                    }
                    dgInfo.ItemsSource = infoContrat;
                    break;
                case "DetalleFactura":
                    List<DetalleFactura> infoDetFac = new List<DetalleFactura>();
                    dba.defineQuery("SELECT * FROM \"detalleFactura\"");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        infoDetFac.Add(new DetalleFactura(dr.GetInt32(0), dr.GetDouble(1), dr.GetDouble(2), dr.GetInt32(3), dr.GetInt32(4), dr.GetDouble(5)));
                    }
                    dgInfo.ItemsSource = infoDetFac;
                    break;
                case "Factura":
                    List<Factura> infoFac = new List<Factura>();
                    dba.defineQuery("SELECT * FROM factura");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        infoFac.Add(new Factura(dr.GetInt32(0), dr.GetInt32(1), dr.GetString(2), dr.GetString(3), dr.GetInt32(4), dr.GetInt32(5), dr.GetInt32(6)));
                    }
                    dgInfo.ItemsSource = infoFac;
                    break;
                case "Inventario":
                    List<Inventario> infoInv = new List<Inventario>();
                    dba.defineQuery("SELECT * FROM inventario");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        infoInv.Add(new Inventario(dr.GetInt32(0), dr.GetInt32(1), dr.GetInt32(2), dr.GetInt32(3)));
                    }
                    dgInfo.ItemsSource = infoInv;
                    break;
                case "Orden":
                    List<Orden> infoOrd = new List<Orden>();
                    dba.defineQuery("SELECT * FROM orden");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        infoOrd.Add(new Orden(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetInt32(4), dr.GetInt32(5), dr.GetString(6)));
                    }
                    dgInfo.ItemsSource = infoOrd;
                    break;
                case "Producto":
                    List<Producto> infoProd = new List<Producto>();
                    dba.defineQuery("SELECT * FROM producto");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        infoProd.Add(new Producto(dr.GetString(0), dr.GetInt32(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetDouble(6)));
                    }
                    dgInfo.ItemsSource = infoProd;
                    break;
                case "Tienda":
                    List<Tienda> infoTiend = new List<Tienda>();
                    dba.defineQuery("SELECT * FROM tienda");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        infoTiend.Add(new Tienda(dr.GetInt32(0), dr.GetString(1)));
                    }
                    dgInfo.ItemsSource = infoTiend;
                    break;
                case "TieneEnCarrito":
                    List<TieneEnCarrito> infoCarr = new List<TieneEnCarrito>();
                    dba.defineQuery("SELECT * FROM \"tieneEnCarrito\"");
                    dr = dba.executeQuery();
                    while (dr.Read())
                    {
                        infoCarr.Add(new TieneEnCarrito(dr.GetInt32(0), dr.GetInt32(1), dr.GetInt32(2)));
                    }
                    dgInfo.ItemsSource = infoCarr;
                    break;
            }
            dba.close();
            dgInfo.IsReadOnly = true;
        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            int index = dgInfo.SelectedIndex;
            if (index > -1)
            {
                DataGridRow row = dgInfo.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                var info = dgInfo.ItemContainerGenerator.ItemFromContainer(row);
                dba.open();
                switch (cbTablaSelec.SelectedItem)
                {
                    case "Almacen":
                        Almacen a = (Almacen)info;
                        dba.defineQuery("DELETE FROM almacen WHERE \"codigoAlmacen\"=" + Convert.ToString(a.codigoAlmacen));
                        break;
                    case "Categoria":
                        Categoria cat = (Categoria)info;
                        dba.defineQuery("DELETE FROM categoria WHERE \"idProducto\"=" + Convert.ToString(cat.idProducto) + " AND \"nombreCategoria\"='" + cat.nombreCategoria + "'");
                        break;
                    case "Cliente":
                        Cliente clien = (Cliente)info;
                        dba.defineQuery("DELETE FROM cliente WHERE \"idCliente\"=" + Convert.ToString(clien.idCliente));
                        break;
                    case "Contrato":
                        Contrato cont = (Contrato)info;
                        dba.defineQuery("DELETE FROM contrato WHERE \"noCuenta\"=" + Convert.ToString(cont.noCuenta));
                        break;
                    case "DetalleFactura":
                        DetalleFactura det = (DetalleFactura)info;
                        dba.defineQuery("DELETE FROM \"detalleFactura\" WHERE \"noFactura\"=" + Convert.ToString(det.noFactura));
                        break;
                    case "Factura":
                        Factura fact = (Factura)info;
                        dba.defineQuery("DELETE FROM factura WHERE \"noFactura\"=" + Convert.ToString(fact.noFactura));
                        break;
                    case "Inventario":
                        Inventario inv = (Inventario)info;
                        dba.defineQuery("DELETE FROM inventario WHERE \"codigoTienda\"=" + Convert.ToString(inv.codigoTienda) + " AND \"codigoAlmacen\"=" + inv.codigoAlmacen + " AND \"idProducto\"=" + inv.idProducto);
                        break;
                    case "Orden":
                        Orden ord = (Orden)info;
                        dba.defineQuery("DELETE FROM orden WHERE \"noOrden\"=" + Convert.ToString(ord.noOrden));
                        break;
                    case "Producto":
                        Producto prod = (Producto)info;
                        dba.defineQuery("DELETE FROM producto WHERE \"idProducto\"=" + Convert.ToString(prod.idProducto));
                        break;
                    case "Tienda":
                        Tienda tien = (Tienda)info;
                        dba.defineQuery("DELETE FROM tienda WHERE \"codigoTienda\"=" + Convert.ToString(tien.codigoTienda));
                        break;
                    case "TieneEnCarrito":
                        TieneEnCarrito carr = (TieneEnCarrito)info;
                        dba.defineQuery("DELETE FROM \"tieneEnCarrito\" WHERE \"idCliente\"=" + Convert.ToString(carr.idCliente) + " AND \"idProducto\"=" + carr.idProducto);
                        break;
                }
                    dba.executeQuery();
                    dba.close();
                    updateTable();
            }
            else
                MessageBox.Show("Debe seleccionar un elemento para poder eliminarlo.");
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            ModificarTabla mt;
            switch (cbTablaSelec.SelectedItem)
            {
                case "Almacen":
                    mt = new ModificarTabla(1, 1, null, this);
                    mt.Show();
                    break;
                case "Categoria":
                    mt = new ModificarTabla(1, 2, null, this);
                    mt.Show();
                    break;
                case "Cliente":
                    mt = new ModificarTabla(1, 3, null, this);
                    mt.Show();
                    break;
                case "Contrato":
                    mt = new ModificarTabla(1, 4, null, this);
                    mt.Show();
                    break;
                case "DetalleFactura":
                    mt = new ModificarTabla(1, 5, null, this);
                    mt.Show();
                    break;
                case "Factura":
                    mt = new ModificarTabla(1, 6, null, this);
                    mt.Show();
                    break;
                case "Inventario":
                    mt = new ModificarTabla(1, 7, null, this);
                    mt.Show();
                    break;
                case "Orden":
                    mt = new ModificarTabla(1, 8, null, this);
                    mt.Show();
                    break;
                case "Producto":
                    mt = new ModificarTabla(1, 9, null, this);
                    mt.Show();
                    break;
                case "Tienda":
                    mt = new ModificarTabla(1, 10, null, this);
                    mt.Show();
                    break;
                case "TieneEnCarrito":
                    mt = new ModificarTabla(1, 11, null, this);
                    mt.Show();
                    break;
            }
        }

        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            int index = dgInfo.SelectedIndex;
            if (index > -1)
            {
                DataGridRow row = dgInfo.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                var info = dgInfo.ItemContainerGenerator.ItemFromContainer(row);
                ModificarTabla mt;
                switch (cbTablaSelec.SelectedItem)
                {
                    case "Almacen":
                        mt = new ModificarTabla(2, 1, info, this);
                        mt.Show();
                        break;
                    case "Categoria":
                        mt = new ModificarTabla(2, 2, info, this);
                        mt.Show();
                        break;
                    case "Cliente":
                        mt = new ModificarTabla(2, 3, info, this);
                        mt.Show();
                        break;
                    case "Contrato":
                        mt = new ModificarTabla(2, 4, info, this);
                        mt.Show();
                        break;
                    case "DetalleFactura":
                        mt = new ModificarTabla(2, 5, info, this);
                        mt.Show();
                        break;
                    case "Factura":
                        mt = new ModificarTabla(2, 6, info, this);
                        mt.Show();
                        break;
                    case "Inventario":
                        mt = new ModificarTabla(2, 7, info, this);
                        mt.Show();
                        break;
                    case "Orden":
                        mt = new ModificarTabla(2, 8, info, this);
                        mt.Show();
                        break;
                    case "Producto":
                        mt = new ModificarTabla(2, 9, info, this);
                        mt.Show();
                        break;
                    case "Tienda":
                        mt = new ModificarTabla(2, 10, info, this);
                        mt.Show();
                        break;
                    case "TieneEnCarrito":
                        mt = new ModificarTabla(2, 11, info, this);
                        mt.Show();
                        break;
                }
            }
            else
                MessageBox.Show("Debe seleccionar un elemento para poder modificarlo.");
        }

        private void btEmpleados_Click(object sender, RoutedEventArgs e)
        {
            Empleados emp = new Empleados();
            emp.Show();
        }

        private void btReportes_Click(object sender, RoutedEventArgs e)
        {
            Reportes rep = new Reportes();
            rep.Show();
        }
    }
}
