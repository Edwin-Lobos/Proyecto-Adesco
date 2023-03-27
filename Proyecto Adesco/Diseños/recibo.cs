using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Proyecto_Adesco.Clases;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System.Data.SqlClient;
using System.Linq;

namespace Proyecto_Adesco
{
    public partial class recibo : Form
    {
        

        public recibo()
        {
            InitializeComponent();
            cargarTabla(null);
            cargarTabla2(null);
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
        private void btnBuscar_Click_1(object sender, EventArgs e)
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



        //---------------------------------------------------------------------------------------------
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombres.Text) || string.IsNullOrEmpty(txtApellidos.Text) || string.IsNullOrEmpty(txtSenda.Text) || string.IsNullOrEmpty(txtOCargo.Text) || string.IsNullOrEmpty(txtN_casa.Text) || string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Debe llenar el campo cantidad", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Agregar fila a la DataGridView
                int indice_fila = dataGridView3.Rows.Add();
                DataGridViewRow fila = dataGridView3.Rows[indice_fila];

                fila.Cells["nombres"].Value = txtNombres.Text;
                fila.Cells["apellidos"].Value = txtApellidos.Text;
                fila.Cells["senda"].Value = txtSenda.Text;
                fila.Cells["poligono"].Value = txtPoligono.Text;
                fila.Cells["n_casa"].Value = txtN_casa.Text;
                fila.Cells["cantidad"].Value = txtCantidad.Text;
                fila.Cells["mes_es"].Value = string.Join(", ", lbxMes_es.SelectedItems.Cast<string>());
                fila.Cells["otro"].Value = txtOCargo.Text;
                fila.Cells["total"].Value = decimal.Parse(txtCantidad.Text) + decimal.Parse(txtOCargo.Text);


                // Enviar los datos a la base de datos
                using (MySqlConnection conexion = Conexion.GetConnection())
                {
                    conexion.Open();
                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        // Verificar si el valor de la columna total es nulo
                        if (row.Cells["nombres"].Value != null)
                        {
                            MySqlCommand cmd = new MySqlCommand("INSERT INTO recibos (nombres, apellidos, senda, poligono, n_casa, cantidad, mes_es, otro, total) VALUES (@nombres, @apellidos, @senda, @poligono, @n_casa, @cantidad, @mes_es, @otro, @total)", conexion);
                            cmd.Parameters.AddWithValue("@nombres", row.Cells["nombres"].Value);
                            cmd.Parameters.AddWithValue("@apellidos", row.Cells["apellidos"].Value);
                            cmd.Parameters.AddWithValue("@senda", row.Cells["senda"].Value);
                            cmd.Parameters.AddWithValue("@poligono", row.Cells["poligono"].Value);
                            cmd.Parameters.AddWithValue("@n_casa", row.Cells["n_casa"].Value);
                            cmd.Parameters.AddWithValue("@cantidad", row.Cells["cantidad"].Value);
                            cmd.Parameters.AddWithValue("@mes_es", row.Cells["mes_es"].Value);
                            cmd.Parameters.AddWithValue("@otro", row.Cells["otro"].Value);
                            cmd.Parameters.AddWithValue("@total", row.Cells["total"].Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conexion.Close();
                    cargarTabla2(null);
                }

                MessageBox.Show("Los datos se han guardado correctamente.");
            }
        }




        //-------------------------------------------------------------------------








        private void recibo_Load(object sender, EventArgs e)
        {
            
        }
        private void limpiar()
        {
            txtId.Text = "";
            txtNum_recibo.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtSenda.Text = "";
            txtPoligono.Text = "";
            txtCodigo.Text = "";
            txtN_casa.Text = "";
            txtCantidad.Text = "";
            txtOCargo.Text = "";
            lbxMes_es.ClearSelected();
        }  
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            DialogResult resultado = MessageBox.Show("¿Seguro que desea eliminar el registro?", "Salir", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                int id_num = int.Parse(txtId.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString());
                CtrlRecibo _ctrl = new CtrlRecibo();
                bandera = _ctrl.eliminar(id_num);

                if (bandera)
                {
                    MessageBox.Show("Registro Eliminado", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    cargarTabla2(null);
                }
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
        private void btnBuscar3_Click(object sender, EventArgs e)
        {
            string datoRC = txtBuscar.Text;
            cargarTabla2(datoRC);
        }
        //-------------------------------------------------------------------------
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void label11_Click(object sender, EventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }

        //-------------Imprime datos desde la imagen del datagriview---------------
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }    

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = DateTime.Now.ToString("dd-MM-yyyy.pdf");
           

            string paginahtml_texto = "<table><tr><td><Hola Mundo></td></tr></table>";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using(FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                        Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    using (StringReader sr = new StringReader(paginahtml_texto))
                    {
                        XMLWorkerHelper.GetInstance()
                            .ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                }
                

            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            limpiar();
        }

       
    }
    
}
