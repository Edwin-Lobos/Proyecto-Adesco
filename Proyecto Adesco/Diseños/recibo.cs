using MySql.Data.MySqlClient;
using Proyecto_Adesco.Clases;
using System;
using System.Collections;
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
            cargarTabla(null);
            
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







        //-------------------Botón para buscar------------------------------------
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            MySqlDataReader reader = null;

            string sql = "SELECT id, nombres, apellidos, senda, poligono, n_casa, codigo FROM datos WHERE codigo LIKE '" + codigo + "' LIMIT 1";
            MySqlConnection conexion = Conexion.GetConnection();
            conexion.Open();

            try
            {

                MySqlCommand comando = new MySqlCommand(sql, conexion);
                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtId.Text = reader[0].ToString();
                        txtNombres.Text = reader[1].ToString();
                        txtApellidos.Text = reader[2].ToString();
                        txtSenda.Text = reader[3].ToString();
                        txtPoligono.Text = reader[4].ToString();
                        txtN_casa.Text = reader[5].ToString();
                        txtCodigo.Text = reader[6].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

        }
        //-------------------------------------------------------------------------

        private void cargarTabla(string dato)
        {
            List<DatosBD> list = new List<DatosBD>();
            Ctrldatos _ctrdatos = new Ctrldatos();
            dataGridView1.DataSource = _ctrdatos.consulta(dato);
        }

        private void cargarTabla2(string datoRC)
        {
            List<AuxRecibo> list = new List<AuxRecibo>();
            CtrlRecibo _ctrdatos = new CtrlRecibo();
            dataGridView2.DataSource = _ctrdatos.consulta(datoRC);
        }

        //-------------------------------------------------------------------------
        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            string dato = txtDato.Text;
            cargarTabla(dato);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
          
        }

        //-------------------------------------------------------------------------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            AuxRecibo _recibo = new AuxRecibo();
            _recibo.Nombres = txtNombres.Text;
            _recibo.Apellidos = txtApellidos.Text;
            _recibo.Senda = txtSenda.Text;
            _recibo.Poligono = txtPoligono.Text;
            _recibo.N_casa = txtN_casa.Text;
            _recibo.Mes_es = cbMes.Text;
            _recibo.Cantidad = int.Parse(txtCantidad.Text);
            //_recibo.Otro = int.Parse(txtOCargo.Text);

            if (string.IsNullOrEmpty(_recibo.Nombres) || string.IsNullOrEmpty(_recibo.Apellidos) || string.IsNullOrEmpty(_recibo.Senda) || string.IsNullOrEmpty(_recibo.Poligono) || string.IsNullOrEmpty(_recibo.N_casa) || string.IsNullOrEmpty(_recibo.Mes_es))
            {
                MessageBox.Show("Debe llenar todos los campos", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CtrlRecibo ctrl = new CtrlRecibo();
                if (txtNum_recibo.Text != "")
                {
                    _recibo.Num_recibo = int.Parse(txtNum_recibo.Text);
                    
                }
                else
                {
                    bandera = ctrl.insertar(_recibo);
                }

                if (bandera)
                {
                    MessageBox.Show("Se guardaron los cambios exitosamente ", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    limpiar();
                    cargarTabla2(null);
                }
            }

        }
        //-------------------------------------------------------------------------

        private void limpiar()
        {
            txtId.Text = "";
            txtNum_recibo.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtSenda.Text = "";
            txtPoligono.Text = "";
            txtN_casa.Text = "";
            txtCantidad.Text = "";
            txtOCargo.Text = "";
            cbMes.Text = "";
        }
        private void recibo_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar3_Click(object sender, EventArgs e)
        {
            string datoRC = txtBuscar.Text;
            cargarTabla(datoRC);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    } 
}
