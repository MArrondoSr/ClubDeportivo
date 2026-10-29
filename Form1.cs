using ClubDeportivo.Datos;

namespace ClubDeportivo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            FormRegistroCliente formularioRegistro = new FormRegistroCliente();
            formularioRegistro.ShowDialog();
        }

        private void btnCobrosCarnet_Click(object sender, EventArgs e)
        {
            FormCobrosCarnet formulario = new FormCobrosCarnet();
            formulario.ShowDialog();
        }

        private void btnListarClientes_Click(object sender, EventArgs e)
        {
            FormListarClientes formulario = new FormListarClientes();
            formulario.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Cerramos el menú principal.
            // Al finalizar ShowDialog(), regresamos a FormLogin.
            this.Close();
        }

        private void btnVtos_Click(object sender, EventArgs e)
        {
            // Creamos una instancia del formulario de vencimientos.
            FormVencimientos formulario = new FormVencimientos();

            // ShowDialog() abre el formulario de manera modal:
            // el usuario debe cerrarlo antes de regresar al menú principal.
            formulario.ShowDialog();
        }

        private void btnCarnet_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario para consultar e imprimir
            // el carnet de un socio existente.
            // No genera un nuevo carnet ni registra pagos.
            FormCarnet formulario = new FormCarnet();

            // Apertura modal, igual que los demás formularios.
            formulario.ShowDialog();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            int socios = EstadisticasClub.ContarSocios();
            int noSocios = EstadisticasClub.ContarNoSocios();

            MessageBox.Show(
                $"Socios: {socios}\n" +
                $"No socios: {noSocios}\n" +
                $"Total de clientes: {socios + noSocios}",
                "Estadísticas de " + EstadisticasClub.NombreClub,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
