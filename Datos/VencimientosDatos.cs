using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClubDeportivo.Datos
{
    internal class VencimientosDatos
    {
        // PERSISTENCIA:
        // Recupera los socios cuya última cuota mensual
        // vence en la fecha indicada.
        //
        // REGLA DE NEGOCIO:
        // Un socio puede tener varias cuotas registradas.
        // Para determinar su vencimiento actual, debemos
        // considerar la fecha máxima de vencimiento.
        //
        // HAVING:
        // Filtra los resultados después de agrupar las
        // cuotas de cada socio mediante MAX().
        //
        // CONSULTA PARAMETRIZADA:
        // Utilizamos @fechaConsulta para enviar la fecha
        // a MySQL sin concatenarla dentro de la sentencia.

        public DataTable listarVencimientos(DateTime fechaConsulta)
        {
            ConexionDB conexionDB = new ConexionDB();

            using (MySqlConnection conexion =
                conexionDB.abrirConexion())
            {
                string sql = @"
                    SELECT
                        cl.idCliente,
                        cl.nombre,
                        cl.apellido,
                        ca.nroCarnet,
                        MAX(cu.fechaVencimiento)
                            AS ultimoVencimiento
                    FROM clientes cl
                    INNER JOIN carnets ca
                        ON ca.idCliente = cl.idCliente
                    INNER JOIN cuotas cu
                        ON cu.nroCarnet = ca.nroCarnet
                    GROUP BY
                        cl.idCliente,
                        cl.nombre,
                        cl.apellido,
                        ca.nroCarnet
                    HAVING MAX(cu.fechaVencimiento) =
                        @fechaConsulta
                    ORDER BY cl.apellido, cl.nombre";

                using (MySqlCommand comando =
                    new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@fechaConsulta",
                        fechaConsulta.Date
                    );

                    // DataTable:
                    // Almacena los resultados en memoria
                    // para mostrarlos posteriormente en
                    // un DataGridView de Windows Forms.
                    DataTable tabla = new DataTable();

                    using (MySqlDataAdapter adaptador =
                        new MySqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }

                    return tabla;
                }
            }
        }
    }
}



