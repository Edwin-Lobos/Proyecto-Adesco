﻿using System;
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
    public partial class Inicio : Form
    {
        private void AbrirFormulario<Login>() where Login : Form, new()
        {
            Form formulario = panel1.Controls.OfType<Login>().FirstOrDefault();
            if (formulario != null)
            {
                //Si la instancia esta minimizada la dejamos en su estado normal
                if (formulario.WindowState == FormWindowState.Minimized)
                {
                    formulario.WindowState = FormWindowState.Normal;
                }
                //Si la instancia existe la pongo en primer plano
                formulario.BringToFront();
                return;
            }
            //Se abre el form
            formulario = new Login();
            formulario.TopLevel = false;
            panel1.Controls.Add(formulario);
            panel1.Tag = formulario;
            formulario.Show();
        }

        public Inicio()
        {
            InitializeComponent();
        }


        private void Inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            try
            {
                Control ctrl = new Control();
                string respuesta = ctrl.ctrlLogin(usuario, password);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Principal frm = new Principal();
                    frm.Visible = true;
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void rjButton3_Click(object sender, EventArgs e)
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

        private void panel1Barra_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picRegresar_Click(object sender, EventArgs e)
        {
            
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
            txtUsuario.SelectAll();

            // centrado();
        }
        // private void centrado()
        //{
        //dimensiones
        //   int altura_form = this.Height;
        // int anchura_form = this.Width;
        // int altura_grbox = panel1.Height;
        // int anchura_grbox = panel1.Width;

        //int nueva_altura = (altura_form - altura_grbox) / 2;
        //int nueva_anchura = (anchura_form - anchura_grbox) / 2;


        //panel1.Location = new Point(nueva_anchura, nueva_altura);
        //}

        private void Inicio_SizeChanged(object sender, EventArgs e)
        {
            //centrado();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //AbrirFormulario<Login>();
        }

        private void picMonstrar_Click(object sender, EventArgs e)
        {
            // la imagen ocultar la mandamos al frente
            picOcultar.BringToFront();
            // se muestra la contraseña
            txtPassword.PasswordChar = '\0';

        }

        private void picOcultar_Click(object sender, EventArgs e)
        {
            picMonstrar.BringToFront();
            txtPassword.PasswordChar = '*';
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            
        }
        //-----------------------------------------------------------------------------
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
                string usuario = txtUsuario.Text;
                string password = txtPassword.Text;

                try
                {
                    Control ctrl = new Control();
                    string respuesta = ctrl.ctrlLogin(usuario, password);
                    if (respuesta.Length > 0)
                    {
                        MessageBox.Show(respuesta, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Principal frm = new Principal();
                        frm.Visible = true;
                        this.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rjButton1.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtUsuario_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPassword.Focus();
            }
        }

        //-----------------------------------------------------------------------------
    }
}
