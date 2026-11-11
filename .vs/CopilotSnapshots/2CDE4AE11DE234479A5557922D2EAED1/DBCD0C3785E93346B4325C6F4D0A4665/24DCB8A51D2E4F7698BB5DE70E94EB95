using System;
using System.Windows.Forms;
using AccesoDatos.Models;
using AccesoDatos.Repositories;

namespace Biblioteca.WinForms
{
    public partial class FormAlquileres : Form
    {
        private const decimal PenalidadDiaria = 500m;

        private readonly IGenericRepository<Alquiler> _alquilerRepository;
        private readonly IGenericRepository<Libro> _libroRepository;
        private readonly IGenericRepository<Cliente> _clienteRepository;

        public FormAlquileres(
            IGenericRepository<Alquiler> alquilerRepository,
            IGenericRepository<Libro> libroRepository,
            IGenericRepository<Cliente> clienteRepository)
        {
            InitializeComponent();
            _alquilerRepository = alquilerRepository;
            _libroRepository = libroRepository;
            _clienteRepository = clienteRepository;
        }

        private void FormAlquileres_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarAlquileres();
        }

        private void CargarCombos()
        {
            // Cargar Libros en el ComboBox
            cmbLibro.DataSource = _libroRepository.ObtenerTodos();
            cmbLibro.DisplayMember = "Titulo";
            cmbLibro.ValueMember = "Id";

            // Cargar Clientes en el ComboBox
            cmbCliente.DataSource = _clienteRepository.ObtenerTodos();
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "Id";
        }

        private void CargarAlquileres()
        {
            dgvAlquileres.DataSource = _alquilerRepository.ObtenerTodos();
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            dgvAlquileres.Columns["LibroId"]!.Visible = false;
            dgvAlquileres.Columns["ClienteId"]!.Visible = false;
            dgvAlquileres.Columns["Libro"]!.Visible = false;
            dgvAlquileres.Columns["Cliente"]!.Visible = false;
            dgvAlquileres.Columns["FechaDevolucion"]!.Visible = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cmbLibro.SelectedValue == null || cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un libro y un cliente.");
                return;
            }

            if (!decimal.TryParse(txtCostoReserva.Text, out decimal costoReserva) || costoReserva < 0)
            {
                MessageBox.Show("Ingrese un costo de reserva válido y no negativo.");
                txtCostoReserva.Focus();
                return;
            }

            int idLibro = Convert.ToInt32(cmbLibro.SelectedValue);
            var libro = _libroRepository.ObtenerPorId(idLibro);
            if (libro == null || !string.Equals(libro.Estado, "Disponible", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("El libro no se puede alquilar en este momento.");
                return;
            }

            DateTime fechaDevolucionEsperada = dtpFechaDevolucion.Value;
            if (fechaDevolucionEsperada.Date < DateTime.Today.AddDays(1))
            {
                MessageBox.Show("El tiempo mínimo de alquiler es de un día.");
                return;
            }

            var nuevoAlquiler = new Alquiler
            {
                LibroId = idLibro,
                ClienteId = Convert.ToInt32(cmbCliente.SelectedValue),
                FechaPrestamo = DateTime.Now,
                FechaDevolucion = fechaDevolucionEsperada,
                CostoReserva = costoReserva,
                FechaDevolucionEsperada = fechaDevolucionEsperada,
                FechaDevolucionReal = null,
                MontoPenalidad = 0m,
                Devuelto = false
            };

            _alquilerRepository.Agregar(nuevoAlquiler);

            libro.Estado = "No disponible";
            _libroRepository.Modificar(libro);

            MessageBox.Show("Alquiler registrado con éxito.");
            CargarAlquileres();
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (dgvAlquileres.CurrentRow != null)
            {
                int idAlquiler = (int)dgvAlquileres.CurrentRow.Cells["Id"].Value;
                var alquiler = _alquilerRepository.ObtenerPorId(idAlquiler);

                if (alquiler != null && !alquiler.Devuelto)
                {
                    alquiler.FechaDevolucionReal = DateTime.Now;
                    int diasAtraso = Math.Max(
                        0,
                        (alquiler.FechaDevolucionReal.Value.Date - alquiler.FechaDevolucionEsperada.Date).Days);
                    alquiler.MontoPenalidad = diasAtraso * PenalidadDiaria;
                    alquiler.Devuelto = true;
                    _alquilerRepository.Modificar(alquiler);

                    var libro = _libroRepository.ObtenerPorId(alquiler.LibroId);
                    if (libro != null)
                    {
                        libro.Estado = "Disponible";
                        _libroRepository.Modificar(libro);
                    }

                    if (diasAtraso > 0)
                    {
                        MessageBox.Show(
                            $"Libro devuelto con {diasAtraso} día(s) de atraso. Penalidad a cobrar: ${alquiler.MontoPenalidad:N2}.");
                    }
                    else
                    {
                        MessageBox.Show("Libro marcado como devuelto. No se aplica penalidad.");
                    }

                    CargarAlquileres();
                }
                else
                {
                    MessageBox.Show("El alquiler ya fue devuelto o no es válido.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un alquiler de la tabla.");
            }
        }
    }
}