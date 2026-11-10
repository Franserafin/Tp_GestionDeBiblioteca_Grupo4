using System;
using System.Linq;
using System.Windows.Forms;
using AccesoDatos.Models;
using AccesoDatos.Repositories;

namespace Biblioteca.WinForms
{
    public partial class FormReportes : Form
    {
        private readonly IGenericRepository<Libro> _libroRepository;
        private readonly IGenericRepository<Cliente> _clienteRepository;

        public FormReportes(
            IGenericRepository<Libro> libroRepository,
            IGenericRepository<Cliente> clienteRepository)
        {
            InitializeComponent();
            _libroRepository = libroRepository;
            _clienteRepository = clienteRepository;
        }

        // Reporte 1: Consulta básica de todos los libros
        private void btnReporte1_Click(object sender, EventArgs e)
        {
            var libros = _libroRepository.ObtenerTodos();
            dgvReportes.DataSource = libros;
        }

        // Reporte 2: Consulta de otra tabla (Clientes)
        private void btnReporte2_Click(object sender, EventArgs e)
        {
            // Asumiendo que tienes un DbSet<Cliente> Clientes en tu DbContext
            var clientes = _clienteRepository.ObtenerTodos();
            dgvReportes.DataSource = clientes;
        }

        // Reporte 3: Consulta ordenada alfabéticamente (OrderBy)
        private void btnReporte3_Click(object sender, EventArgs e)
        {
            var librosOrdenados = _libroRepository.ObtenerTodos()
                                          .OrderBy(l => l.Titulo)
                                          .ToList();
            dgvReportes.DataSource = librosOrdenados;
        }

        // Reporte 4: Consulta combinada (Top 5 más recientes)
        private void btnReporte4_Click(object sender, EventArgs e)
        {
            var ultimosLibros = _libroRepository.ObtenerTodos()
                                        .OrderByDescending(l => l.Id)
                                        .Take(5)
                                        .ToList();
            dgvReportes.DataSource = ultimosLibros;
        }

        // Reporte 5: Consulta con filtro dinámico (Where)
        private void btnReporte5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Ingrese un texto para buscar.");
                return;
            }

            var textoBusqueda = txtBuscar.Text.ToLower();

            // Busca libros que contengan el texto escrito en el título
            var resultados = _libroRepository.ObtenerTodos()
                                     .Where(l => l.Titulo.ToLower().Contains(textoBusqueda))
                                     .ToList();

            dgvReportes.DataSource = resultados;
        }
    }
}