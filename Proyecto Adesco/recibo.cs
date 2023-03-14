using MySql.Data.MySqlClient;
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
        //-------------------Botón para buscar------------------------------
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

        private void cargarTabla(string dato)
        {
            List<DatosBD> list = new List<DatosBD>();
            Ctrldatos _ctrdatos = new Ctrldatos();
            dataGridView1.DataSource = _ctrdatos.consulta(dato);
        }

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
    } 
}
