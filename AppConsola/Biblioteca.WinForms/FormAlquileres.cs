using System;
using System.Linq;
using System.Windows.Forms;
using AccesoDatos.Data;
using AccesoDatos.Models;

namespace Biblioteca.WinForms
{
    public partial class FormAlquileres : Form
    {
        private AplicationDbContext _context;

        public FormAlquileres()
        {
            InitializeComponent();
            _context = new AplicationDbContext();
            _context.Database.EnsureCreated();

        }

        private void FormAlquileres_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarAlquileres();
        }

        private void CargarCombos()
        {
            // Cargar Libros en el ComboBox
            cmbLibro.DataSource = _context.Libros.ToList();
            cmbLibro.DisplayMember = "Titulo";
            cmbLibro.ValueMember = "Id";

            // Cargar Clientes en el ComboBox
            cmbCliente.DataSource = _context.Clientes.ToList();
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "Dni"; // CAMBIA ESTO si tu identificador se llama "Id" o "Dni"
        }

        private void CargarAlquileres()
        {
            dgvAlquileres.DataSource = _context.Alquileres.ToList();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cmbLibro.SelectedValue == null || cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un libro y un cliente.");
                return;
            }

            var nuevoAlquiler = new Alquiler
            {
                LibroId = (int)cmbLibro.SelectedValue,
                ClienteId = (int)cmbCliente.SelectedValue,
                FechaPrestamo = DateTime.Now,
                FechaDevolucion = dtpFechaDevolucion.Value,
                Devuelto = false
            };

            _context.Alquileres.Add(nuevoAlquiler);
            _context.SaveChanges();

            MessageBox.Show("Alquiler registrado con éxito.");
            CargarAlquileres();
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (dgvAlquileres.CurrentRow != null)
            {
                int idAlquiler = (int)dgvAlquileres.CurrentRow.Cells["Id"].Value;
                var alquiler = _context.Alquileres.FirstOrDefault(a => a.Id == idAlquiler);

                if (alquiler != null && !alquiler.Devuelto)
                {
                    alquiler.Devuelto = true;
                    _context.SaveChanges();
                    MessageBox.Show("Libro marcado como devuelto.");
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