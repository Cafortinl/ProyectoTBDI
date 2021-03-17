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
        public adminView()
        {
            InitializeComponent();
        }

        private void btLogoff_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void cbTablaSelec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbTablaSelec.SelectedItem)
            {
                case "Almacen":

                    break;
                case "Categoria":
                    break;
                case "Cliente":
                    break;
                case "Contrato":
                    break;
                case "DetalleFactura":
                    break;
                case "Factura":
                    break;
                case "Inventario":
                    break;
                case "Orden":
                    break;
                case "Producto":
                    break;
                case "Tienda":
                    break;
                case "TieneEnCarrito":
                    break;
            }
        }
    }
}
