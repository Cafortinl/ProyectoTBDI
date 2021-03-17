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
    /// Interaction logic for CallCenter.xaml
    /// </summary>
    public partial class CallCenter : Window
    {
        public CallCenter()
        {
            InitializeComponent();
        }

        private void Cll_BtCompra_Click(object sender, RoutedEventArgs e)
        {
            int idCliente = Convert.ToInt32(Cll_idCliente.Text);
            int  nOrden = Convert.ToInt32(Cll_nOrden.Text);
            int nSeguimiento = Convert.ToInt32(Cll_nSeguimiento.Text);
            string nombreRemitente = Cll_nRemitente.Text;
            string empresaEnvio = Cll_EmpresaEnvio.Text;
            string DireccionEnvio = Cll_DirreccionEnvio.Text;
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
            try
            {
                dba.open();
                dba.defineQuery("SELECT * FROM Clientes");
                NpgsqlDataReader dr = dba.executeQuery();
                if (dr.HasRows)
                {
                    
                }
                else
                    MessageBox.Show("El usuario ingresado no se encuentra en la base de datos. Intentelo de nuevo.");
                dba.close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }

        }
    }
}
