using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SistemaInventario
{
    public partial class Autenticacion : Form
    {
        public static OleDbConnection con;
        public static string direccion = "C:/Users/YOO/Documents/GitHub/SistemaInventario/SISTEMA/sistema.mdb";
        public int intentos = 1;
        public static string user;

        public Autenticacion()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (intentos < 3)
            {
                user = tbUsuario.Text;
                string contras = tbPassword.Text;
                if (user == "" || contras == "")
                {
                    MessageBox.Show("Por favor, debe de ingresar usuario y/o contraseña.");
                }
                else
                {
                    if (Ingreso(user, contras) == 1)
                    {
                        MessageBox.Show("Bienvenido Administrador.");
                        MenuG administrador = new MenuG();
                        administrador.Show();
                    }
                    else if (Ingreso(user, contras) == 2)
                    {
                        MessageBox.Show("Bienvenido Usuario.");
                        MenuP menuP = new MenuP();
                        menuP.Show();
                    }
                    else
                    {
                        MessageBox.Show("El usuario y/o la contraseña son incorrectos o el usuario no existe.");
                        tbUsuario.Clear();
                        tbPassword.Clear();
                        tbUsuario.Focus();
                        intentos += 1;
                    }
                }
                tbUsuario.Clear();
                tbPassword.Clear();
            }
            else
            {
                MessageBox.Show("Haz desperdiciado tus intentos de Accesar.");
                tbPassword.Enabled = false;
                tbUsuario.Enabled = false;
                btnIngresar.Enabled = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            SplashScreen splash = new SplashScreen();
            splash.Close();
            this.Close();
        }

        public static bool ConectarBD()
        {
            bool permitir = false;
            string stringConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + direccion;
            try
            {
                con = new OleDbConnection(@stringConexion);
                con.Open();
                permitir = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            return permitir;
        }

        public int Ingreso(string usuario, string contra)
        {
            int validar = 0;
            ConectarBD();
            OleDbCommand buscar = new OleDbCommand();
            buscar.Connection = con;
            buscar.CommandText = @"SELECT * FROM USUARIO";
            OleDbDataReader reader = buscar.ExecuteReader();
            while (reader.Read())
            {
                if (usuario == reader.GetValue(1).ToString() && contra == reader.GetValue(2).ToString())
                {
                    if (reader.GetValue(3).ToString() == "0")
                    {
                        int algo = 1;
                        validar = algo;
                    }
                    else if (reader.GetValue(3).ToString() == "1")
                    {
                        int algo = 2;
                        validar = algo;
                    }
                }
            }
            con.Close();
            return validar;
        }
    }
}

