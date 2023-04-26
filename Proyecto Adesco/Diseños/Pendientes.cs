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


        private void Pendientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }




        private void Pendientes_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string cadenaConexion = "server=sql355.main-hosting.eu;database=u433272284_adesco;uid=u433272284_edwin;pwd=$8k4W~!qb4P;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();

            string consulta = "SELECT DATEDIFF(fecha_fin, fecha_inicio) as diferencia FROM tabla_fechas";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);

            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                int diferenciaEnDias = reader.GetInt32("diferencia");

                // Asignamos el resultado al DataGridView
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView1);
                fila.Cells[0].Value = diferenciaEnDias.ToString();
                dataGridView1.Rows.Add(fila);
            }

            reader.Close();
            conexion.Close();

        }
    }
}
