using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using MySql.Data.MySqlClient;
using Proyecto_Adesco.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
        
        //------------------------------Imprime el recibo---------------------------
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //crearPDF();
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = DateTime.Now.ToString("ddMMyyHHmmss") + ".pdf";
            guardar.ShowDialog();
        }
        //---------------------------Codigo para generar un reporte------------------------------------
        private void crearPDF()
        {
            PdfWriter pdfWriter = new PdfWriter("C:\\Users\\trace\\Downloads\\Reporte.pdf");
            PdfDocument pdfDocument = new PdfDocument(pdfWriter);
            Document documento = new Document(pdfDocument, PageSize.LETTER);

            documento.SetMargins(60, 20, 55, 20);
            PdfFont fontcolumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontcontenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            string[] columnas = { "Num_recibo", "mes_es", "total", "cantidad", "otro", "nombres", "apellidos", "senda", "poligono", "n_casa", };
            float[] tamanios = { 4, 2, 4, 2, 2, 2, 2, 2, 2, 2  };
            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach(string columna in columnas) 
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontcolumnas)));
            }

            string sql = "SELECT Num_recibo, mes_es, total, cantidad, otro, nombres, apellidos, senda, poligono, n_casa FROM recibos";
            MySqlConnection conexion = Conexion.GetConnection();
            conexion.Open();

            MySqlCommand command = new MySqlCommand(sql, conexion);
            MySqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                tabla.AddCell(new Cell().Add(new Paragraph(reader["Num_recibo"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["mes_es"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["total"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["cantidad"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["otro"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["nombres"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["apellidos"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["senda"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["poligono"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["n_casa"].ToString()).SetFont(fontcontenido)));
            }
            

            documento.Add(tabla);
            documento.Close();

            
        }

        //----------------------------------------------------------------------------------------------
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
           
            int indice_fila = dgvRecibo.Rows.Add();
            DataGridViewRow fila = dgvRecibo.Rows[indice_fila];

            fila.Cells["mes"].Value = cbMes.Text;
            fila.Cells["codigo"].Value = txtCodigo.Text;
            fila.Cells["nombres"].Value = txtNombres.Text;
            fila.Cells["apellidos"].Value = txtApellidos.Text;
            fila.Cells["senda"].Value = txtSenda.Text;
            fila.Cells["poligono"].Value = txtPoligono.Text;
            fila.Cells["n_casa"].Value = txtN_casa.Text;
            fila.Cells["cantidad"].Value = txtCantidad.Text;
            fila.Cells["otro"].Value = txtOCargo.Text;

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
            //-----------------------------------
            
            
            
            
            //fila.Cells["total"].Value = decimal.Parse(txtCantidad.Text) * decimal.Parse(txtOCargo.Text);

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
        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            string dato = txtDato.Text;
            cargarTabla(dato);
        }
        private void btnBuscar3_Click(object sender, EventArgs e)
        {
            string datoRC = txtBuscar.Text;
            cargarTabla(datoRC);
        }
        private void recibo_Load(object sender, EventArgs e)
        {
            dgvRecibo.Columns.Add("mes", "Mes");
            dgvRecibo.Columns.Add("codigo", "Codigo");
            dgvRecibo.Columns.Add("nombres", "Nombres");
            dgvRecibo.Columns.Add("apellidos", "Apellidos");
            dgvRecibo.Columns.Add("senda", "Senda");
            dgvRecibo.Columns.Add("poligono", "Poligono");
            dgvRecibo.Columns.Add("n_casa", "N° Casa");
            dgvRecibo.Columns.Add("cantidad", "Cantidad");
            dgvRecibo.Columns.Add("otro", "Otro");
            dgvRecibo.Columns.Add("total", "Total");
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
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

        
        //-------------------------------------------------------------------------
    }
}
