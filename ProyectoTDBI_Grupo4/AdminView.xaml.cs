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
    /// Interaction logic for adminView.xaml
    /// </summary>
    public partial class adminView : Window
    {
        public MainWindow mw;
        public adminView()
        {
            InitializeComponent();
            List<string> tablas = new List<string> {"Almacen", "Categoria", "Cliente", "Contrato", "DetalleFactura", "Factura", "Inventario", "Orden", "Producto", "Tienda", "TieneEnCarrito"};
            cbTablaSelec.ItemsSource = tablas;
        }

        private void btLogoff_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //MainWindow mw = new MainWindow();
           // mw.Show();
        }

        private void cbTablaSelec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> columnas = null;
            dgInfo = new DataGrid();
            switch (cbTablaSelec.SelectedItem)
            {
                case "Almacen":
                    columnas = new List<string> { "codigoAlmacen", "ubicacion" };
                    break;
                case "Categoria":
                    columnas = new List<string> { "idProducto", "nombreCategoria"};
                    break;
                case "Cliente":
                    columnas = new List<string> {"idCliente", "nombreCliente", "isFrecuente", "isVirtual", "direccionFactura", "nombreUsuario", "password", "numeroTarjeta", "tarjetaHabiente", "codigoSeguridad", "mesVencimiento", "yearVencimiento" };
                    break;
                case "Contrato":
                    columnas = new List<string> { "noCuenta", "cuota", "idCliente"};
                    break;
                case "DetalleFactura":
                    columnas = new List<string> { "noFactura", "total", "isv", "cantidadProducto", "idProducto", "subtotal"};
                    break;
                case "Factura":
                    columnas = new List<string> { "noFactura", "RTN", "fechaEmision", "direccion", "idCliente", "codigoTienda"};
                    break;
                case "Inventario":
                    columnas = new List<string> { "codigoTienda", "codigoAlmacen", "idProducto", "cantidadInventario"};
                    break;
                case "Orden":
                    columnas = new List<string> { "noOrden", "nombreRemitente", "empresaEnvio", "direccionEnvio", "noSeguimiento", "idCliente"};
                    break;
                case "Producto":
                    columnas = new List<string> { "idProducto", "fabricante", "nombreProducto", "modelo", "precio", "tipoProducto", "descripcion"};
                    break;
                case "Tienda":
                    columnas = new List<string> { "codigoTienda", "ubicacion"};
                    break;
                case "TieneEnCarrito":
                    columnas = new List<string> { "idCliente", "idProducto", "cantidadProductoCarrito"};
                    break;
            }
        }

    }
}
