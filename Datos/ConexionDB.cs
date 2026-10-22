using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClubDeportivo.Datos
{
    class ConexionDB
    {
        private string cadenaConexion =
        "Server=localhost;" +
        "Port=3306;" +
        "Database=club_deportivo;" +
        "Uid=club_app;" +
        "Pwd=grupo14;"            ;

        private MySqlConnection conexion;

        public ConexionDB()
        {
            conexion = new MySqlConnection(cadenaConexion);
        }

        public MySqlConnection abrirConexion()
        {
            conexion.Open();
            return conexion;
        }
    }
}
