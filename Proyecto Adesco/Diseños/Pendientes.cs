using MySql.Data.MySqlClient;
using Proyecto_Adesco.Clases;
using SharpCompress;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace Proyecto_Adesco
{
    public partial class Pendientes : Form
    {
        public Pendientes()
        {
            InitializeComponent();          
        }

        private void picRegresar_Click(object sender, EventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }

        private void Pendientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Visible = false;
        }

        private void CargarPendientes()
        {
            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Obtener la tabla "recibos" desde la base de datos
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM recibos", Conexion.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            // Crear un diccionario para almacenar el total de meses pendientes por persona
            Dictionary<string, int> mesesPendientesPorPersona = new Dictionary<string, int>();

            // Calcular la diferencia en meses entre la fecha actual y el mes de pago almacenado en la columna "mes_es"
            foreach (DataRow row in dt.Rows)
            {
                string mesPago = row["mes_es"].ToString();
                DateTime fechaPago = DateTime.ParseExact(mesPago, "MMMM", CultureInfo.CurrentCulture);
                int mesesPendientes = (fechaActual.Year - fechaPago.Year) * 12 + fechaActual.Month - fechaPago.Month;
                string nombrePersona = row["nombres"].ToString(); // Reemplaza "nombre" con el nombre de la columna que contiene el nombre de la persona en tu tabla "recibos"
                if (!mesesPendientesPorPersona.ContainsKey(nombrePersona))
                {
                    mesesPendientesPorPersona.Add(nombrePersona, 0);
                }
                mesesPendientesPorPersona[nombrePersona] += mesesPendientes;
            }

            // Crear un nuevo DataTable para mostrar el nombre de la persona y el total de meses pendientes
            DataTable dtPendientes = new DataTable();
            dtPendientes.Columns.Add("Nombre", typeof(string));
            dtPendientes.Columns.Add("Pendiente", typeof(int));

            // Agregar los datos del diccionario al DataTable
            foreach (var kvp in mesesPendientesPorPersona)
            {
                DataRow newRow = dtPendientes.NewRow();
                newRow["Nombre"] = kvp.Key;
                newRow["Pendiente"] = kvp.Value;
                dtPendientes.Rows.Add(newRow);
            }

            // Asignar el DataTable al DataGridView "dataGridView1"
            dataGridView1.DataSource = dtPendientes;
        }


        private void Pendientes_Load(object sender, EventArgs e)
        {
            CargarPendientes();
        }
    }
}
