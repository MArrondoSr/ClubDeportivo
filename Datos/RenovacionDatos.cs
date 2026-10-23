using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ClubDeportivo.Datos
{
    internal class RenovacionDatos
    {
        // TRANSACCIÓN:
        // La renovación mensual comprende dos operaciones:
        // registrar el pago y generar el nuevo período.
        //
        // Ambas deben confirmarse juntas. Si alguna falla,
        // se deshacen los cambios mediante Rollback().

        public int renovarCuota(
            int idCliente,
            int nroCarnet,
            Pago pago)
        {
            ConexionDB conexionDB = new ConexionDB();

            using (MySqlConnection conexion =
                conexionDB.abrirConexion())
            {
                using (MySqlTransaction transaccion =
                    conexion.BeginTransaction())
                {
                    try
                    {
                        PagoDatos pagoDatos = new PagoDatos();
                        CuotaDatos cuotaDatos = new CuotaDatos();

                        // CONCURRENCIA:
                        // Bloqueamos el registro del carnet mientras
                        // calculamos y guardamos la renovación.
                        //
                        // Esto evita que dos renovaciones simultáneas
                        // del mismo socio calculen el mismo período.
                        string sqlBloqueo =
                            @"SELECT nroCarnet
                              FROM carnets
                              WHERE nroCarnet = @nroCarnet
                                AND idCliente = @idCliente
                              FOR UPDATE";

                        using (MySqlCommand comando =
                            new MySqlCommand(
                                sqlBloqueo, conexion, transaccion))
                        {
                            comando.Parameters.AddWithValue(
                                "@nroCarnet", nroCarnet);

                            comando.Parameters.AddWithValue(
                                "@idCliente", idCliente);

                            object? resultado = comando.ExecuteScalar();

                            if (resultado == null)
                            {
                                throw new InvalidOperationException(
                                    "El carnet no corresponde al cliente.");
                            }
                        }

                        // PERSISTENCIA:
                        // Consultamos el último vencimiento dentro
                        // de la misma transacción.
                        DateTime? vencimientoAnterior =
                            cuotaDatos.buscarUltimoVencimiento(
                                nroCarnet,
                                conexion,
                                transaccion
                            );

                        // REGLA DE NEGOCIO:
                        // Si paga anticipadamente, la nueva cuota
                        // comienza en el vencimiento anterior.
                        //
                        // Si la cuota anterior ya venció,
                        // comienza en la fecha del nuevo pago.
                        //
                        // El cálculo se realiza en Cuota,
                        // no en esta clase.
                        Cuota nuevaCuota = new Cuota(
                            0,
                            pago.getFecha(),
                            vencimientoAnterior,
                            pago.getImporte()
                        );

                        // POLIMORFISMO:
                        // El pago puede ser efectivo o tarjeta.
                        int idPago = pagoDatos.registrarPago(
                            idCliente,
                            pago,
                            conexion,
                            transaccion
                        );

                        // PERSISTENCIA:
                        // Registramos el nuevo período mensual.
                        int idCuota = cuotaDatos.registrarCuota(
                            nroCarnet,
                            idPago,
                            nuevaCuota.getFechaInicio(),
                            nuevaCuota.getFechaVencimiento(),
                            pago.getImporte(),
                            conexion,
                            transaccion
                        );

                        // Confirmamos el pago y la cuota.
                        transaccion.Commit();

                        return idCuota;
                    }
                    catch
                    {
                        // Si falla alguna operación, se revierten
                        // los cambios realizados en MySQL.
                        transaccion.Rollback();

                        // Evitamos conservar un identificador
                        // de pago que fue revertido.
                        pago.setIdPago(0);

                        throw;
                    }
                }
            }
        }
    }
}
