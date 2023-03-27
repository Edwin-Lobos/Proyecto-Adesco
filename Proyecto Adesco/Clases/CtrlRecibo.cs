using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Adesco.Clases
{
    internal class CtrlRecibo : Conexion
    {

        //---------------Conexión con la base para el módulo de registro de personas------------------
        public List<object> consulta(string datoRC)
        {
            MySqlDataReader reader;
            List<object> lista = new List<object>();
            string sql;

            if (datoRC == null)
            {
                sql = "SELECT Num_recibo, nombres, apellidos, senda, poligono, n_casa, cantidad, mes_es, total, otro FROM recibos ORDER BY Num_recibo ASC";
            }
            else
            {
                sql = "SELECT Num_recibo, nombres, apellidos, senda, poligono, n_casa, cantidad, mes_es, total, otro FROM recibos WHERE nombres LIKE '%" + datoRC + "%' OR apellidos LIKE '%" + datoRC + "%' OR senda LIKE '%" + datoRC + "%' OR poligono LIKE '%" + datoRC + "%' OR n_casa LIKE '%" + datoRC + "%' OR cantidad LIKE '%" + datoRC + "%' OR mes_es LIKE '%" + datoRC + "%' OR total LIKE '%" + datoRC + "%' OR otro LIKE '%" + datoRC + "%' ORDER BY Num_recibo ASC";
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








        public void Insertar(AuxRecibo persona)
        {
            try
            {
                MySqlConnection conexion = Conexion.GetConnection();
                conexion.Open();

                string query = "INSERT INTO Persona (nombres, apellidos, senda, poligono, n_casa, cantidad, mes_es, total, otro) VALUES (@nombres, @apellidos, @senda, @poligono, @n_casa, @cantidad, @mes_es, @total, @otro)";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@nombres", persona.Nombres);
                comando.Parameters.AddWithValue("@apellidos", persona.Apellidos);
                comando.Parameters.AddWithValue("@senda", persona.Senda);
                comando.Parameters.AddWithValue("@poligono", persona.Poligono);
                comando.Parameters.AddWithValue("@n_casa", persona.N_casa);
                comando.Parameters.AddWithValue("@cantidad", persona.Cantidad);
                comando.Parameters.AddWithValue("@mes_es", persona.Mes_es);
                comando.Parameters.AddWithValue("@total", persona.Total);
                comando.Parameters.AddWithValue("@otro", persona.Otro);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
                
            }
           
        }


        public bool eliminar(int Num_id)
        {
            bool bandera = false;

            string sql = "DELETE FROM recibos WHERE Num_recibo= '" + Num_id + "'";

            try
            {
                MySqlConnection conexion = Conexion.GetConnection();
                conexion.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.ExecuteNonQuery();
                bandera = true;


            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }
            return bandera;
        }

    }
}
