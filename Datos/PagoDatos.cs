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
    }
}
