using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoTDBI_Grupo4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         
        }

        private void btInicioSesion_Click(object sender, RoutedEventArgs e)
        {
            String Usuario = tbUsuario.Text;
            String Contra = tbContra.Password;

            if (Usuario == "admin")
            {
                if (Contra == "123")
                {
                    adminView aV = new adminView();
                    aV.Show();
                    this.Close();
                }
            }
            if(Usuario == "ServClien")
            {
                if(Contra == "123")
                {
                    ServicioCliente sc = new ServicioCliente();
                    sc.Show();
                    this.Close();
                }
            }
            if(Usuario == "callCent")
            {
                if(Contra == "123")
                {
                    CallCenter cc = new CallCenter();
                    cc.Show();
                    this.Close();
                }
            }
            if(Usuario == "almacen")
            {
                if(Contra == "123")
                {
                    Bodega bd = new Bodega();
                    bd.Show();
                    this.Close();
                }
            }
            tbUsuario.Text = "";
            tbContra.Password = "";
        }
    }
}
