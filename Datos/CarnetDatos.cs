using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    
        internal class CarnetDatos
        {
        public int generarCarnet(int idCliente)
        {
            ConexionDB conexionDB = new ConexionDB();

            using (MySqlConnection conexion = conexionDB.abrirConexion())
            {
                // PERSISTENCIA:
                // Registramos el carnet asociado al identificador
                // interno del cliente, no a su documento.
                string sql = @"INSERT INTO carnets (idCliente)
                       VALUES (@idCliente)";

                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@idCliente", idCliente);

                    comando.ExecuteNonQuery();

                    // MySQL genera automáticamente el número de carnet.
                    // Recuperamos ese valor para crear el objeto Carnet.
                    return (int)comando.LastInsertedId;
                }
            }
        }

        public Carnet? buscarCarnetPorIdCliente(int idCliente)
        {
            ConexionDB conexionDB = new ConexionDB();

            using (MySqlConnection conexion = conexionDB.abrirConexion())
            {
                // ASOCIACIÓN ENTRE OBJETOS:
                // Buscamos el carnet que pertenece al cliente
                // identificado mediante idCliente.
                string sql = @"SELECT nroCarnet
                       FROM carnets
                       WHERE idCliente = @idCliente";

                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@idCliente", idCliente);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Carnet(
                                Convert.ToInt32(reader["nroCarnet"])
                            );
                        }
                    }
                }
            }

            return null;
        }

        // PERSISTENCIA Y TRANSACCIONES:
        // Este método utiliza una conexión y una transacción
        // recibidas desde otra clase.
        //
        // No abre una nueva conexión ni confirma la transacción.
        // Así podemos registrar el pago y emitir el carnet
        // como una única operación en MySQL.
        // SOBRECARGA

        public int generarCarnet(
            int idCliente,
            MySqlConnection conexion,
            MySqlTransaction transaccion)
        {
            string sql = @"INSERT INTO carnets (idCliente)
                   VALUES (@idCliente)";

            using (MySqlCommand comando =
                new MySqlCommand(sql, conexion, transaccion))
            {
                comando.Parameters.AddWithValue("@idCliente", idCliente);

                comando.ExecuteNonQuery();

                return Convert.ToInt32(comando.LastInsertedId);
            }
        }
    }
    }

