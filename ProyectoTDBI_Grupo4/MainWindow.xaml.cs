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
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            
            String Usuario = tbUsuario.Text;
            String Contra = tbContra.Password;

            try
            {
                dba.open();
                //dba.defineQuery("SELECT 1 FROM pg_roles WHERE rolname='" + Usuario + "'");
                //NpgsqlDataReader dr = dba.executeQuery();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT 1 FROM pg_roles WHERE rolname='administrador'", dba.getConn());
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                dg.DataContext = dt;
                //MessageBox.Show(dt[0].ToString());
                dba.close();
            }catch(Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }

            /*if (Usuario == "admin")
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
            }*/
            tbUsuario.Text = "";
            tbContra.Password = "";
        }
    }
}
