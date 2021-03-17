using System;
using System.Collections.Generic;
using System.Data;
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
using Npgsql;

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
            string Host = "proyectotdbi.ce6kih4lqvgw.us-east-1.rds.amazonaws.com";
            string User = "administrador";
            string DBname = "ProyectoTDBI";
            string Port = "5432";
            string Password = "AdM1n_Pr0yect0#1";
            string connString =
                String.Format(
                    "Server={0};Port={1};Database={2};User Id={3};Password={4};",
                    Host,
                    Port,
                    DBname,
                    User,
                    Password);
            DBAdmin dba = new DBAdmin(connString);
            
            String Usuario = tbUsuario.Text;
            String Contra = tbContra.Password;

            try
            {
                dba.open();
                dba.defineQuery("SELECT 1 FROM pg_roles WHERE rolname='" + Usuario + "'");
                NpgsqlDataReader dr = dba.executeQuery();
                if (dr.HasRows)
                {
                    if (Usuario == "administrador")
                    {
                        if (Contra == "1234")
                        {
                            adminView aV = new adminView();
                            aV.Show();
                        }
                        else
                            MessageBox.Show("Contraseña incorrecta");
                    }
                    else if (Usuario == "Servicio Cliente")
                    {
                        if (Contra == "1234")
                        {
                            ServicioCliente sc = new ServicioCliente();
                            sc.Show();
                        }
                        else
                            MessageBox.Show("Contraseña incorrecta");
                    }
                    else if (Usuario == "Call Center")
                    {
                        if (Contra == "1234")
                        {
                            CallCenter cc = new CallCenter();
                            cc.Show();
                        }
                        else
                            MessageBox.Show("Contraseña incorrecta");
                    }
                    else if (Usuario == "almacen")
                    {
                        if (Contra == "1234")
                        {
                            Bodega bd = new Bodega();
                            bd.Show();
                        }
                        else
                            MessageBox.Show("Contraseña incorrecta");
                    }
                }
                else
                    MessageBox.Show("El usuario ingresado no se encuentra en la base de datos. Intentelo de nuevo.");
                dba.close();
            }catch(Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }
            tbUsuario.Text = "";
            tbContra.Password = "";
        }

    }
}
