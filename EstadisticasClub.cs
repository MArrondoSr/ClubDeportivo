using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ClubDeportivo.Datos;

namespace ClubDeportivo
{
    internal static class EstadisticasClub
    {
        // Atributo estático compartido por toda la aplicación.
        public static readonly string NombreClub = "POO GYM";

        // MÉTODO ESTÁTICO
        public static int ContarSocios()
        {
            ConexionDB conexionDB = new ConexionDB();

            using (MySqlConnection conexion = conexionDB.abrirConexion())
            {
                string sql = @"SELECT COUNT(DISTINCT idCliente)
                               FROM carnets";

                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }

        // MÉTODO ESTÁTICO: cuenta los clientes que no son socios.
        public static int ContarNoSocios()
        {
            ConexionDB conexionDB = new ConexionDB();

            using (MySqlConnection conexion = conexionDB.abrirConexion())
            {
                string sql = @"SELECT COUNT(*)
                       FROM clientes c
                       WHERE NOT EXISTS (
                           SELECT 1
                           FROM carnets ca
                           WHERE ca.idCliente = c.idCliente
                       )";

                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }
    }
}
