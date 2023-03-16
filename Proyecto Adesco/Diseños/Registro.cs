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

namespace Proyecto_Adesco
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

       

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void Registro_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void picMonstrar_Click(object sender, EventArgs e)
        {
            // la imagen ocultar la mandamos al frente
            picOcultar.BringToFront();
            // se muestra la contraseña
            txtPassword.PasswordChar = '\0';
            txtConPassword.PasswordChar = '\0';
        }

        private void picOcultar_Click(object sender, EventArgs e)
        {
            picMonstrar.BringToFront();
            txtPassword.PasswordChar = '*';
            txtConPassword.PasswordChar = '*';
        }

        private void picRegresar_Click(object sender, EventArgs e)
        {
            Form frmInicio = new Inicio();
            frmInicio.Show();
            this.Visible = false;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            usuario.Usuario = txtUsuario.Text;
            usuario.Password = txtPassword.Text;
            usuario.Conpassword = txtConPassword.Text;
            usuario.Nombre = txtNombre.Text;

            try
            {
                Control control = new Control();
                string respuesta = control.ctrlRegistro(usuario);

                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Usuario registrado con exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtConPassword.Focus();
            }
        }

        private void txtConPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtNombre.Focus();
            }
        }

        private void txtConPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
