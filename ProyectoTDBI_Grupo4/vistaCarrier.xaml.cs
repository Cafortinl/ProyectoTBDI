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
    /// Interaction logic for vistaCarrier.xaml
    /// </summary>
    public partial class vistaCarrier : Window
    {
        private static string usuario;
        private static string Host = "proyectotdbi.ce6kih4lqvgw.us-east-1.rds.amazonaws.com";
        private static string User = "administrador";
        private static string DBname = "ProyectoTDBI";
        private static string Port = "5432";
        private static string Password = "AdM1n_Pr0yect0#1";
        private static string connString =
            String.Format(
                "Server={0};Port={1};Database={2};User Id={3};Password={4};",
                Host,
                Port,
                DBname,
                User,
                Password);
        DBAdmin dba = new DBAdmin(connString);
        public vistaCarrier(string u)
        {
            InitializeComponent();
            usuario = u;
            List<string> estados = new List<string> {"En espera", "En proceso", "Entregado", "Destruido"};
            lbNombreEmpresa.Content = usuario;
            cbEstados.ItemsSource = estados;
            updateTable();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public void updateTable()
        {
            dba.open();
            dba.defineQuery("SELECT * FROM orden WHERE \"empresaEnvio\"='" + usuario + "'");
            NpgsqlDataReader dr = dba.executeQuery();
            List<Orden> ordenes = new List<Orden>();
            while (dr.Read())
            {
                ordenes.Add(new Orden(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetInt32(4), dr.GetInt32(5), dr.GetString(6)));
            }
            dgOrdenes.ItemsSource = ordenes;
            dgOrdenes.CanUserAddRows = false;
            dba.close();
        }

        private void btModEstado_Click(object sender, RoutedEventArgs e)
        {
            int index = dgOrdenes.SelectedIndex;
            if (index > -1)
            {
                DataGridRow row = dgOrdenes.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                var info = dgOrdenes.ItemContainerGenerator.ItemFromContainer(row);
                Orden o = (Orden)info;
                o.estadoEnvio = (string)cbEstados.SelectedItem;
                dba.open();
                if (((string)cbEstados.SelectedItem).Equals("Entregado"))
                {
                    dba.defineQuery("DELETE FROM orden WHERE \"noOrden\"=" + o.noOrden);
                }
                else
                {
                    dba.defineQuery("UPDATE orden SET \"estadoEnvio\"='" + o.estadoEnvio + "' WHERE \"noOrden\"=" + o.noOrden);
                }
                dba.executeQuery();
                dba.close();
                updateTable();
            }
            else
                MessageBox.Show("Debe seleccionar una orden para cambiarle el estado.");
        }

        private void btSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
