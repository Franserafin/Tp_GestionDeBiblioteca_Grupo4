using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.WinForms
{
    public partial class FormPrincipal : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public FormPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            TemaVisual.AplicarTemaGlobal(this);
            _serviceProvider = serviceProvider;
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            // Abre la pantalla de libros que ya construimos
            using FormLibros formLibros = _serviceProvider.GetRequiredService<FormLibros>();
            formLibros.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            using FormClientes formClientes = _serviceProvider.GetRequiredService<FormClientes>();
            formClientes.ShowDialog();
        }

        private void btnAlquileres_Click(object sender, EventArgs e)
        {
            using FormAlquileres formAlquileres = _serviceProvider.GetRequiredService<FormAlquileres>();
            formAlquileres.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            using FormReportes formReportes = _serviceProvider.GetRequiredService<FormReportes>();
            formReportes.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cierra la aplicación por completo
            Application.Exit();
        }
    }
}
