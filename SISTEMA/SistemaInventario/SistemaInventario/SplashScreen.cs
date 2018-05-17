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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            tiempo.Enabled = true;
            tiempo.Interval = 2000;
        }

        private void tiempo_Tick(object sender, EventArgs e)
        {
            this.tiempo.Stop();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
        }
    }
}
