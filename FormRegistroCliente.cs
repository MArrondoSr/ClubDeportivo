using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClubDeportivo.Datos;

namespace ClubDeportivo
{
    public partial class FormRegistroCliente : Form
    {
        public FormRegistroCliente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Validamos que se haya seleccionado un tipo de documento.
            if (cmbTipoDocumento.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de documento.");
                return;
            }

            // Validamos que se haya ingresado el número de documento.
            if (string.IsNullOrWhiteSpace(txtNroDocumento.Text))
            {
                MessageBox.Show("Debe ingresar el número de documento.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar nombre y apellido.");
                return;
            }
            // REGLA DE NEGOCIO:
            // El teléfono celular es obligatorio para registrar un cliente.
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show(
                    "Debe ingresar un número de teléfono celular.",
                    "Teléfono obligatorio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtTelefono.Focus();
                return;
            }
            // REGLA DE NEGOCIO:
            // Según los requisitos acordados para el sistema,
            // no se permite registrar un cliente que no haya
            // presentado el apto físico.
            //
            // Esta validación se aplica tanto a futuros socios
            // como a clientes que utilizarán pases diarios.
            if (!chkAptoFisico.Checked)
            {
                MessageBox.Show(
                    "No se puede registrar al cliente.\n" +
                    "Debe presentar el apto físico obligatorio.",
                    "Apto físico requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Recuperamos los datos ingresados en el formulario.
            string tipoDocumento = cmbTipoDocumento.Text;
            string nroDocumento = txtNroDocumento.Text.Trim();
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string domicilio = txtDomicilio.Text;
            // Normalizamos el teléfono al formato internacional de WhatsApp.
            string? telefono = NormalizarTelefono(txtTelefono.Text);

            // Si el formato no es válido, interrumpimos el registro.
            if (telefono == null)
            {
                MessageBox.Show(
                    "Ingrese un teléfono celular válido, incluyendo el código de área.\n\n" +
                    "Ejemplo: 11 6252-0330\n" +
                    "También se acepta: +54 9 11 6252-0330",
                    "Teléfono inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtTelefono.Focus();
                return;
            }
            string mail = txtMail.Text;
            bool aptoFisico = chkAptoFisico.Checked;

            // Creamos un objeto Cliente con los datos ingresados.
            // El idCliente será generado automáticamente por MySQL.
            Cliente cliente = new Cliente(
                tipoDocumento,
                nroDocumento,
                nombre,
                apellido,
                domicilio,
                telefono,
                mail,
                aptoFisico
            );

            ClienteDatos clienteDatos = new ClienteDatos();

            bool clienteRegistrado =
                clienteDatos.registrarCliente(cliente);

            if (clienteRegistrado)
            {
                MessageBox.Show("Cliente registrado correctamente.");
                limpiarFormulario();
            }
            else
            {
                MessageBox.Show(
                    "Ya existe un cliente con ese tipo y número de documento.");
            }
        }
        private void limpiarFormulario()
        {
            cmbTipoDocumento.SelectedItem = "DNI";

            txtNroDocumento.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDomicilio.Text = "";
            txtTelefono.Text = "";
            txtMail.Text = "";
            chkAptoFisico.Checked = false;

            txtNroDocumento.Focus();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Reutiliza el método que restablece los campos del formulario.
            limpiarFormulario();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // NAVEGACIÓN ENTRE FORMULARIOS:
            // Close() cierra únicamente el formulario actual.
            // Como fue abierto mediante ShowDialog(), al cerrarlo
            // se devuelve el control al menú principal (Form1).
            this.Close();
        }

        private static string? NormalizarTelefono(string telefono)
        {
            // Eliminamos espacios, guiones, paréntesis y el signo +.
            string numeros = new string(
                telefono.Where(char.IsDigit).ToArray()
            );

            // Formato internacional: 549 + 10 dígitos.
            if (numeros.StartsWith("549") && numeros.Length == 13)
                return numeros;

            // Formato con código de país, sin el 9.
            if (numeros.StartsWith("54") && numeros.Length == 12)
                return "549" + numeros.Substring(2);

            // Formato nacional con cero inicial.
            if (numeros.StartsWith("0") && numeros.Length == 11)
                numeros = numeros.Substring(1);

            // Formato nacional: código de área + número local.
            if (numeros.Length == 10)
                return "549" + numeros;

            // Número incompleto o formato no admitido.
            return null;
        }
    }
}
