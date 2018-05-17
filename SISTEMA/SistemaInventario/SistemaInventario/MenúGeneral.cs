using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInventario
{
    public partial class MenuG : Form
    {
        public MenuG()
        {
            InitializeComponent();
        }

        private void btnResguardos_Click(object sender, EventArgs e)
        {
            Personal resguardos = new Personal();
            resguardos.Show();
            this.Hide();
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            Informes informes = new Informes();
            informes.Show();
            this.Hide();
        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            Articulos articulos = new Articulos();
            articulos.Show();
            this.Hide();
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            SplashScreen splash = new SplashScreen();
            splash.Close();
            this.Close();
        }
    }
}
