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
    /// Interaction logic for Registrarse.xaml
    /// </summary>
    public partial class Registrarse : Window
    {
        public static string Host = "proyectotdbi.ce6kih4lqvgw.us-east-1.rds.amazonaws.com";
        public static string User = "administrador";
        public static string DBname = "ProyectoTDBI";
        public static string Port = "5432";
        public static string Password = "AdM1n_Pr0yect0#1";
        public static string connString =
            String.Format(
                "Server={0};Port={1};Database={2};User Id={3};Password={4};",
                Host,
                Port,
                DBname,
                User,
                Password);
        DBAdmin dba = new DBAdmin(connString);
        public Registrarse()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            dba.open();
            bool canRegister = true;
            dba.defineQuery("SELECT 1 from cliente WHERE \"idCliente\"=" + tbID.Text);
            NpgsqlDataReader dr = dba.executeQuery();
            if (dr.HasRows)
            {
                MessageBox.Show("El id ingresado ya se encuentra en la base de datos. Intentelo de nuevo.");
                tbID.Text = "";
                canRegister = false;
            }
            dba.clearQuery();
            dr = null;
            if (!int.TryParse(tbID.Text, out _))
            {
                MessageBox.Show("El id debe ser un número. Intentelo de nuevo.");
                tbID.Text = "";
                canRegister = false;
            }
            dba.defineQuery("SELECT 1 from usuarios WHERE usuario='" + tbUsuario.Text + "'");
            dr = dba.executeQuery();
            if (dr.HasRows)
            {
                MessageBox.Show("El usuario ingresado ya se encuentra en la base de datos. Intentelo de nuevo.");
                tbUsuario.Text = "";
                canRegister = false;
            }
            dba.clearQuery();
            dr = null;
            if (!int.TryParse(tbTarjeta.Text, out _))
            {
                MessageBox.Show("El número de tarjeta debe ser un número. Intentelo de nuevo.");
                tbTarjeta.Text = "";
                canRegister = false;
            }
            if (!int.TryParse(tbCodSeg.Text, out _))
            {
                MessageBox.Show("El código de seguridad debe ser un número. Intentelo de nuevo.");
                tbCodSeg.Text = "";
                canRegister = false;
            }
            if (!int.TryParse(tbMes.Text, out _))
            {
                MessageBox.Show("El mes de vencimiento debe ser un número. Intentelo de nuevo.");
                tbMes.Text = "";
                canRegister = false;
            }
            if (!int.TryParse(tbYear.Text, out _))
            {
                MessageBox.Show("El año de vencimiento debe ser un número. Intentelo de nuevo.");
                tbYear.Text = "";
                canRegister = false;
            }
            if (canRegister)
            {
                int id = Convert.ToInt32(tbID.Text);
                string nombre = tbNombre.Text;
                bool isFrecuente = (bool)cbFrecuente.IsChecked;
                bool isVirtual = (bool)cbVirtual.IsChecked;
                string direccion = tbDireccion.Text;
                string usuario = tbUsuario.Text;
                string password = pbPassword.Password;
                int noTarj = Convert.ToInt32(tbTarjeta.Text);
                string th = tbThabiente.Text;
                int codSeg = Convert.ToInt32(tbCodSeg.Text);
                int mes = Convert.ToInt32(tbMes.Text);
                int year = Convert.ToInt32(tbYear.Text);
                dba.defineQuery("INSERT INTO cliente VALUES(" + id + ",'" + nombre + "'," + isFrecuente + "," + isVirtual + ",'" + direccion + "','" + usuario + "','" + password + "'," + noTarj + ",'" + th + "'," + codSeg + "," + mes + "," + year + ")");
                dba.executeQuery();
                dba.clearQuery();
                dba.defineQuery("INSERT INTO usuarios VALUES('" + usuario + "','" + password + "',5)");
                dba.executeQuery();
                this.Close();
            }
            dba.close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
