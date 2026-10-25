using ClubDeportivo.Datos;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class FormCarnet : Form
    {
        private string tipoDocRecibido = "";
        private string nroDocRecibido = "";
        private Cliente? clienteActual; // Guardamos el cliente buscado

        // Constructor vacío (desde Menú Principal)
        public FormCarnet()
        {
            InitializeComponent();

        }

        private void FormCarnet_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nroDocRecibido))
            {
                cmbTipoDocumento.Text = tipoDocRecibido;
                txtNroDocumento.Text = nroDocRecibido;
                btnBuscar.PerformClick();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbTipoDocumento.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtNroDocumento.Text))
            {
                MessageBox.Show("Seleccione tipo e ingrese número de documento.");
                return;
            }

            ClienteDatos clienteDatos = new ClienteDatos();
            clienteActual = clienteDatos.buscarClientePorDocumento(cmbTipoDocumento.Text, txtNroDocumento.Text.Trim());

            if (clienteActual != null)
            {
                lblNombre.Text = clienteActual.getNombre();
                lblApellido.Text = clienteActual.getApellido();
                lblEstado.Text = clienteActual.esSocio() ? "Socio" : "No socio";

                // Si el cliente ya es socio, se muestra el carnet
                if (clienteActual.esSocio())
                {
                    CargarDatosCarnet();
                }
                else
                {
                    MessageBox.Show("Este cliente aún no es socio. Primero debe asociarlo desde el módulo de Cobros.");
                    panelCarnet.Visible = false;
                    btnImprimir.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.");
                lblNombre.Text = "";
                lblApellido.Text = "";
                lblEstado.Text = "";
                panelCarnet.Visible = false;
                btnImprimir.Visible = false;
            }
        }

        private void CargarDatosCarnet()
        {
            if (clienteActual == null || clienteActual.getCarnet() == null) return;

            // datos del "Panel" que simula el carnet
            lblCarnetNombre.Text = "Nombre y Apellido ";
            lblCarnetApellido.Text = clienteActual.getNombre() + " " + clienteActual.getApellido();
            lblCarnetNroSocio.Text = "Nro Socio: " + clienteActual.getCarnet().getNroCarnet();

            // vencimiento real desde la Base de Datos
            CuotaDatos cuotaDatos = new CuotaDatos();
            DateTime? vencimiento = cuotaDatos.buscarUltimoVencimiento(clienteActual.getCarnet().getNroCarnet());

            if (vencimiento.HasValue)
            {
                // Mostramos la fecha completa del último vencimiento
                // registrado en la base de datos.
                lblCarnetVencimiento.Text =
                    "Vence: " + vencimiento.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                lblCarnetVencimiento.Text = "Vence: ----";
            }

            //panel y botón de imprimir
            panelCarnet.Visible = true;
            btnImprimir.Visible = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Verificamos que haya un socio con carnet seleccionado.
            if (clienteActual == null || !clienteActual.esSocio())
            {
                MessageBox.Show("Primero debe buscar un socio con carnet.");
                return;
            }

            // Permitimos elegir el nombre y la ubicación del PDF.
            using SaveFileDialog guardar = new SaveFileDialog();

            guardar.Filter = "Archivo PDF (*.pdf)|*.pdf";
            guardar.FileName = "Carnet_" +
                clienteActual.getCarnet()!.getNroCarnet() + ".pdf";

            if (guardar.ShowDialog() != DialogResult.OK)
            {
                // Cancelar no modifica ningún dato del socio.
                return;
            }

            try
            {
                // POLIMORFISMO:
                // La variable es de tipo interfaz, pero el objeto
                // concreto es CarnetPdf.
                IDocumentoImprimible documento =
                    new CarnetPdf(panelCarnet);

                // Ejecutamos la implementación de CarnetPdf.
                documento.GenerarPdf(guardar.FileName);

                MessageBox.Show("Se envió el carnet a generar como PDF.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo generar el PDF: " + ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Panel centrado en la hoja A4 horizontal para impresion


            int x = (e.PageBounds.Width - panelCarnet.Width) / 2;
            int y = (e.PageBounds.Height - panelCarnet.Height) / 2;


            Bitmap bmp = new Bitmap(panelCarnet.Width, panelCarnet.Height);
            panelCarnet.DrawToBitmap(bmp, new Rectangle(0, 0, panelCarnet.Width, panelCarnet.Height));

            e.Graphics.DrawImage(bmp, x, y);
            e.HasMorePages = false;
        }

        // Los siguientes métodos limpian el carnet si se cambia el documento
        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelCarnet.Visible = false;
            btnImprimir.Visible = false;
        }

        private void txtNroDocumento_TextChanged(object sender, EventArgs e)
        {
            panelCarnet.Visible = false;
            btnImprimir.Visible = false;
        }

        private void btnEmitirCarnet_Click(object sender, EventArgs e)
        {
        }

        private void lblCarnetVencimiento_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblCarnetNroSocio_Click(object sender, EventArgs e)
        {

        }

        private void lblCarnetApellido_Click(object sender, EventArgs e)
        {

        }

        private void lblCarnetTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}