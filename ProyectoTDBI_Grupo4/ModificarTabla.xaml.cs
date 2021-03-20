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
    /// Interaction logic for ModificarTabla.xaml
    /// </summary>
    public partial class ModificarTabla : Window
    {

        private static int opcion;
        private static int tablaSelec;
        private static object elemento;
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
        }
    }
}
