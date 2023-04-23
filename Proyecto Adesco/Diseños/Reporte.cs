using MySql.Data.MySqlClient;
using Proyecto_Adesco.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices;
using System.Globalization;
using Org.BouncyCastle.Asn1.X500;
using Point = System.Drawing.Point;
using System.IO;
using System.Drawing.Printing;

namespace Proyecto_Adesco
{
    public partial class Reporte : Form 
    {

        public Reporte()
        {
            InitializeComponent();
            
        }

        private void picRegresar_Click(object sender, EventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }

        private void Reporte_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }

        


        //----------------------------------------------------------------------------------------------------------
        public List<object> consulta(string datoRC)
        {
            MySqlDataReader reader;
            List<object> lista = new List<object>();
            string sql;

            if (datoRC == null)
            {
                sql = "SELECT Num_recibo, nombres, apellidos, senda, poligono, n_casa, cantidad, mes_es, total, otro FROM recibos ORDER BY mes_es ASC";
            }
            else
            {
                sql = "SELECT Num_recibo, nombres, apellidos, senda, poligono, n_casa, cantidad, mes_es, total, otro FROM recibos WHERE nombres LIKE '%" + datoRC + "%' OR apellidos LIKE '%" + datoRC + "%' OR senda LIKE '%" + datoRC + "%' OR poligono LIKE '%" + datoRC + "%' OR n_casa LIKE '%" + datoRC + "%' OR cantidad LIKE '%" + datoRC + "%' OR mes_es LIKE '%" + datoRC + "%' OR total LIKE '%" + datoRC + "%' OR otro LIKE '%" + datoRC + "%' ORDER BY mes_es ASC";
            }

            try
            {
                MySqlConnection conexion = Conexion.GetConnection();
                conexion.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    AuxRecibo _recibo = new AuxRecibo();
                    _recibo.Num_recibo = int.Parse(reader.GetString(0));
                    _recibo.Mes_es = reader.GetString("mes_es");
                    double total;
                    bool success = double.TryParse(reader[8].ToString(), out total);
                    if (success)
                    {
                        _recibo.Total = total;
                    }
                    _recibo.Cantidad = double.Parse(reader[6].ToString());
                    _recibo.Otro = double.Parse(reader[9].ToString());
                    _recibo.Nombres = reader.GetString("nombres");
                    _recibo.Apellidos = reader.GetString("apellidos");
                    _recibo.Senda = reader.GetString("senda");
                    _recibo.Poligono = reader.GetString("poligono");
                    _recibo.N_casa = reader.GetString("n_casa");

                    lista.Add(_recibo);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return lista;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {




        }
        private void Reporte_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SELECT Num_recibo, nombres, apellidos, senda, poligono, n_casa, codigo, mes_es, cantidad, otro, total, DATE_FORMAT(fecha, '%Y') AS fecha_year FROM recibos ORDER BY Num_recibo DESC", Conexion.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            dt.Columns["fecha_year"].ColumnName = "fecha"; // Renombrar la columna de fecha/hora
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
        private void label11_Click(object sender, EventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void cbxDato_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Reporte_Resize(object sender, EventArgs e)
        {


        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            // Obtener el valor seleccionado del ComboBox "cbxDato"
            string mesSeleccionado = cbxDato.SelectedItem.ToString();

            // Obtener el valor seleccionado del DateTimePicker "dtpAño"
            int añoSeleccionado = dtpAño.Value.Year;

            // Obtener el mes correspondiente al mes seleccionado
            int mes = DateTime.ParseExact(mesSeleccionado, "MMMM", CultureInfo.CurrentCulture).Month;

            // Crear la consulta SQL filtrada por el mes y año seleccionados
            string consulta = "SELECT Num_recibo, nombres, apellidos, senda, poligono, n_casa, codigo, mes_es, cantidad, otro, total, DATE_FORMAT(fecha, '%Y') AS fecha FROM recibos WHERE MONTH(fecha) = " + mes + " AND YEAR(fecha) = " + añoSeleccionado + " ORDER BY Num_recibo DESC";

            // Crear un objeto DataTable y llenarlo con los datos de la consulta filtrada
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(consulta, Conexion.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            // Actualizar el origen de datos del informe con la consulta filtrada
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private void btnGenerarRP_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
            saveDialog.Title = "Guardar como";
            saveDialog.FileName = "Reporte.pdf";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string filenameExtension;

                byte[] pdfBytes;

                pdfBytes = reportViewer1.LocalReport.Render(
                    "PDF", null, out mimeType, out encoding,
                    out filenameExtension, out streamids, out warnings);

                using (MemoryStream pdfStream = new MemoryStream(pdfBytes))
                {
                    // Guardar el archivo PDF en la ubicación especificada
                    File.WriteAllBytes(saveDialog.FileName, pdfStream.ToArray());

                    MessageBox.Show("El archivo se ha guardado correctamente.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

      
        //----------------------------------------------------------------------------------------------------------




    }
}
