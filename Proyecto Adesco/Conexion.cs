using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Adesco
{
    //--------------------------------Conexion a la base--------------------------------------
    internal class Conexion
    {

        public MySqlConnection GetConnection()
        {

            string servidor = "sql355.main-hosting.eu";
            string puerto = "3306";
            string usuario = "u433272284_edwin";
            string password = "$8k4W~!qb4P";
            string bd = "u433272284_adesco";

            string cadenaconexion = "Server=" + servidor + "; port=" + puerto + "; user= " + usuario +
                "; password=" + password + "; database=" + bd;

            MySqlConnection conexion = new MySqlConnection(cadenaconexion);
            return conexion;

        }
    }
}
