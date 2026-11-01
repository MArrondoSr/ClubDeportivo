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
            ListarClientes();
        }

        public void ListarClientes()
        {
             DataTable tablaClientes = ClienteDatos.ListarClientes();

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
                    condicion.DataPropertyName = "condicion";

                    dataGridView1.DataSource = tablaClientes;

                
            
           
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            {
                // NAVEGACIÓN ENTRE FORMULARIOS:
                // Cerramos el formulario de vencimientos.
                // Como se abrirá mediante ShowDialog(),
                // el usuario regresará al menú principal.
                this.Close();
            }
        }
    }
}
