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
    /// Interaction logic for ModificarTabla.xaml
    /// </summary>
    public partial class ModificarTabla : Window
    {

        private static int opcion;
        private static int tablaSelec;
        private static object elemento;
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
        public ModificarTabla(int op, int tabla, object elem)
        {
            InitializeComponent();
            opcion = op;
            tablaSelec = tabla;
            elemento = elem;
            switch (opcion)
            {
                case 1://agregar
                    switch (tablaSelec)
                    {
                        case 1:
                            List<Almacen> listaAlmacen = new List<Almacen>();
                            listaAlmacen.Add(new Almacen());
                            MessageBox.Show(listaAlmacen.Count.ToString());
                            dgAgrEdit.ItemsSource = listaAlmacen;
                            break;
                        case 2:
                            List<Categoria> listaCateg = new List<Categoria>();
                            listaCateg.Add(new Categoria());
                            dgAgrEdit.ItemsSource = listaCateg;
                            break;
                        case 3:
                            List<Cliente> listaClien = new List<Cliente>();
                            listaClien.Add(new Cliente());
                            dgAgrEdit.ItemsSource = listaClien;
                            break;
                        case 4:
                            List<Contrato> listaCont = new List<Contrato>();
                            listaCont.Add(new Contrato());
                            dgAgrEdit.ItemsSource = listaCont;
                            break;
                        case 5:
                            List<DetalleFactura> listaDet = new List<DetalleFactura>();
                            listaDet.Add(new DetalleFactura());
                            dgAgrEdit.ItemsSource = listaDet;
                            break;
                        case 6:
                            List<Factura> listaFact = new List<Factura>();
                            listaFact.Add(new Factura());
                            dgAgrEdit.ItemsSource = listaFact;
                            break;
                        case 7:
                            List<Inventario> listaInv = new List<Inventario>();
                            listaInv.Add(new Inventario());
                            dgAgrEdit.ItemsSource = listaInv;
                            break;
                        case 8:
                            List<Orden> listaOrd = new List<Orden>();
                            listaOrd.Add(new Orden());
                            dgAgrEdit.ItemsSource = listaOrd;
                            break;
                        case 9:
                            List<Producto> listaProd = new List<Producto>();
                            listaProd.Add(new Producto());
                            dgAgrEdit.ItemsSource = listaProd;
                            break;
                        case 10:
                            List<Tienda> listaTien = new List<Tienda>();
                            listaTien.Add(new Tienda());
                            dgAgrEdit.ItemsSource = listaTien;
                            break;
                        case 11:
                            List<TieneEnCarrito> listaCarr = new List<TieneEnCarrito>();
                            listaCarr.Add(new TieneEnCarrito());
                            dgAgrEdit.ItemsSource = listaCarr;
                            break;
                    }
                    break;
                case 2://modificar
                    switch (tablaSelec)
                    {
                        case 1:
                            List<Almacen> listaAlmacen = new List<Almacen>();
                            listaAlmacen.Add((Almacen)elemento);
                            dgAgrEdit.ItemsSource = listaAlmacen;
                            break;
                        case 2:
                            List<Categoria> listaCateg = new List<Categoria>();
                            listaCateg.Add((Categoria)elemento);
                            dgAgrEdit.ItemsSource = listaCateg;
                            break;
                        case 3:
                            List<Cliente> listaClien = new List<Cliente>();
                            listaClien.Add((Cliente)elemento);
                            dgAgrEdit.ItemsSource = listaClien;
                            break;
                        case 4:
                            List<Contrato> listaCont = new List<Contrato>();
                            listaCont.Add((Contrato)elemento);
                            dgAgrEdit.ItemsSource = listaCont;
                            break;
                        case 5:
                            List<DetalleFactura> listaDet = new List<DetalleFactura>();
                            listaDet.Add((DetalleFactura)elemento);
                            dgAgrEdit.ItemsSource = listaDet;
                            break;
                        case 6:
                            List<Factura> listaFact = new List<Factura>();
                            listaFact.Add((Factura)elemento);
                            dgAgrEdit.ItemsSource = listaFact;
                            break;
                        case 7:
                            List<Inventario> listaInv = new List<Inventario>();
                            listaInv.Add((Inventario)elemento);
                            dgAgrEdit.ItemsSource = listaInv;
                            break;
                        case 8:
                            List<Orden> listaOrd = new List<Orden>();
                            listaOrd.Add((Orden)elemento);
                            dgAgrEdit.ItemsSource = listaOrd;
                            break;
                        case 9:
                            List<Producto> listaProd = new List<Producto>();
                            listaProd.Add((Producto)elemento);
                            dgAgrEdit.ItemsSource = listaProd;
                            break;
                        case 10:
                            List<Tienda> listaTien = new List<Tienda>();
                            listaTien.Add((Tienda)elemento);
                            dgAgrEdit.ItemsSource = listaTien;
                            break;
                        case 11:
                            List<TieneEnCarrito> listaCarr = new List<TieneEnCarrito>();
                            listaCarr.Add((TieneEnCarrito)elemento);
                            dgAgrEdit.ItemsSource = listaCarr;
                            break;
                    }
                    break;
            }
            dgAgrEdit.CanUserAddRows = false;
        }

        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {
            dba.open();
            NpgsqlDataReader dr;
            int index = 0;
            DataGridRow row = dgAgrEdit.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            var info = dgAgrEdit.ItemContainerGenerator.ItemFromContainer(row);
            //for(int i = 0;i < ((DataGridRow)info).)
            switch (opcion)
            {
                case 1:
                    switch (tablaSelec)
                    {
                        case 1:
                            Almacen a = (Almacen)info;
                            dba.defineQuery("SELECT 1 from almacen WHERE \"codigoAlmacen\"=" + a.codigoAlmacen);
                            dr = dba.executeQuery();
                            if (!dr.HasRows)
                            {
                                dba.clearQuery();
                                dr = null;
                                dba.defineQuery("INSERT INTO almacen VALUES(" + a.codigoAlmacen + ",'" + a.ciudad + "')");
                            }
                            else
                                MessageBox.Show("No puede repetir la llave de una tabla");
                            break;
                        case 2:
                            Categoria cat = (Categoria)info;
                            dba.defineQuery("SELECT 1 from categoria WHERE \"idProducto\"=" + cat.idProducto + "AND \"nombreCategoria\"='" + cat.nombreCategoria + "'");
                            dr = dba.executeQuery();
                            if (!dr.HasRows)
                            {
                                dba.clearQuery();
                                dr = null;
                                dba.defineQuery("INSERT INTO categoria VALUES(" + cat.idProducto + ",'" + cat.nombreCategoria + "')");
                            }
                            else
                                MessageBox.Show("No puede repetir la llave de una tabla");
                            break;
                        case 3:
                            Cliente clien = (Cliente)info;
                            dba.defineQuery("SELECT 1 from cliente WHERE \"idCliente\"=" + clien.idCliente);
                            dr = dba.executeQuery();
                            if (!dr.HasRows)
                            {
                                dba.clearQuery();
                                dr = null;
                                dba.defineQuery("INSERT INTO cliente VALUES(" + clien.idCliente + ",'" + clien.nombre + "'," + clien.isFrecuente + "," + clien.isVirtual + ",'" + clien.direccionFacturacion + "','" + clien.nombreUsuario + "','" + clien.password + "'," + clien.numeroTarjeta + ",'" + clien.tarjetaHabiente + "'," + clien.codigoSeguridad + "," + clien.mesVencimiento + "," + clien.yearVencimiento);
                            }
                            else
                                MessageBox.Show("No puede repetir la llave de una tabla");
                            break;
                        case 4:
                            Contrato cont = (Contrato)info;
                            dba.defineQuery("SELECT 1 from contrato WHERE \"noCuenta\"=" + cont.noCuenta);
                            dr = dba.executeQuery();
                            if (!dr.HasRows)
                            {
                                dba.clearQuery();
                                dr = null;
                                dba.defineQuery("INSERT INTO contrato VALUES(" + cont.noCuenta + "," + cont.cuota + ","+ cont.idCliente + ")");
                            }
                            else
                                MessageBox.Show("No puede repetir la llave de una tabla");
                            break;
                        case 5:
                            DetalleFactura det = (DetalleFactura)info;
                            dba.defineQuery("SELECT 1 from \"detalleFactura\" WHERE \"noFactura\"=" + det.noFactura);
                            dr = dba.executeQuery();
                            if (!dr.HasRows)
                            {
                                dba.clearQuery();
                                dr = null;
                                //dba.defineQuery("INSERT INTO \"detalleFactura\" VALUES(" + cat.idProducto + ",'" + cat.nombreCategoria + "')");
                            }
                            else
                                MessageBox.Show("No puede repetir la llave de una tabla");
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                    }
                    break;
                case 2:
                    switch (tablaSelec)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                    }
                    break;
            }
            dba.executeQuery();
            dba.close();
        }
    }
}
