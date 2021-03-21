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
        private static adminView av;
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
        public ModificarTabla(int op, int tabla, object elem, adminView avi)
        {
            InitializeComponent();
            av = avi;
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
                                if (!a.hasNullElem())
                                {
                                    dba.clearQuery();
                                    dr = null;
                                    dba.defineQuery("INSERT INTO almacen VALUES(" + a.codigoAlmacen + ",'" + a.ciudad + "')");
                                }
                                else
                                    MessageBox.Show("No puede dejar campos en blanco.");
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
                                if (!cat.hasNullElem())
                                {
                                    dba.clearQuery();
                                    dr = null;
                                    dba.defineQuery("INSERT INTO categoria VALUES(" + cat.idProducto + ",'" + cat.nombreCategoria + "')");
                                }else
                                    MessageBox.Show("No puede dejar campos en blanco.");
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
                                if (!clien.hasNullElem())
                                {
                                    dba.clearQuery();
                                    dr = null;
                                    dba.defineQuery("INSERT INTO cliente VALUES(" + clien.idCliente + ",'" + clien.nombre + "'," + clien.isFrecuente + "," + clien.isVirtual + ",'" + clien.direccionFacturacion + "','" + clien.nombreUsuario + "','" + clien.password + "'," + clien.numeroTarjeta + ",'" + clien.tarjetaHabiente + "'," + clien.codigoSeguridad + "," + clien.mesVencimiento + "," + clien.yearVencimiento);
                                }else
                                    MessageBox.Show("No puede dejar campos en blanco.");
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
                                if (!det.hasNullElem())
                                {
                                    dba.clearQuery();
                                    dr = null;
                                    dba.defineQuery("INSERT INTO \"detalleFactura\" VALUES(" + det.noFactura + "," + det.total + "," + det.isv + "," + det.cantidadProducto + "," + det.idProducto + "," + det.subtotal + ")");
                                }else
                                    MessageBox.Show("No puede dejar campos en blanco.");
                            }
                            else
                                MessageBox.Show("No puede repetir la llave de una tabla");
                            break;
                        case 6:
                            Factura fact = (Factura)info;
                            dba.defineQuery("SELECT 1 from factura WHERE \"noFactura\"=" + fact.noFactura);
                            dr = dba.executeQuery();
                            if (!dr.HasRows)
                            {
                                if (!fact.hasNullElem())
                                {
                                    dba.clearQuery();
                                    dr = null;
                                    dba.defineQuery("INSERT INTO factura VALUES(" + fact.noFactura + "," + fact.RTN + ",'" + fact.fechaEmision + "','" + fact.direccion + "'," + fact.idCliente + "," + fact.codigoTienda + ")");
                                }else
                                    MessageBox.Show("No puede dejar campos en blanco.");
                            }
                            else
                                MessageBox.Show("No puede repetir la llave de una tabla");
                            break;
                        case 7:
                            Inventario inv = (Inventario)info;
                            dba.defineQuery("SELECT 1 from inventario WHERE \"codigoTienda\"=" + inv.codigoTienda + " AND \"codigoAlmacen\"=" + inv.codigoAlmacen + " AND \"idProducto\"=" + inv.idProducto);
                            dr = dba.executeQuery();
                            if (!dr.HasRows)
                            {
                                dba.clearQuery();
                                dr = null;
                                dba.defineQuery("INSERT INTO inventario VALUES(" + inv.codigoTienda + "," + inv.codigoAlmacen + "," + inv.idProducto + "," + inv.cantidadInventario + ")");
                            }
                            else
                                MessageBox.Show("No puede repetir la llave de una tabla");
                            break;
                        case 8:
                            Orden ord = (Orden)info;
                            dba.defineQuery("SELECT 1 from orden WHERE \"noOrden\"=" + ord.noOrden);
                            dr = dba.executeQuery();
                            if (!dr.HasRows)
                            {
                                if (!ord.hasNullElem())
                                {
                                    dba.clearQuery();
                                    dr = null;
                                    dba.defineQuery("INSERT INTO orden VALUES(" + ord.noOrden + ",'" + ord.nombreRemitente + "','" + ord.empresaEnvio + "','" + ord.direccionEnvio + "'," + ord.noSeguimiento + "," + ord.idCliente + ")");
                                }else
                                    MessageBox.Show("No puede dejar campos en blanco.");
                            }
                            else
                                MessageBox.Show("No puede repetir la llave de una tabla");
                            break;
                        case 9:
                            Producto prod = (Producto)info;
                            dba.defineQuery("SELECT 1 from producto WHERE \"idProducto\"=" + prod.idProducto);
                            dr = dba.executeQuery();
                            if (!dr.HasRows)
                            {
                                if (!prod.hasNullElem())
                                {
                                    dba.clearQuery();
                                    dr = null;
                                    dba.defineQuery("INSERT INTO producto VALUES('" + prod.fabricante + "'," + prod.idProducto + ",'" + prod.modelo + "','" + prod.nombreProducto + "','" + prod.tipoProducto + "','" + prod.descripcion + "'," + prod.precio + ")");
                                }else
                                    MessageBox.Show("No puede dejar campos en blanco.");
                            }
                            else
                                MessageBox.Show("No puede repetir la llave de una tabla");
                            break;
                        case 10:
                            Tienda tien = (Tienda)info;
                            dba.defineQuery("SELECT 1 from tienda WHERE \"codigoTienda\"=" + tien.codigoTienda);
                            dr = dba.executeQuery();
                            if (!dr.HasRows)
                            {
                                if (!tien.hasNullElem())
                                {
                                    dba.clearQuery();
                                    dr = null;
                                    dba.defineQuery("INSERT INTO tienda VALUES(" + tien.codigoTienda + ",'" + tien.ubicacion + "')");
                                }else
                                    MessageBox.Show("No puede dejar campos en blanco.");
                            }
                            else
                                MessageBox.Show("No puede repetir la llave de una tabla");
                            break;
                        case 11:
                            TieneEnCarrito carr = (TieneEnCarrito)info;
                            dba.defineQuery("SELECT 1 from \"tieneEnCarrito\" WHERE \"idCliente\"=" + carr.idCliente + " AND \"idProducto\"=" + carr.idProducto);
                            dr = dba.executeQuery();
                            if (!dr.HasRows)
                            {
                                if (!carr.hasNullElem())
                                {
                                    dba.clearQuery();
                                    dr = null;
                                    dba.defineQuery("INSERT INTO \"tieneEnCarrito\" VALUES(" + carr.idCliente + "," + carr.idProducto + "," + carr.cantidadProductoCarrito + ")");
                                }else
                                    MessageBox.Show("No puede dejar campos en blanco.");
                            }
                            else
                                MessageBox.Show("No puede repetir la llave de una tabla");
                            break;
                    }
                    break;
                case 2:
                    switch (tablaSelec)
                    {
                        case 1:
                            Almacen a = (Almacen)info;
                            dba.defineQuery("UPDATE almacen SET \"codigoAlmacen\"=" + a.codigoAlmacen + ", ciudad='" + a.ciudad + "' WHERE \"codigoAlmacen\"=" + ((Almacen)elemento).codigoAlmacen);
                            break;
                        case 2:
                            Categoria cat = (Categoria)info;
                            dba.defineQuery("UPDATE categoria SET \"idProducto\"=" + cat.idProducto + ",\"nombreCategoria\"='" + cat.nombreCategoria + "' WHERE \"idProducto\"=" + ((Categoria)elemento).idProducto + "AND \"nombreCategoria\"='" + ((Categoria)elemento).nombreCategoria + "'");
                            break;
                        case 3:
                            Cliente clien = (Cliente)info;
                            dba.defineQuery("UPDATE cliente SET \"idCliente\"=" + clien.idCliente + ", \"nombreCliente\"='" + clien.nombre + "', \"isFrecuente\"=" + clien.isFrecuente + ",\"isVirtual\"=" + clien.isVirtual + ",\"direccionFacturacion\"='" + clien.direccionFacturacion + "',\"nombreUsuario\"='" + clien.nombreUsuario + "',password='" + clien.password + "',\"numeroTarjeta\"=" + clien.numeroTarjeta + ",\"tarjetaHabiente\"='" + clien.tarjetaHabiente + "',\"codigoSeguridad\"=" + clien.codigoSeguridad + ",\"mesVencimiento\"=" + clien.mesVencimiento + ",\"yearVencimiento\"" + clien.yearVencimiento + " WHERE \"idCliente\"=" + ((Cliente)elemento).idCliente);
                            break;
                        case 4://aqui
                            Contrato cont = (Contrato)info;
                            dba.defineQuery("UPDATE contrato SET \"noCuenta\"=" + cont.noCuenta + ",cuota=" + cont.cuota + ",\"idCliente\"=" + cont.idCliente + " WHERE \"noCuenta\"=" + ((Contrato)elemento).noCuenta);
                            break;
                        case 5:
                            DetalleFactura det = (DetalleFactura)info;
                            dba.defineQuery("UPDATE \"detalleFactura\" SET \"noFactura\"=" + det.noFactura + ",total=" + det.total + ",isv=" + det.isv + ",\"cantidadProducto\"=" + det.cantidadProducto + ",\"idProducto\"=" + det.idProducto + ",subtotal=" + det.subtotal + " WHERE \"noFactura\"=" + ((DetalleFactura)elemento).noFactura);
                            break;
                        case 6:
                            Factura fact = (Factura)info;
                            dba.defineQuery("UPDATE factura SET \"noFactura\"=" + fact.noFactura + ",RTN=" + fact.RTN + ",\"fechaEmision\"='" + fact.fechaEmision + "',direccion='" + fact.direccion + "',\"idCliente\"=" + fact.idCliente + ",\"codigoTienda\"=" + fact.codigoTienda + " WHERE \"noFactura\"=" + ((Factura)elemento).noFactura);
                            break;
                        case 7:
                            Inventario inv = (Inventario)info;
                            dba.defineQuery("UPDATE inventario SET \"codigoTienda\"=" + inv.codigoTienda + ",\"codigoAlmacen\"=" + inv.codigoAlmacen + ",\"idProducto\"=" + inv.idProducto + ",\"cantidadInventario\"=" + inv.cantidadInventario + " WHERE \"codigoTienda\"=" + ((Inventario)elemento).codigoTienda + " AND \"codigoAlmacen\"=" + ((Inventario)elemento).codigoAlmacen + " AND \"idProducto\"=" + ((Inventario)elemento).idProducto);
                            break;
                        case 8:
                            Orden ord = (Orden)info;
                            dba.defineQuery("UPDATE orden SET \"noOrden\"=" + ord.noOrden + ",\"nombreRemitente\"='" + ord.nombreRemitente + "',\"empresaEnvio\"='" + ord.empresaEnvio + "',\"direccionEnvio\"='" + ord.direccionEnvio + "',\"noSeguimiento\"=" + ord.noSeguimiento + ",\"idCliente\"=" + ord.idCliente + " WHERE \"noOrden\"=" + ((Orden)elemento).noOrden);
                            break;
                        case 9:
                            Producto prod = (Producto)info;
                            dba.defineQuery("UPDATE producto SET fabricante='" + prod.fabricante + "',\"idProducto\"=" + prod.idProducto + ",modelo='" + prod.modelo + "',\"nombreProducto\"='" + prod.nombreProducto + "',\"tipoProducto\"='" + prod.tipoProducto + "',descripcion='" + prod.descripcion + "',precio=" + prod.precio + " WHERE \"idProducto\"=" + ((Producto)elemento).idProducto);
                            break;
                        case 10:
                            Tienda tien = (Tienda)info;
                            dba.defineQuery("UPDATE tienda SET \"codigoTienda\"=" + tien.codigoTienda + ",ubicacion='" + tien.ubicacion + "' WHERE \"codigoTienda\"=" + ((Tienda)elemento).codigoTienda);
                            break;
                        case 11:
                            TieneEnCarrito carr = (TieneEnCarrito)info;
                            dba.defineQuery("UPDATE \"tieneEnCarrito\" SET \"idCliente\"=" + carr.idCliente + ",\"idProducto\"=" + carr.idProducto + ",\"cantidadProductoCarrito\"=" + carr.cantidadProductoCarrito + " WHERE \"idCliente\"=" + ((TieneEnCarrito)elemento).idCliente + " AND \"idProducto\"=" + ((TieneEnCarrito)elemento).idProducto);
                            break;
                    }
                    break;
            }
            dba.executeQuery();
            dba.close();
            this.Close();
            av.updateTable();
        }
    }
}
