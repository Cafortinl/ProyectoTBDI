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
    /// Interaction logic for Empleados.xaml
    /// </summary>
    public partial class Empleados : Window
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
        public Empleados()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> tipos = new List<string> { "Administrador", "Servicio al cliente", "Centro de llamadas", "Almacen", "Empresa envíos"};
            cbTipos.ItemsSource = tipos;
            updateTable();
        }

        struct Usuario
        {
            public string nombre { get; set; }
            public string password { get; set; }
            public int tipo { get; set; }

            public Usuario(string n, string p, int t)
            {
                nombre = n;
                password = p;
                tipo = t;
            }
        }

        public void updateTable()
        {
            List<Usuario> usuarios = new List<Usuario>();
            dba.open();
            dba.defineQuery("SELECT * FROM usuarios WHERE tipo <> 5");
            NpgsqlDataReader dr = dba.executeQuery();
            while (dr.Read())
            {
                usuarios.Add(new Usuario(dr.GetString(0), dr.GetString(1), dr.GetInt32(2)));
            }
            dba.close();
            dgEmpleados.ItemsSource = usuarios;
            dgEmpleados.IsReadOnly = true;
        }

        public void updateCB(int i)
        {
            if (i == 6)
                cbTipos.SelectedIndex = i - 2;
            else
                cbTipos.SelectedIndex = i - 1;
        }

        public int getIntCB()
        {
            if (cbTipos.SelectedIndex == 4)
                return cbTipos.SelectedIndex + 2;
            else
                return cbTipos.SelectedIndex + 1;
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = tbUsuario.Text;
            string password = tbPass.Text;
            int tipo = getIntCB();
            dba.open();
            dba.defineQuery("SELECT 1 FROM usuarios WHERE usuario='" + nombre + "'");
            NpgsqlDataReader dr = dba.executeQuery();
            if (dr.HasRows)
            {
                MessageBox.Show("El nombre de usuario seleccionado ya está en la base de datos. Intentelo de nuevo");
                tbUsuario.Text = "";
            }
            else
            {
                dba.clearQuery();
                dr = null;
                dba.defineQuery("INSERT INTO usuarios VALUES('" + nombre + "','" + password + "'," + tipo + ")");
                dba.executeQuery();
                tbUsuario.Text = "";
                tbPass.Text = "";
                cbTipos.SelectedIndex = -1;
            }
            dba.close();
            updateTable();
        }

        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            int index = dgEmpleados.SelectedIndex;
            if (index > -1)
            {
                DataGridRow row = dgEmpleados.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                var info = dgEmpleados.ItemContainerGenerator.ItemFromContainer(row);
                Usuario u = (Usuario)info;
                string nombre = tbUsuario.Text;
                string password = tbPass.Text;
                int tipo = getIntCB();
                dba.open();
                dba.defineQuery("SELECT 1 FROM usuarios WHERE usuario='" + nombre + "'");
                NpgsqlDataReader dr = dba.executeQuery();
                if (dr.HasRows)
                {
                    MessageBox.Show("El nombre de usuario seleccionado ya está en la base de datos. Intentelo de nuevo");
                    tbUsuario.Text = "";
                }
                else
                {
                    dba.clearQuery();
                    dr = null;
                    dba.defineQuery("UPDATE usuarios SET usuario='" + nombre + "',password='" + password + "',tipo=" + tipo + " WHERE usuario='" + u.nombre + "'");
                    dba.executeQuery();
                    tbUsuario.Text = "";
                    tbPass.Text = "";
                    cbTipos.SelectedIndex = -1;
                }
                dba.close();
                updateTable();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuaio para poder modificarlo.");
            }
        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            int index = dgEmpleados.SelectedIndex;
            if (index > -1)
            {
                dba.open();
                dba.defineQuery("DELETE FROM usuarios WHERE usuario='" + tbUsuario.Text + "'");
                dba.executeQuery();
                dba.close();
                tbUsuario.Text = "";
                tbPass.Text = "";
                cbTipos.SelectedIndex = -1;
                updateTable();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuaio para poder eliminarlo.");
            }
        }

        private void dgEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = dgEmpleados.SelectedIndex;
            if (index > -1)
            {
                DataGridRow row = dgEmpleados.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                var info = dgEmpleados.ItemContainerGenerator.ItemFromContainer(row);
                Usuario u = (Usuario)info;
                updateCB(u.tipo);
                tbUsuario.Text = u.nombre;
                tbPass.Text = u.password;
            }
        }
    }
}
