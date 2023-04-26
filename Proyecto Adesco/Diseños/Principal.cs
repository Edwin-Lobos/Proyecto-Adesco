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
        private Form currentChildForm;
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
            Form frmDatos = new Beneficiarios();
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
            
        }


        //---------------------------------------------------------------
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End

            // Configurar el nuevo formulario hijo a mostrar
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelhijo.Controls.Add(childForm);
            panelhijo.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            // Actualizar la referencia al nuevo formulario hijo actual
            currentChildForm = childForm;
        }
        //---------------------------------------------------------------
        private void Recibo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new recibo());
        }

        private void Reporte_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Reporte());
        }

        private void Pendientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Pendientes());
        }

        private void Beneficiarios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Beneficiarios());

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjButton2_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form frmRegistro = new Registro();
            frmRegistro.Show();
            this.Visible = false;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new recibo());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Reporte());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Pendientes());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Beneficiarios());
        }
    }
}
