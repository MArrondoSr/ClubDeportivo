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
                        // Registramos el pago inicial y recuperamos su ID,
                        // necesario para vincularlo con la primera cuota.
                        int idPago = pagoDatos.registrarPago(
                            idCliente,
                            pago,
                            conexion,
                            transaccion
                        );

                        // ASOCIACIÓN:
                        // Generamos el carnet correspondiente al nuevo socio.
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
                        Cuota primeraCuota = new Cuota(
                            0,
                            pago.getFecha(),
                            null,
                            pago.getImporte()
                        );

                        // PERSISTENCIA:
                        // Registramos la primera cuota dentro de la misma
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
                        // Confirmamos conjuntamente el pago, el carnet
                        // y la primera cuota mensual.
                        transaccion.Commit();

                        return nroCarnet;
                    }
                    catch
                    {
                        // Si falla alguna operación,
                        // deshacemos todos los cambios.
                        transaccion.Rollback();

                        // Evitamos conservar en memoria un ID
                        // correspondiente a un pago revertido.
                        pago.setIdPago(0);

                        throw;
                    }
                }
            }
        }
    }
}


