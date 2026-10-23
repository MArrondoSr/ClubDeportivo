using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ClubDeportivo.Datos
{
    internal class CuotaDatos
    {
        // PERSISTENCIA:
        // Registra en MySQL el período mensual abonado
        // por un socio del gimnasio.
        //
        // TRANSACCIÓN:
        // Recibimos la conexión y la transacción desde
        // AsociacionDatos. No abrimos otra conexión ni
        // ejecutamos Commit(), porque el pago, el carnet
        // y la primera cuota deben confirmarse juntos.
        public int registrarCuota(
            int nroCarnet,
            int idPago,
            DateTime fechaInicio,
            DateTime fechaVencimiento,
            decimal importe,
            MySqlConnection conexion,
            MySqlTransaction transaccion)
        {
            string sql = @"INSERT INTO cuotas
                           (nroCarnet, idPago, fechaInicio,
                            fechaVencimiento, importe)
                           VALUES
                           (@nroCarnet, @idPago, @fechaInicio,
                            @fechaVencimiento, @importe)";

            using (MySqlCommand comando =
                new MySqlCommand(sql, conexion, transaccion))
            {
                comando.Parameters.AddWithValue(
                    "@nroCarnet", nroCarnet);

                comando.Parameters.AddWithValue(
                    "@idPago", idPago);

                comando.Parameters.AddWithValue(
                    "@fechaInicio", fechaInicio.Date);

                comando.Parameters.AddWithValue(
                    "@fechaVencimiento", fechaVencimiento.Date);

                comando.Parameters.AddWithValue(
                    "@importe", importe);

                comando.ExecuteNonQuery();

                // MySQL genera automáticamente el idCuota.
                return Convert.ToInt32(comando.LastInsertedId);
            }
        }

        // PERSISTENCIA:
        // Consulta la última fecha de vencimiento registrada
        // para un socio, identificado por su número de carnet.
        //
        // REGLA DE NEGOCIO:
        // Esta fecha permite calcular el comienzo de la próxima
        // cuota mensual.
        //
        // Si el socio paga anticipadamente, la nueva cuota
        // comenzará en el vencimiento anterior, conservando
        // los días que todavía tenía abonados.
        //
        // Si no existen cuotas registradas, devuelve null.
        // Esto puede suceder con socios incorporados antes
        // de implementar la tabla cuotas.
        //
        // DateTime? es un tipo nullable: puede contener
        // una fecha válida o el valor null.

        public DateTime? buscarUltimoVencimiento(int nroCarnet)
        {
            ConexionDB conexionDB = new ConexionDB();

            using (MySqlConnection conexion = conexionDB.abrirConexion())
            {
                string sql = @"SELECT MAX(fechaVencimiento)
                       FROM cuotas
                       WHERE nroCarnet = @nroCarnet";

                using (MySqlCommand comando =
                    new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@nroCarnet", nroCarnet);

                    object resultado = comando.ExecuteScalar();

                    // MAX devuelve NULL cuando el socio
                    // todavía no tiene cuotas registradas.
                    if (resultado == null || resultado == DBNull.Value)
                    {
                        return null;
                    }

                    return Convert.ToDateTime(resultado);
                }
            }
        }

        // SOBRECARGA Y TRANSACCIONES:
        //
        // Consulta el último vencimiento utilizando una conexión
        // y una transacción recibidas desde otra clase.
        //
        // Esto permite que la renovación consulte el período
        // anterior y registre el nuevo pago y la nueva cuota
        // dentro de una misma operación de base de datos.
        //
        // No abre una conexión nueva ni ejecuta Commit().

        public DateTime? buscarUltimoVencimiento(
            int nroCarnet,
            MySqlConnection conexion,
            MySqlTransaction transaccion)
        {
            string sql = @"SELECT MAX(fechaVencimiento)
                   FROM cuotas
                   WHERE nroCarnet = @nroCarnet";

            using (MySqlCommand comando =
                new MySqlCommand(sql, conexion, transaccion))
            {
                comando.Parameters.AddWithValue(
                    "@nroCarnet", nroCarnet);

                object? resultado = comando.ExecuteScalar();

                // Si el socio todavía no tiene cuotas registradas,
                // la consulta devuelve NULL.
                if (resultado == null || resultado == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToDateTime(resultado);
            }
        }

    }
}
