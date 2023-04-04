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
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.IO.Font.Constants;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;
using System.Globalization;

namespace Proyecto_Adesco
{
    public partial class Reporte : Form
    {

        public Reporte()
        {
            InitializeComponent();
            cargarTabla2(null);
        }

        private void picRegresar_Click(object sender, EventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }

        private void Reporte_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {

        }
        private void cargarTabla2(string datoRC)
        {
            List<AuxRecibo> list = new List<AuxRecibo>();
            CtrlRecibo _ctrdatos = new CtrlRecibo();
            dataGridView1.DataSource = _ctrdatos.consulta(datoRC);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dato = cbxDato.Text;
            cargarTabla2(dato);
        }

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
            crearPDF();
        }

        private void crearPDF()
        {
            //------------------------------------Crea el pdf---------------------------------------------
            PdfWriter pdfWriter = new PdfWriter("Reporte.pdf");
            PdfDocument pdfDocument = new PdfDocument(pdfWriter);
            PageSize tamanio = new PageSize(792, 612);
            Document documento = new Document(pdfDocument, tamanio);

            documento.SetMargins(60, 20, 55, 20);
            PdfFont fontcolumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontcontenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            string[] columnas = { "Nombres", "Apellidos", "Senda", "Poligono", "N° Casa", "Mes(es)", "N° Recibo", "Cantidad", "Otro(cargo)", "Total", };
            float[] tamanios = { 3, 3, 1, 2, 2, 3, 2, 1, 2, 1 };
            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (string columna in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontcolumnas)));
            }

            string sql = "SELECT nombres, apellidos, senda, poligono, n_casa, mes_es, Num_recibo, cantidad, otro, total FROM recibos";
            MySqlConnection conexion = Conexion.GetConnection();
            conexion.Open();

            MySqlCommand command = new MySqlCommand(sql, conexion);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                tabla.AddCell(new Cell().Add(new Paragraph(reader["nombres"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["apellidos"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["senda"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["poligono"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["n_casa"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["mes_es"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["Num_recibo"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph("$" + reader["cantidad"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph("$" + reader["otro"].ToString()).SetFont(fontcontenido)));
                tabla.AddCell(new Cell().Add(new Paragraph("$" + reader["total"].ToString()).SetFont(fontcontenido)));

            }


            documento.Add(tabla);
            documento.Close();

            //--------------------------------Inserta logo, fecha y hora al pdf-----------------------------------
            var logo = new iText.Layout.Element.Image(ImageDataFactory.Create("C:\\Users\\trace\\source\\repos\\Edwin-Lobos\\Proyecto-Adesco\\Proyecto Adesco\\Resources\\logopdf.png")).SetWidth(50);
            var plogo = new Paragraph("").Add(logo);

            var titulo = new Paragraph("Reporte de Personas");
            titulo.SetTextAlignment(TextAlignment.CENTER);
            titulo.SetFontSize(12);

            var dfecha = DateTime.Now.ToString("dd-MM-yyyy");
            var dhora = DateTime.Now.ToString("hh:mm:ss");
            var fecha = new Paragraph("Fecha: " + dfecha + "\nHora: " + dhora);
            fecha.SetFontSize(12);

            PdfDocument pdfdoc = new PdfDocument(new PdfReader("Reporte.pdf"), new PdfWriter("ReportePersonas.pdf"));
            Document doc = new Document(pdfdoc);

            int numeros = pdfdoc.GetNumberOfPages();

            for (int i = 1; i <= numeros; i++)
            {
                PdfPage pagina = pdfdoc.GetPage(i);
                float y = pdfdoc.GetPage(i).GetPageSize().GetTop() - 15;
                doc.ShowTextAligned(plogo, 40, y, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(titulo, 150, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(fecha, 520, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

                doc.ShowTextAligned(new Paragraph(string.Format("Página {0} de {1}", i, numeros)), pdfdoc.GetPage(i).GetPageSize().GetWidth() / 2, pdfdoc.GetPage(i).GetPageSize().GetBottom() + 30, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);



            }
            doc.Close();
            MessageBox.Show("Reporte creado correctamente", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
