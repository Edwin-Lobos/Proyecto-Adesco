using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                sql = "SELECT Num_recibo, nombres, apellidos, senda, poligono, n_casa, cantidad, mes_es, total, otro FROM recibos ORDER BY nombres ASC";
            }
            else
            {
                sql = "SELECT Num_recibo, nombres, apellidos, senda, poligono, n_casa, cantidad, mes_es, total, otro FROM recibos WHERE nombres LIKE '%" + datoRC + "%' OR apellidos LIKE '%" + datoRC + "%' OR senda LIKE '%" + datoRC + "%' OR poligono LIKE '%" + datoRC + "%' OR n_casa LIKE '%" + datoRC + "%' OR cantidad LIKE '%" + datoRC + "%' OR mes_es LIKE '%" + datoRC + "%' OR total LIKE '%" + datoRC + "%' OR otro LIKE '%" + datoRC + "%' ORDER BY nombres ASC";
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
                    //_recibo.Total = double.Parse(reader[2].ToString());
                    _recibo.Cantidad = double.Parse(reader[3].ToString());
                    _recibo.Otro = double.Parse(reader[4].ToString());
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

        public bool insertar(AuxRecibo datoRC)
        {
            bool bandera = false;

            string sql = "INSERT INTO recibos (nombres, apellidos, senda, poligono, n_casa, cantidad, mes_es, total, otro) VALUES ('" + datoRC.Nombres + "', '" + datoRC.Apellidos + "', '" + datoRC.Senda + "', '" + datoRC.Poligono + "', '" + datoRC.N_casa + "', '" + datoRC.Cantidad + "', '" + datoRC.Mes_es + "', '" + "', '" + datoRC.Total +  datoRC.Otro + "')";

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
