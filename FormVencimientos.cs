using ClubDeportivo.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class FormVencimientos: Form
    {
        public FormVencimientos()
        {
            InitializeComponent();
        }

            private void btnVolver_Click(object sender, EventArgs e)
        {
            // NAVEGACIÓN ENTRE FORMULARIOS:
            // Cerramos el formulario de vencimientos.
            // Como se abrirá mediante ShowDialog(),
            // el usuario regresará al menú principal.
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                // CAPA DE DATOS:
                // Creamos el objeto que se encarga de consultar
                // los vencimientos registrados en MySQL.
                VencimientosDatos vencimientosDatos = new VencimientosDatos();

                // Obtenemos la fecha elegida por el usuario.
                // Value.Date descarta la parte correspondiente a la hora.
                DateTime fechaConsulta = dtpFechaConsulta.Value.Date;

                // Consultamos la base de datos.
                // El método devuelve un DataTable con los socios
                // cuya última cuota vence en la fecha seleccionada.
                DataTable resultados = vencimientosDatos.listarVencimientos(fechaConsulta);

                // PRESENTACIÓN:
                // El DataGridView genera las columnas automáticamente
                // a partir del DataTable recibido.
                dgvVencimientos.AutoGenerateColumns = true;
                dgvVencimientos.DataSource = resultados;
                // PRESENTACIÓN DE LOS DATOS:
                // Cambiamos los títulos técnicos por nombres legibles.
                // No modificamos los nombres de las columnas del DataTable.
                dgvVencimientos.Columns["idCliente"].HeaderText = "ID Cliente";
                dgvVencimientos.Columns["nombre"].HeaderText = "Nombre";
                dgvVencimientos.Columns["apellido"].HeaderText = "Apellido";
                dgvVencimientos.Columns["nroCarnet"].HeaderText = "N.º Carnet";
                dgvVencimientos.Columns["ultimoVencimiento"].HeaderText = "Vencimiento";

                // Ocultamos la columna vacía utilizada para seleccionar filas.
                dgvVencimientos.RowHeadersVisible = false;

                // Distribuimos el ancho disponible entre todas las columnas.
                dgvVencimientos.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                // FORMATO DE FECHA:
                // Mostramos únicamente día, mes y año.
                // Esto modifica la presentación, no el valor almacenado en MySQL.
                dgvVencimientos.Columns["ultimoVencimiento"]
                    .DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                // Informamos cualquier error de consulta o conexión.
                MessageBox.Show(
                    "Error al consultar los vencimientos:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }

 }

