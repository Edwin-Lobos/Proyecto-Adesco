using MySql.Data.MySqlClient;
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
    public partial class Datos : Form
    {
        public Datos()
        {
            InitializeComponent();
            cargarTabla(null);
        }

        private void Datos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void picRegresar_Click(object sender, EventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }
        //----------------Botón para registrar y actualizar los datos en la base------------------
        private void rjButton2_Click_1(object sender, EventArgs e)
        {

            bool bandera = false;
            DatosBD _datos = new DatosBD();
            _datos.Nombres = txtNombres.Text;
            _datos.Apellidos = txtApellidos.Text;
            _datos.Senda = txtSenda.Text;
            _datos.Poligono = txtPoligono.Text;
            _datos.N_casa = txtN_casa.Text;
            _datos.Telefono = int.Parse(txtTelefono.Text);
            _datos.Codigo = txtCodigo.Text;

            if (string.IsNullOrEmpty(_datos.Nombres) || string.IsNullOrEmpty(_datos.Apellidos) || string.IsNullOrEmpty(_datos.Senda) || string.IsNullOrEmpty(_datos.Poligono) || string.IsNullOrEmpty(_datos.N_casa) || string.IsNullOrEmpty(_datos.Codigo))
            {
                MessageBox.Show("Debe llenar todos los campos", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Ctrldatos ctrl = new Ctrldatos();
                if (txtId.Text != "")
                {
                    _datos.Id = int.Parse(txtId.Text);
                    bandera = ctrl.actualizar(_datos);
                }
                else
                {
                    bandera = ctrl.insertar(_datos);
                }

                if (bandera)
                {
                    MessageBox.Show("Registro exitoso", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    limpiar();
                    cargarTabla(null);
                }
            }

        }

        //-----------------------------limpiar los texbox------------------------------
        private void limpiar()
        {
            txtId.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtSenda.Text = "";
            txtPoligono.Text = "";
            txtN_casa.Text = "";
            txtTelefono.Text = "";
            txtCodigo.Text = "";
        }

        //---------------------------------Botón para buscar--------------------------------------
        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            string dato = txtDato.Text;
            cargarTabla(dato);
        }

        //-------------------------Carga la tabla en la datagridview------------------------------
        private void cargarTabla(string dato)
        {
            List<DatosBD> list = new List<DatosBD>();
            Ctrldatos _ctrdatos = new Ctrldatos();
            dataGridView1.DataSource = _ctrdatos.consulta(dato);
        }

        //-----------Selecciona los datos de la datagridview y los manda a las texbox-------------
        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombres.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtApellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSenda.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtPoligono.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtN_casa.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtTelefono.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtCodigo.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        //----------------Botón para eliminar los registros de la base de datos-------------------
        private void rjButton2_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            DialogResult resultado = MessageBox.Show("¿Seguro que desea eliminar el registro?", "Salir", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                int id = int.Parse(txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Ctrldatos _ctrl = new Ctrldatos();
                bandera = _ctrl.eliminar(id);

                if (bandera)
                {
                    MessageBox.Show("Registro Eliminado", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    cargarTabla(null);
                }
            }
        }

        //-------------------------LIMPIAR-----------------------------------------
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        
        private void rjButton1_Click(object sender, EventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombres.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtApellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSenda.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtPoligono.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtN_casa.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtTelefono.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtCodigo.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }
        //-------------------------------------------------------------------------------


        private void rjButton3_Click(object sender, EventArgs e)
        {
            limpiar();
        }



        //--------------------------------------------------------------------------
        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtApellidos.Focus();
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtSenda.Focus();
            }
        }

        private void txtSenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPoligono.Focus();
            }
        }

        private void txtPoligono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtN_casa.Focus();
            }
        }

        private void txtN_casa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtCodigo.Focus();
            }
        }

        //-------------------------------------------------------------------------------

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Datos_Load(object sender, EventArgs e)
        {
            CentrarPanelEnFormulario();
        }
        private void CentrarPanelEnFormulario()
        {
            int altura_form = this.Height;
            int anchura_form = this.Width;
            int altura_grbox = panel1.Height;
            int anchura_grbox = panel1.Width;

            int nueva_altura = (altura_form - altura_grbox) / 2;
            int nueva_anchura = (anchura_form - anchura_grbox) / 2;


            panel1.Location = new Point(nueva_anchura, nueva_altura);
        }

        private void Datos_SizeChanged(object sender, EventArgs e)
        {
            CentrarPanelEnFormulario();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }


