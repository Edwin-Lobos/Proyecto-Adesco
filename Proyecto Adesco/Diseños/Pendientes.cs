using Proyecto_Adesco.Clases;
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
    public partial class Pendientes : Form
    {
        public Pendientes()
        {
            InitializeComponent();
            cargarTabla2(null);
        }
        private void cargarTabla2(string datoRC)
        {
            List<AuxRecibo> list = new List<AuxRecibo>();
            CtrlRecibo _ctrdatos = new CtrlRecibo();
            dataGridView1.DataSource = _ctrdatos.consulta(datoRC);
        }
        private void picRegresar_Click(object sender, EventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }

        private void Pendientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }
    }
}
