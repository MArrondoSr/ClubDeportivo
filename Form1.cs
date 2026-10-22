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
    }
}
