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
    public partial class FormCobrosCarnet : Form
    {
        private Cliente? clienteSeleccionado;
        public FormCobrosCarnet()
        {
            InitializeComponent();
            cmbMedioPago.SelectedIndex = 0;
            lblCuotas.Enabled = false;
            cmbCuotas.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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
                MessageBox.Show("Debe ingresar un número de documento.");
                return;
            }

            string tipoDocumento = cmbTipoDocumento.Text;
            string nroDocumento = txtNroDocumento.Text.Trim();

            ClienteDatos clienteDatos = new ClienteDatos();

            // Buscamos al cliente por tipo y número de documento.
            clienteSeleccionado =
                clienteDatos.buscarClientePorDocumento(
                    tipoDocumento, nroDocumento);

            if (clienteSeleccionado == null)
            {
                MessageBox.Show(
                    "No existe un cliente con ese tipo y número de documento.");

                lblNombre.Text = "";
                lblApellido.Text = "";
                lblEstado.Text = "";

                return;
            }

            lblNombre.Text = clienteSeleccionado.getNombre();
            lblApellido.Text = clienteSeleccionado.getApellido();

            if (clienteSeleccionado.esSocio())
            {
                lblEstado.Text = "Socio";
            }
            else
            {
                lblEstado.Text = "No socio";
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Restablece el formulario y descarta la selección actual.
            limpiarFormulario();
        }

        private void btnEmitirCarnet_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Primero debe buscar un cliente.");
                return;
            }

            if (clienteSeleccionado.esSocio())
            {
                MessageBox.Show("El cliente ya posee carnet.");
                return;
            }

            CarnetDatos carnetDatos = new CarnetDatos();

            // PERSISTENCIA: utilizamos el identificador interno del cliente.
            int nroCarnet =
                carnetDatos.generarCarnet(clienteSeleccionado.getIdCliente());

            Carnet carnet = new Carnet(nroCarnet);

            // ENCAPSULAMIENTO: asignamos el carnet mediante
            // un método público de Cliente.
            clienteSeleccionado.asignarCarnet(carnet);

            lblEstado.Text = "Socio";

            //check, si existe mail registrado se enviaria copi al mail,
            //sino se muestra "no existe mail registrado, entregar en persona"
            string segundaLinea = "";

            if (!string.IsNullOrWhiteSpace(clienteSeleccionado.getMail()))
            {
                segundaLinea = "Se ha enviado una copia a: " + clienteSeleccionado.getMail();
            }
            else
            {
                segundaLinea = "No existe mail registrado, entregar en persona.";
            }

            MessageBox.Show(
                "Carnet emitido correctamente. Número: " + nroCarnet +
                "\n" + segundaLinea

            //***************************************************
            );

        }

        private void cmbMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMedioPago.Text == "Tarjeta")
            {
                lblCuotas.Enabled = true;
                cmbCuotas.Enabled = true;
            }
            else
            {
                lblCuotas.Enabled = false;
                cmbCuotas.Enabled = false;
                cmbCuotas.SelectedIndex = -1;
            }
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Primero debe buscar un cliente.");
                return;
            }

            if (!decimal.TryParse(txtImporte.Text, out decimal importe) || importe <= 0)
            {
                MessageBox.Show("Ingrese un importe válido.");
                return;
            }

            // POLIMORFISMO: una referencia de tipo Pago puede contener
            // un objeto PagoEfectivo o PagoTarjeta, gracias a la herencia.

            Pago pago;

            if (cmbMedioPago.Text == "Efectivo")
            {
                pago = new PagoEfectivo(DateTime.Today, importe);
            }
            else
            {
                if (cmbCuotas.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione 3 o 6 cuotas.");
                    return;
                }

                int cantidadCuotas = Convert.ToInt32(cmbCuotas.Text);

                if (cantidadCuotas != 3 && cantidadCuotas != 6)
                {
                    MessageBox.Show("La cantidad de cuotas debe ser 3 o 6.");
                    return;
                }

                pago = new PagoTarjeta(
                    DateTime.Today,
                    importe,
                    cantidadCuotas
                );
            }

            PagoDatos pagoDatos = new PagoDatos();

            int idPago = pagoDatos.registrarPago(
                clienteSeleccionado.getIdCliente(),
                pago
            );

            // CONSISTENCIA: agregamos el pago a la lista del cliente solo
            // despues de que el INSERT en MySQL se ejecuto correctamente.

            clienteSeleccionado.agregarPago(pago);

            // POLIMORFISMO EN EJECUCIÓN: obtenerDetalle() llama a la versión
            // sobrescrita (override) correspondiente al tipo real del objeto,
            // sin necesidad de preguntar si es PagoEfectivo o PagoTarjeta.

            MessageBox.Show(
                "Pago registrado correctamente.\n\n" +
                pago.obtenerDetalle()
            );

            txtImporte.Text = "";
            cmbMedioPago.SelectedIndex = 0;
        }

        private void limpiarFormulario()
        {
            // Limpia los datos de identificación del cliente.
            cmbTipoDocumento.SelectedItem = "DNI";
            txtNroDocumento.Clear();
            lblNombre.Text = "";
            lblApellido.Text = "";
            lblEstado.Text = "";

            // elimina la referencia al cliente seleccionado.
            // Evita registrar pagos o emitir carnets al cliente anterior.
            clienteSeleccionado = null;

            // restablece los campos correspondientes al pago.
            txtImporte.Clear();
            cmbMedioPago.SelectedIndex = 0; // Efectivo
            cmbCuotas.SelectedIndex = -1;    // Sin cuotas seleccionadas

            // deshabilita las cuotas porque el medio inicial es efectivo.
            lblCuotas.Enabled = false;
            cmbCuotas.Enabled = false;

            // devuelve el foco al campo DNI.
            txtNroDocumento.Focus();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Cierra el formulario modal de Cobros y Carnet.
            // No cierra la aplicación ni destruye el menú principal.
            this.Close();
        }

        private void txtNroDocumento_TextChanged(object sender, EventArgs e)
        {
            // Si cambia el documento, el cliente seleccionado
            // deja de corresponder necesariamente a la búsqueda actual.
            clienteSeleccionado = null;

            lblNombre.Text = "";
            lblApellido.Text = "";
            lblEstado.Text = "";
        }

        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Al cambiar el tipo de documento, invalidamos
            // la selección del cliente anterior.
            clienteSeleccionado = null;

            lblNombre.Text = "";
            lblApellido.Text = "";
            lblEstado.Text = "";
        }
    }
}
