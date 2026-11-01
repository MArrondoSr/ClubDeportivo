using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubDeportivo.Clases;
using ClubDeportivo.Clases.Carnets;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;


namespace ClubDeportivo.Datos
{
    internal class ClienteDatos

    {
        
        public bool registrarCliente(Cliente cliente)
        {
            // Verificamos que no exista otro cliente con la misma
            // combinación de tipo y número de documento.
            if (existeDocumento(
                cliente.getTipoDocumento(),
                cliente.getNroDocumento()))
            {
                return false;
            }

            ConexionDB conexionDB = new ConexionDB();

            using (MySqlConnection conexion = conexionDB.abrirConexion())
            {
                string sql = @"INSERT INTO clientes
            (tipoDocumento, nroDocumento, nombre, apellido,
             domicilio, telefono, mail, aptoFisico)
            VALUES
            (@tipoDocumento, @nroDocumento, @nombre, @apellido,
             @domicilio, @telefono, @mail, @aptoFisico)";

                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@tipoDocumento", cliente.getTipoDocumento());

                    comando.Parameters.AddWithValue(
                        "@nroDocumento", cliente.getNroDocumento());

                    comando.Parameters.AddWithValue("@nombre", cliente.getNombre());
                    comando.Parameters.AddWithValue("@apellido", cliente.getApellido());
                    comando.Parameters.AddWithValue("@domicilio", cliente.getDomicilio());
                    comando.Parameters.AddWithValue("@telefono", cliente.getTelefono());
                    comando.Parameters.AddWithValue("@mail", cliente.getMail());
                    comando.Parameters.AddWithValue("@aptoFisico", cliente.tieneAptoFisico());

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        // PERSISTENCIA:
                        // MySQL genera idCliente mediante AUTO_INCREMENT.
                        // Recuperamos ese identificador y lo asignamos
                        // al mismo objeto Cliente que acabamos de guardar.
                        int idCliente = (int)comando.LastInsertedId;
                        cliente.setIdCliente(idCliente);

                        return true;
                    }

                    return false;
                }   
            }
        }

        public bool existeDocumento(string tipoDocumento, string nroDocumento)
        {
            ConexionDB conexionDB = new ConexionDB();

            using (MySqlConnection conexion = conexionDB.abrirConexion())
            {
                string sql = @"SELECT idCliente
                       FROM clientes
                       WHERE tipoDocumento = @tipoDocumento
                         AND nroDocumento = @nroDocumento";

                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@tipoDocumento", tipoDocumento);
                    comando.Parameters.AddWithValue("@nroDocumento", nroDocumento);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        return reader.Read();
                    }
                }
            }
        }
        public Cliente? buscarClientePorDocumento(
    string tipoDocumento, string nroDocumento)
        {
            ConexionDB conexionDB = new ConexionDB();

            using (MySqlConnection conexion = conexionDB.abrirConexion())
            {
                string sql = @"SELECT idCliente, tipoDocumento, nroDocumento,
                              nombre, apellido, domicilio,
                              telefono, mail, aptoFisico
                       FROM clientes
                       WHERE tipoDocumento = @tipoDocumento
                         AND nroDocumento = @nroDocumento";

                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@tipoDocumento", tipoDocumento);

                    comando.Parameters.AddWithValue(
                        "@nroDocumento", nroDocumento);

                    Cliente? cliente = null;

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Reconstruimos el objeto Cliente con los
                            // datos almacenados en MySQL.
                            cliente = new Cliente(
                                reader["tipoDocumento"].ToString()!,
                                reader["nroDocumento"].ToString()!,
                                reader["nombre"].ToString()!,
                                reader["apellido"].ToString()!,
                                reader["domicilio"].ToString()!,
                                reader["telefono"].ToString()!,
                                reader["mail"].ToString()!,
                                Convert.ToBoolean(reader["aptoFisico"])
                            );

                            // Este cliente ya existe en la base de datos,
                            // por lo que recuperamos su identificador real.
                            cliente.setIdCliente(
                                Convert.ToInt32(reader["idCliente"]));
                        }
                    }

                    if (cliente != null)
                    {
                        CarnetDatos carnetDatos = new CarnetDatos();

                        // Recuperamos el carnet mediante el identificador
                        // interno del cliente, no mediante su documento.
                        Carnet? carnet = carnetDatos.buscarCarnetPorIdCliente(
                            cliente.getIdCliente());

                        if (carnet != null)
                        {
                            cliente.asignarCarnet(carnet);
                        }
                    }

                    return cliente;
                }
            }
        }

        public static DataTable ListarClientes()
        {
            ConexionDB conexionDB = new ConexionDB();
            DataTable tablaClientes = new DataTable();
            try {
                using (MySqlConnection conexion = conexionDB.abrirConexion())
                {
                    string consulta = @"SELECT
                                    c.tipoDocumento,
                                    c.nroDocumento,
                                    c.nombre,
                                    c.apellido,
                                    c.domicilio,
                                    c.telefono,
                                    c.mail,
                                    CASE
                                        WHEN c.aptoFisico = 1 THEN 'Si'
                                        ELSE 'No'
                                    END AS aptoFisico,
                                    CASE
                                        WHEN EXISTS (
                                            SELECT 1
                                            FROM carnets ca
                                            WHERE ca.idCliente = c.idCliente
                                        )
                                        THEN 'Socio'
                                        ELSE 'No socio'
                                    END AS condicion
                                FROM clientes c";

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);

                   

                    adaptador.Fill(tablaClientes);

                    return tablaClientes;
                }
            }
            catch (Exception ex) { 
                MessageBox.Show("Error al cargar los clientes: " + ex.Message);
                return tablaClientes;
            }
        }
    }
}