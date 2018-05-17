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
    public partial class MenuP : Form
    {
        public MenuP()
        {
            InitializeComponent();
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
