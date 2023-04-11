using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Proyecto_Adesco.Clases;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Globalization;
using static System.Resources.ResXFileRef;

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



        //---------------------------------------------------------------------------------------------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbxMes_es.Text) || string.IsNullOrEmpty(txtCantidad.Text))
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
                fila.Cells["total"].Value = decimal.Parse(txtCantidad.Text) + (string.IsNullOrEmpty(txtOCargo.Text) ? 0 : decimal.Parse(txtOCargo.Text));
                //fila.Cells["totalenletras"].Value = ConvertirNumeroALetras((decimal)fila.Cells["total"].Value);
                fila.Cells["codigo"].Value = txtCodigo.Text;
                fila.Cells["nota"].Value = txtNota.Text;


                // Enviar los datos a la base de datos
                using (MySqlConnection conexion = Conexion.GetConnection())
                {
                    conexion.Open();
                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        // Verificar si el valor de la columna total es nulo
                        if (row.Cells["nombres"].Value != null)
                        {
                            MySqlCommand cmd = new MySqlCommand("INSERT INTO recibos (nombres, apellidos, senda, poligono, n_casa, cantidad, mes_es, otro, total, codigo, nota) VALUES (@nombres, @apellidos, @senda, @poligono, @n_casa, @cantidad, @mes_es, @otro, @total, @codigo, @nota)", conexion);
                            cmd.Parameters.AddWithValue("@nombres", row.Cells["nombres"].Value);
                            cmd.Parameters.AddWithValue("@apellidos", row.Cells["apellidos"].Value);
                            cmd.Parameters.AddWithValue("@senda", row.Cells["senda"].Value);
                            cmd.Parameters.AddWithValue("@poligono", row.Cells["poligono"].Value);
                            cmd.Parameters.AddWithValue("@n_casa", row.Cells["n_casa"].Value);
                            cmd.Parameters.AddWithValue("@cantidad", row.Cells["cantidad"].Value);                         
                            cmd.Parameters.AddWithValue("@mes_es", row.Cells["mes_es"].Value);
                            cmd.Parameters.AddWithValue("@otro", row.Cells["otro"].Value);
                            cmd.Parameters.AddWithValue("@total", row.Cells["total"].Value);
                            cmd.Parameters.AddWithValue("@codigo", row.Cells["codigo"].Value);
                            cmd.Parameters.AddWithValue("@nota", row.Cells["nota"].Value);
                            //cmd.Parameters.AddWithValue("@totalenletras", row.Cells["totalenletras"].Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conexion.Close();
                    cargarTabla2(null);
                    dataGridView3.Rows.Clear(); // Limpia las filas del DataGridView3

                }

                MessageBox.Show("Los datos se han guardado correctamente.");
                MySqlCommand cmdUltimaFila = new MySqlCommand("SELECT * FROM recibos ORDER BY Num_recibo DESC LIMIT 1", Conexion.GetConnection());
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmdUltimaFila);
                DataTable dtUltimaFila = new DataTable();
                adapter.Fill(dtUltimaFila);

                ReciboVS formRecibo = new ReciboVS(dtUltimaFila);
                formRecibo.Show();
            }


        }




        //-------------------------------------------------------------------------
        public static string ConvertirNumeroALetras(decimal numero)
        {
            string[] unidades = new string[] { "cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
            string[] decenas = new string[] { "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };
            string[] veintenas = new string[] { "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
            string[] centenas = new string[] { "cien", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

            int valorEntero = (int)numero;
            decimal valorDecimal = numero - valorEntero;
            string valorEnteroEnLetras = "";
            string valorDecimalEnLetras = "";

            if (valorEntero == 0)
            {
                valorEnteroEnLetras = unidades[0];
            }
            else if (valorEntero < 10)
            {
                valorEnteroEnLetras = unidades[valorEntero];
            }
            else if (valorEntero < 20)
            {
                valorEnteroEnLetras = decenas[valorEntero - 10];
            }
            else if (valorEntero < 100)
            {
                int decena = valorEntero / 10;
                int unidad = valorEntero % 10;
                valorEnteroEnLetras = veintenas[decena - 2];
                if (unidad > 0)
                {
                    valorEnteroEnLetras += " y " + unidades[unidad];
                }
            }
            else if (valorEntero == 100)
            {
                valorEnteroEnLetras = centenas[0];
            }
            else if (valorEntero < 1000)
            {
                int centena = valorEntero / 100;
                int resto = valorEntero % 100;
                valorEnteroEnLetras = centenas[centena - 1];
                if (resto > 0)
                {
                    valorEnteroEnLetras += " " + ConvertirNumeroALetras(resto);
                }
            }

            if (valorDecimal > 0)
            {
                int centavos = (int)(valorDecimal * 100);
                string centavosEnLetras = ConvertirNumeroALetras(centavos);

                if (centavosEnLetras == "uno")
                {
                    valorDecimalEnLetras = " con un centavo";
                }
                else if (centavosEnLetras != "cero")
                {
                    valorDecimalEnLetras = " con " + centavosEnLetras + " centavos";
                }
            }


            if (valorDecimalEnLetras == "" && valorEnteroEnLetras != "")
            {
                valorEnteroEnLetras += " dólares";
            }
            else if (valorEnteroEnLetras != "")
            {
                valorEnteroEnLetras += " con " + valorDecimalEnLetras;
            }

            return valorEnteroEnLetras;
        }










        //---------------------------------------------------------------------------
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
        
        
        //---------------------------------------------------------------------------
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
        //---------------------------------------------------------------------------
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


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
    
}
