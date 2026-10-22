using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ClubDeportivo.Datos;

namespace ClubDeportivo
{
    internal class Usuario
    {

        public bool iniciarSesion(string nombre, string password)
        {
            ConexionDB conexionDB = new ConexionDB();

            using (MySqlConnection conexion = conexionDB.abrirConexion())
            {
                using (MySqlCommand comando =
                    new MySqlCommand("buscarUsuario", conexion))
                {
                    comando.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "p_nombreUsuario",
                        nombre
                    );

                    using (MySqlDataReader reader =
                        comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashGuardado =
                                reader.GetString("passwordHash");

                            return BCrypt.Net.BCrypt.Verify(
                                password,
                                hashGuardado
                            );
                        }

                        return false;
                    }
                }
            }
        }
    }
}
