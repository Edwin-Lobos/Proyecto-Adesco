using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Proyecto_Adesco
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        
            label2.Text = Session.nombre;
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            centrado();
        }
        private void centrado()
        {
            //dimensiones
            int altura_form = this.Height;
            int anchura_form = this.Width;
            int altura_grbox = panel1.Height;
            int anchura_grbox = panel1.Width;

            int nueva_altura = (altura_form - altura_grbox) / 2;
            int nueva_anchura = (anchura_form - anchura_grbox) / 2;


            panel1.Location = new Point(nueva_anchura, nueva_altura);
        }

        private void btnRecibo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Form frmReporte = new Reporte();
            frmReporte.Show();
            this.Visible = false;
        }

        private void btnPendientes_Click(object sender, EventArgs e)
        {
            Form frmPendientes = new Pendientes();
            frmPendientes.Show();
            this.Visible = false;
        }

        private void picRegresar_Click(object sender, EventArgs e)
        {
            Form frmInicio = new Inicio();
            frmInicio.Show();
            this.Visible = false;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Form frmRecibo = new recibo();
            frmRecibo.Show();
            this.Visible = false;
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            Form frmPendientes = new Pendientes();
            frmPendientes.Show();
            this.Visible = false;
        }

        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            Form frmReporte = new Reporte();
            frmReporte.Show();
            this.Visible = false;
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            Form frmRecibo = new recibo();
            frmRecibo.Show();
            this.Visible = false;
        }

        private void rjButton2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rjButtonmaxi_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void rjButtonmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1Barra_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1Barra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void botonDatos_Click(object sender, EventArgs e)
        {
            Form frmDatos = new Datos();
            frmDatos.Show();
            this.Visible = false;
        }

        private void rjButton1_Click_2(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cerrar sesión?", "Salir",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question) == DialogResult.No)
            {
               
            }
            else
            {
                Form frmInicio = new Inicio();
                frmInicio.Show();
                this.Visible = false;
            }

            
        }

        private void Principal_SizeChanged(object sender, EventArgs e)
        {
            centrado();
        }
    }
}
