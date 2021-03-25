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
    /// Interaction logic for Reportes.xaml
    /// </summary>
    public partial class Reportes : Window
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
        public Reportes()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
