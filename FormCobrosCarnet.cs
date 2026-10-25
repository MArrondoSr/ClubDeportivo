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
        private Pago? ultimoPagoRegistrado;
        private string ultimoConcepto = "";
        public FormCobrosCarnet()
        {
            InitializeComponent();
            cmbMedioPago.SelectedIndex = 0;
            lblCuotas.Enabled = false;
            cmbCuotas.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ultimoPagoRegistrado = null;
            ultimoConcepto = "";
            btnComprobante.Enabled = false;
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
            ultimoPagoRegistrado = null;
            ultimoConcepto = "";
            btnComprobante.Enabled = false;

            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Primero debe buscar un cliente.");
                return;
            }

            if (clienteSeleccionado.esSocio())
            {
                MessageBox.Show("El cliente ya es socio.");
                return;
            }

            // VALIDACIÓN: la asociación requiere el pago
            // de la primera cuota mensual.
            if (!decimal.TryParse(txtImporte.Text, out decimal importe)
                || importe <= 0)
            {
                MessageBox.Show("Ingrese el importe de la primera cuota mensual.");
                return;
            }

            // POLIMORFISMO:
            // Trabajamos con una referencia de tipo Pago,
            // que puede contener un PagoEfectivo o un PagoTarjeta.
            Pago pago;

            if (cmbMedioPago.Text == "Efectivo")
            {
                pago = new PagoEfectivo(DateTime.Today, importe);
            }
            else if (cmbMedioPago.Text == "Tarjeta")
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
                    DateTime.Today, importe, cantidadCuotas);
            }
            else
            {
                MessageBox.Show("Seleccione un medio de pago.");
                return;
            }

            try
            {
                // TRANSACCIÓN:
                // Registramos el primer pago y generamos el carnet
                // como una única operación en MySQL.
                AsociacionDatos asociacionDatos = new AsociacionDatos();

                int nroCarnet = asociacionDatos.asociarCliente(
                    clienteSeleccionado.getIdCliente(), pago);

                // ENCAPSULAMIENTO:
                // Actualizamos el objeto solamente después
                // de confirmar la transacción.
                Carnet carnet = new Carnet(nroCarnet);
                clienteSeleccionado.asignarCarnet(carnet);
                clienteSeleccionado.agregarPago(pago);
                ultimoPagoRegistrado = pago;
                ultimoConcepto = "Primera cuota mensual";
                btnComprobante.Enabled = true;

                lblEstado.Text = "Socio";

                MessageBox.Show(
                    "Cliente asociado correctamente.\n" +
                    "Primera cuota mensual registrada.\n" +
                    "Número de carnet: " + nroCarnet
                );

                txtImporte.Clear();
                cmbMedioPago.SelectedIndex = 0;
                // Abre el formulario del carnet del socio recién asociado.
                // Usa el segundo constructor que recibe tipo y número de documento.
                FormCarnet formularioCarnet = new FormCarnet(
                    cmbTipoDocumento.Text,
                    txtNroDocumento.Text.Trim()
                );

                formularioCarnet.Show();
            }


            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo completar la asociación.\n\n" +
                    ex.Message
                );
            }
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

            ultimoPagoRegistrado = null;
            ultimoConcepto = "";
            btnComprobante.Enabled = false;

            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Primero debe buscar un cliente.");
                return;
            }


            if (!decimal.TryParse(txtImporte.Text, out decimal importe)
                || importe <= 0)
            {
                MessageBox.Show("Ingrese un importe válido.");
                return;
            }

            // POLIMORFISMO:
            // Una referencia de tipo Pago puede contener un objeto
            // PagoEfectivo o PagoTarjeta, gracias a la herencia.
            Pago pago;

            if (cmbMedioPago.Text == "Efectivo")
            {
                pago = new PagoEfectivo(DateTime.Today, importe);
            }
            else if (cmbMedioPago.Text == "Tarjeta")
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
            else
            {
                MessageBox.Show("Seleccione un medio de pago.");
                return;
            }

            try
            {
                // REGLA DE NEGOCIO:
                // Si el cliente no es socio, registramos un pase diario.
                // No se genera carnet ni cuota mensual.
                if (!clienteSeleccionado.esSocio())
                {
                    // PERSISTENCIA:
                    // Utilizamos la sobrecarga de PagoDatos que permite
                    // identificar explícitamente el concepto del pago.
                    PagoDatos pagoDatos = new PagoDatos();

                    // REGLA DE NEGOCIO:
                    // Un no socio puede abonar un solo pase diario
                    // para una misma fecha.
                    //
                    // Consultamos MySQL antes de registrar el pago
                    // para evitar cobros duplicados.
                    if (pagoDatos.existePagoDiario(
                        clienteSeleccionado.getIdCliente(),
                        pago.getFecha()))
                    {
                        MessageBox.Show(
                            "El cliente ya tiene registrado un pase diario " +
                            "para la fecha de hoy.\n\n" +
                            "No corresponde realizar otro cobro.",
                            "Pago diario duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }

                    int idPago = pagoDatos.registrarPago(
                        clienteSeleccionado.getIdCliente(),
                        pago,
                        "PASE_DIARIO"
                    );

                    // CONSISTENCIA ENTRE OBJETOS Y BASE DE DATOS:
                    // Actualizamos el objeto Cliente únicamente después
                    // de registrar correctamente el pago en MySQL.
                    clienteSeleccionado.agregarPago(pago);
                    ultimoPagoRegistrado = pago;
                    ultimoConcepto = "Pase diario";
                    btnComprobante.Enabled = true;

                    // POLIMORFISMO:
                    // obtenerDetalle() ejecuta el comportamiento
                    // correspondiente a PagoEfectivo o PagoTarjeta.
                    MessageBox.Show(
                        "Pase diario registrado correctamente.\n" +
                        "Número de pago: " + idPago + "\n\n" +
                        pago.obtenerDetalle()
                    );

                    txtImporte.Clear();
                    cmbMedioPago.SelectedIndex = 0;

                    // Finalizamos el método para evitar ejecutar
                    // la renovación mensual destinada a los socios.
                    return;
                }
                // ASOCIACIÓN ENTRE OBJETOS:
                // Obtenemos el carnet del cliente seleccionado.
                // No generamos uno nuevo porque ya es socio.
                Carnet? carnet = clienteSeleccionado.getCarnet();

                if (carnet == null)
                {
                    MessageBox.Show("No se encontró el carnet del socio.");
                    return;
                }

                // TRANSACCIÓN:
                // RenovacionDatos registra el pago y la nueva cuota
                // mensual como una única operación en MySQL.
                //
                // REGLA DE NEGOCIO:
                // Si el socio paga anticipadamente, conserva los días
                // abonados porque la nueva cuota comienza en el
                // vencimiento de la cuota anterior.
                RenovacionDatos renovacionDatos = new RenovacionDatos();

                int idCuota = renovacionDatos.renovarCuota(
                    clienteSeleccionado.getIdCliente(),
                    carnet.getNroCarnet(),
                    pago
                );

                // CONSISTENCIA:
                // Agregamos el pago al objeto Cliente solamente
                // después de confirmar la transacción.
                clienteSeleccionado.agregarPago(pago);
                ultimoPagoRegistrado = pago;
                ultimoConcepto = "Renovación cuota mensual";
                btnComprobante.Enabled = true;

                // POLIMORFISMO EN EJECUCIÓN:
                // obtenerDetalle() utiliza la implementación
                // correspondiente al tipo real del objeto Pago.
                MessageBox.Show(
                    "Cuota mensual renovada correctamente.\n" +
                    "Número de cuota: " + idCuota + "\n\n" +
                    pago.obtenerDetalle()
                );

                txtImporte.Clear();
                cmbMedioPago.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo registrar la renovación.\n\n" +
                    ex.Message
                );
            }
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
            //Evita que si queda el pago de un cliente y se ebusca otro se asigne erroneamente
            clienteSeleccionado = null;
            ultimoPagoRegistrado = null;
            ultimoConcepto = "";
            btnComprobante.Enabled = false;

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
            ultimoPagoRegistrado = null;
            ultimoConcepto = "";
            btnComprobante.Enabled = false;
            lblNombre.Text = "";
            lblApellido.Text = "";
            lblEstado.Text = "";
        }

        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Al cambiar el tipo de documento, invalidamos
            // la selección del cliente anterior.
            clienteSeleccionado = null;
            ultimoPagoRegistrado = null;
            ultimoConcepto = "";
            btnComprobante.Enabled = false;

            lblNombre.Text = "";
            lblApellido.Text = "";
            lblEstado.Text = "";
        }

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            // Verifica que exista un pago registrado
            // y un cliente seleccionado.
            if (clienteSeleccionado == null || ultimoPagoRegistrado == null)
            {
                MessageBox.Show("No hay un pago registrado para generar el comprobante.");
                return;
            }

            using SaveFileDialog guardar = new SaveFileDialog();

            guardar.Filter = "Archivo PDF (*.pdf)|*.pdf";
            guardar.FileName = "Comprobante_" +
                                 ultimoPagoRegistrado.getIdPago() + ".pdf";

            if (guardar.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                // POLIMORFISMO MEDIANTE INTERFACES:
                // La referencia es IDocumentoImprimible,
                // pero el objeto concreto es ReciboPdf.
                IDocumentoImprimible documento = new ReciboPdf(
                    clienteSeleccionado,
                    ultimoPagoRegistrado,
                    ultimoConcepto
                );

                documento.GenerarPdf(guardar.FileName);

                MessageBox.Show("Se envió el comprobante a generar como PDF.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo generar el comprobante PDF.\n\n" +
                    ex.Message
                );
            }
        }
    }
}
