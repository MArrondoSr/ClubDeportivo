using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ClubDeportivo.Datos
{
    internal class PagoDatos
    {
        // POLIMORFISMO: este método recibe un Pago, que puede ser
        // PagoEfectivo o PagoTarjeta. Los métodos virtuales proporcionan
        // los datos correspondientes sin preguntar por el subtipo.
        public int registrarPago(int idCliente, Pago pago)
        {
            ConexionDB conexionDB = new ConexionDB();

            using (MySqlConnection conexion = conexionDB.abrirConexion())
            {
                // PERSISTENCIA: relacionamos el pago con el cliente
                // mediante su identificador interno (idCliente).
                string sql = @"INSERT INTO pagos
               (idCliente, fecha, importe, medioPago, cantidadCuotas)
               VALUES
               (@idCliente, @fecha, @importe, @medioPago, @cantidadCuotas)";

                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@idCliente", idCliente);
                    comando.Parameters.AddWithValue("@fecha", pago.getFecha());
                    comando.Parameters.AddWithValue("@importe", pago.getImporte());
                    comando.Parameters.AddWithValue("@medioPago", pago.getMedioPago());
                    comando.Parameters.AddWithValue(
                        "@cantidadCuotas",
                        pago.getCantidadCuotas() ?? (object)DBNull.Value
                    );

                    comando.ExecuteNonQuery();

                    // Recuperamos el identificador generado por MySQL.
                    int idPago = (int)comando.LastInsertedId;

                    pago.setIdPago(idPago);

                    return idPago;
                }
            }
        }

        // SOBRECARGA Y TRANSACCIONES:
        // Registra un pago utilizando una conexión y una transacción
        // proporcionadas por la operación que asocia al cliente.
        //
        // No abre otra conexión ni ejecuta Commit().
        // Así, el pago y la emisión del carnet pueden confirmarse
        // o revertirse conjuntamente.
        //
        // POLIMORFISMO: Pago puede ser PagoEfectivo o PagoTarjeta.
        public int registrarPago(
            int idCliente,
            Pago pago,
            MySqlConnection conexion,
            MySqlTransaction transaccion)
        {
            string sql = @"INSERT INTO pagos
                   (idCliente, fecha, importe, medioPago, cantidadCuotas)
                   VALUES
                   (@idCliente, @fecha, @importe, @medioPago, @cantidadCuotas)";

            using (MySqlCommand comando =
                new MySqlCommand(sql, conexion, transaccion))
            {
                comando.Parameters.AddWithValue("@idCliente", idCliente);
                comando.Parameters.AddWithValue("@fecha", pago.getFecha());
                comando.Parameters.AddWithValue("@importe", pago.getImporte());
                comando.Parameters.AddWithValue("@medioPago", pago.getMedioPago());

                comando.Parameters.AddWithValue(
                    "@cantidadCuotas",
                    pago.getCantidadCuotas() ?? (object)DBNull.Value
                );

                comando.ExecuteNonQuery();

                // Recuperamos el identificador generado por MySQL.
                int idPago = Convert.ToInt32(comando.LastInsertedId);

                pago.setIdPago(idPago);

                return idPago;
            }
        }

        // SOBRECARGA DE MÉTODOS:
        // Esta versión permite registrar un pago indicando su concepto.
        //
        // Se utilizará para los pases diarios de los no socios.
        // Los métodos existentes permanecen sin cambios para no
        // afectar la asociación ni la renovación de socios.
        //
        // POLIMORFISMO:
        // Recibimos un Pago, que puede ser PagoEfectivo o PagoTarjeta.
        // No necesitamos conocer su tipo concreto.
        public int registrarPago(int idCliente, Pago pago, string concepto)
        {
            ConexionDB conexionDB = new ConexionDB();

            using (MySqlConnection conexion = conexionDB.abrirConexion())
            {
                // PERSISTENCIA:
                // Guardamos el concepto junto con los datos del pago.
                // Para un no socio utilizaremos "PASE_DIARIO".
                string sql = @"INSERT INTO pagos
            (idCliente, fecha, importe, medioPago, cantidadCuotas, concepto)
            VALUES
            (@idCliente, @fecha, @importe, @medioPago, @cantidadCuotas, @concepto)";

                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@idCliente", idCliente);
                    comando.Parameters.AddWithValue("@fecha", pago.getFecha());
                    comando.Parameters.AddWithValue("@importe", pago.getImporte());
                    comando.Parameters.AddWithValue("@medioPago", pago.getMedioPago());

                    comando.Parameters.AddWithValue(
                        "@cantidadCuotas",
                        pago.getCantidadCuotas() ?? (object)DBNull.Value
                    );

                    comando.Parameters.AddWithValue("@concepto", concepto);

                    comando.ExecuteNonQuery();

                    // Recuperamos el ID generado automáticamente por MySQL.
                    int idPago = Convert.ToInt32(comando.LastInsertedId);

                    // Actualizamos el objeto Pago solamente después
                    // de que la inserción se haya realizado correctamente.
                    pago.setIdPago(idPago);

                    return idPago;
                }
            }
        }

        // REGLA DE NEGOCIO:
        // Un cliente no socio solamente puede registrar
        // un pase diario para una misma fecha.
        //
        // PERSISTENCIA:
        // Consultamos MySQL para verificar si ya existe
        // un pago diario del cliente en la fecha indicada.
        public bool existePagoDiario(int idCliente, DateTime fecha)
        {
            ConexionDB conexionDB = new ConexionDB();

            using (MySqlConnection conexion = conexionDB.abrirConexion())
            {
                string sql = @"
            SELECT COUNT(*)
            FROM pagos
            WHERE idCliente = @idCliente
              AND fecha = @fecha
              AND concepto = 'PASE_DIARIO'";

                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@idCliente", idCliente);
                    comando.Parameters.AddWithValue("@fecha", fecha.Date);

                    // ExecuteScalar() devuelve el primer valor
                    // de la primera fila: en este caso, COUNT(*).
                    int cantidad = Convert.ToInt32(
                        comando.ExecuteScalar()
                    );

                    // Si existe al menos un registro, devolvemos true.
                    return cantidad > 0;
                }
            }
        }

        // SOBRECARGA:
        // Consulta si existe un pase diario utilizando una conexión
        // y una transacción proporcionadas por otra operación.
        public bool existePagoDiario(
            int idCliente,
            DateTime fecha,
            MySqlConnection conexion,
            MySqlTransaction transaccion)
        {
            string sql = @"
        SELECT COUNT(*)
        FROM pagos
        WHERE idCliente = @idCliente
          AND fecha = @fecha
          AND concepto = 'PASE_DIARIO'";

            using (MySqlCommand comando =
                new MySqlCommand(sql, conexion, transaccion))
            {
                comando.Parameters.AddWithValue("@idCliente", idCliente);
                comando.Parameters.AddWithValue("@fecha", fecha.Date);

                int cantidad = Convert.ToInt32(
                    comando.ExecuteScalar()
                );

                return cantidad > 0;
            }
        }
    }
}
