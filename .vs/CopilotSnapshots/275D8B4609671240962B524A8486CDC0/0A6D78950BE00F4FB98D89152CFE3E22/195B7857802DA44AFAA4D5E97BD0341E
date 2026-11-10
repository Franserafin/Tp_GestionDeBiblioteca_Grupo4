using System;
using System.Windows.Forms;

namespace Biblioteca.WinForms
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            // Abre la pantalla de libros que ya construimos
            FormLibros formLibros = new FormLibros();
            formLibros.ShowDialog(); // ShowDialog impide usar el menú hasta que cierres la ventana de libros
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            formClientes.ShowDialog();
        }

        private void btnAlquileres_Click(object sender, EventArgs e)
        {
            FormAlquileres formAlquileres = new FormAlquileres();
            formAlquileres.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            // Abre la nueva pantalla de reportes
            FormReportes formReportes = new FormReportes();
            formReportes.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cierra la aplicación por completo
            Application.Exit();
        }
    }
}
