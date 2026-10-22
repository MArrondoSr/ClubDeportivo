using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ClubDeportivo.Datos;

namespace ClubDeportivo
{
    public partial class FormListarClientes : Form
    {
        public FormListarClientes()
        {
            InitializeComponent();
            ListarClientes ();
        }

        public void ListarClientes()
        {
            ConexionDB conexionDB = new ConexionDB();

            try
            {
                using (MySqlConnection conexion = conexionDB.abrirConexion())
                {
                    string consulta = @"SELECT
                       tipoDocumento,
                       nroDocumento,
                       nombre,
                       apellido,
                       domicilio,
                       telefono,
                       mail,
                       CASE
                           WHEN aptoFisico = 1 THEN 'Si'
                           ELSE 'No'
                       END AS aptoFisico
                   FROM clientes";

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);

                    DataTable tablaClientes = new DataTable();

                    adaptador.Fill(tablaClientes);

                    dataGridView1.AutoGenerateColumns = false;

                    // Vinculamos las columnas del DataGridView
                    // con los campos que devuelve la consulta SQL.
                    tipoDocumento.DataPropertyName = "tipoDocumento";
                    NroDocumento.DataPropertyName = "nroDocumento";
                    nombre.DataPropertyName = "nombre";
                    apellido.DataPropertyName = "apellido";
                    domicilio.DataPropertyName = "domicilio";
                    telefono.DataPropertyName = "telefono";
                    mail.DataPropertyName = "mail";
                    aptoFisico.DataPropertyName = "aptoFisico";

                    dataGridView1.DataSource = tablaClientes;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message);
            }
        }
    }
}
