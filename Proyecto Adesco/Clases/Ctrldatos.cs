using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Adesco
{
    internal class Ctrldatos : Conexion
    {
        //---------------Conexión con la base para el módulo de registro de personas------------------
        public List<object> consulta(string dato)
        {
            MySqlDataReader reader;
            List<object> lista = new List<object>();
            string sql;

            if (dato == null)
            {
                sql = "SELECT id, nombres, apellidos, senda, poligono, n_casa, Telefono, codigo FROM datos ORDER BY nombres ASC";
            }
            else
            {
                sql = "SELECT id, nombres, apellidos, senda, poligono, n_casa, Telefono, codigo FROM datos WHERE nombres LIKE '%" + dato + "%' OR apellidos LIKE '%" + dato + "%' OR senda LIKE '%" + dato + "%' OR poligono LIKE '%" + dato + "%' OR n_casa LIKE '%" + dato + "%' OR Telefono LIKE '%" + dato + "%' OR codigo LIKE '%" + dato + "%' ORDER BY nombres ASC";
            }

            try
            {
                MySqlConnection conexion = Conexion.GetConnection();
                conexion.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    DatosBD _datos = new DatosBD();
                    _datos.Id = int.Parse(reader.GetString(0));
                    _datos.Nombres = reader.GetString("nombres");
                    _datos.Apellidos = reader.GetString("apellidos");
                    _datos.Senda = reader.GetString("senda");
                    _datos.Poligono = reader.GetString("poligono");
                    _datos.N_casa = reader.GetString("n_casa");
                    _datos.Telefono = int.Parse(reader.GetString(6));
                    _datos.Codigo = reader.GetString("codigo");

                    lista.Add(_datos);

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return lista;
        }

        //-----------Control para el ingreso de datos en el módulo de registro de personas------------
        public bool insertar(DatosBD datos)
        {
            bool bandera = false;

            string sql = "INSERT INTO datos (nombres, apellidos, senda, poligono, n_casa, Telefono, codigo) VALUES ('"+datos.Nombres+ "', '"+datos.Apellidos+ "', '"+datos.Senda+"', '"+datos.Poligono+"', '"+datos.N_casa+ "', '"+datos.Telefono+"', '" + datos.Codigo+"')";

            try
            {
                MySqlConnection conexion = Conexion.GetConnection();
                conexion.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.ExecuteNonQuery();
                bandera = true;


            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }
            return bandera;
        }

        public bool actualizar(DatosBD datos)
        {
            bool bandera = false;

            string sql = "UPDATE datos SET nombres='" + datos.Nombres + "', apellidos='" + datos.Apellidos + "', senda='" + datos.Senda + "', poligono='" + datos.Poligono + "', n_casa='" + datos.N_casa + "', Telefono='" + datos.Telefono + "', codigo='" + datos.Codigo + "' WHERE id= '" + datos.Id + "'";

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

        public bool eliminar(int id)
        {
            bool bandera = false;

            string sql = "DELETE FROM datos WHERE id= '" + id + "'";

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
    //-------------------------------------------------------------------------------------------------
}
