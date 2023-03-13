using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Adesco
{
    public partial class recibo : Form
    {
        public recibo()
        {
            InitializeComponent();
        }

        private void recibo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void picRegresar_Click(object sender, EventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }
    }
}
