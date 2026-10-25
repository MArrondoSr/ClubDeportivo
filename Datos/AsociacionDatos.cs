using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClubDeportivo.Datos
{
    internal class AsociacionDatos
    {
        // TRANSACCIÓN:
        // El primer pago y la emisión del carnet
        // forman una única operación.
        public int asociarCliente(int idCliente, Pago pago)
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
                        CarnetDatos carnetDatos = new CarnetDatos();

                        // PERSISTENCIA:
                        // Registra el pago inicial y recupera su ID,
                        // necesario para vincularlo con la primera cuota.
                        int idPago = pagoDatos.registrarPago(
                            idCliente,
                            pago,
                            conexion,
                            transaccion
                        );

                        // ASOCIACIÓN:
                        // Genera el carnet correspondiente al nuevo socio.
                        int nroCarnet = carnetDatos.generarCarnet(
                            idCliente,
                            conexion,
                            transaccion
                        );

                        // REGLA DE NEGOCIO:
                        // La primera cuota comienza en la fecha del pago.
                        // Como todavía no existe una cuota anterior,
                        // el vencimiento anterior se representa mediante null.
                        //
                        // El constructor de Cuota calcula automáticamente
                        // el vencimiento sumando un mes calendario.
                        // Fecha de inicio de vigencia de la primera cuota.
                        // Inicialmente coincide con la fecha del pago.
                        //Si el tipo tenia pagado el día coo No Socio el pago de
                        //asociacion se registra con la fecha posterior
                        // REGLA DE NEGOCIO:
                        // Si el cliente ya abonó un pase diario en la fecha
                        // de asociación, la primera cuota comenzará al día siguiente.

                        DateTime fechaInicioCuota = pago.getFecha().Date;

                        bool tienePaseDiario = pagoDatos.existePagoDiario(
                            idCliente,
                            fechaInicioCuota,
                            conexion,
                            transaccion
                        );

                        if (tienePaseDiario)
                        {
                            fechaInicioCuota = fechaInicioCuota.AddDays(1);
                        }

                        // Crea la primera cuota con la fecha de inicio calculada.
                        Cuota primeraCuota = new Cuota(
                            0,
                            fechaInicioCuota,
                            null,
                            pago.getImporte()
                        );

                        // PERSISTENCIA:
                        // Registra la primera cuota dentro de la misma
                        // transacción que el pago y el carnet.
                        CuotaDatos cuotaDatos = new CuotaDatos();

                        // ENCAPSULAMIENTO Y REUTILIZACIÓN:
                        //
                        // Las fechas se obtienen del objeto primeraCuota,
                        // que aplica las reglas de negocio en su constructor.
                        //
                        // De esta manera, AsociacionDatos no calcula
                        // vencimientos ni duplica esa responsabilidad.

                        cuotaDatos.registrarCuota(
                            nroCarnet,
                            idPago,
                            primeraCuota.getFechaInicio(),
                            primeraCuota.getFechaVencimiento(),
                            pago.getImporte(),
                            conexion,
                            transaccion
                        );

                        // TRANSACCIÓN:
                        // Confirma conjuntamente el pago, el carnet
                        // y la primera cuota mensual.
                        transaccion.Commit();

                        return nroCarnet;
                    }
                    catch
                    {
                        // Si falla alguna operación,
                        // deshace todos los cambios.
                        transaccion.Rollback();

                        // Evita conservar en memoria un ID
                        // correspondiente a un pago revertido.
                        pago.setIdPago(0);

                        throw;
                    }
                }
            }
        }
    }
}


