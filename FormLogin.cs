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
    public partial class FormLogin: Form
    {
        public FormLogin()
        {
            InitializeComponent();

          }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombre = textUsuario.Text;
            string password = textPassword.Text;

            try
            {
                Usuario usuario = new Usuario();

                bool accesoCorrecto =
                    usuario.iniciarSesion(nombre, password);

                if (accesoCorrecto)
                {
                    this.Hide();

                    Form1 principal = new Form1();
                    // VENTANA MODAL: ShowDialog() mantiene la ejecución aquí
                    // hasta que se cierre el menú principal.
                    principal.ShowDialog();

                    // Al cerrar el menú principal, se vuelve a mostrar el login
                    // para permitir que otro usuario inicie sesión.
                    textUsuario.Clear();
                    textPassword.Clear();

                    // VENTANA NO MODAL: Show() vuelve a mostrar el login
                    // sin bloquear la ejecución del método que lo invoca.
                    this.Show();
                    textUsuario.Focus();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo conectar con la base de datos.\n\n" +
                    ex.Message
                );
            }
        }


    }
}
