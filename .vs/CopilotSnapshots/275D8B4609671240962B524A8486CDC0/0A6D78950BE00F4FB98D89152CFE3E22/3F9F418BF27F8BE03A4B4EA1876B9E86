using System;
using System.Linq;
using System.Windows.Forms;
using AccesoDatos.Data;
using AccesoDatos.Models;

namespace Biblioteca.WinForms
{
    public partial class FormClientes : Form
    {
        private AplicationDbContext _context;

        public FormClientes()
        {
            InitializeComponent();
            _context = new AplicationDbContext();
            _context.Database.EnsureCreated();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = _context.Clientes.ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas requeridas
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("El documento es obligatorio.");
                return;
            }

            // Opcional: Validar que el documento sea numérico
            if (!int.TryParse(txtDocumento.Text, out _))
            {
                MessageBox.Show("El documento debe contener solo números.");
                return;
            }

            var nuevoCliente = new Cliente
            {
                // ATENCIÓN: Asegúrate de que estas propiedades existan en tu clase Cliente
                Nombre = txtNombre.Text,
                // Documento = txtDocumento.Text // Descomenta o ajusta según tu modelo (ej. Dni = txtDocumento.Text)
            };

            _context.Clientes.Add(nuevoCliente);
            _context.SaveChanges();

            MessageBox.Show("Cliente agregado exitosamente.");
            LimpiarCampos();
            CargarClientes();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Seleccione un cliente de la lista para modificar.");
                return;
            }

            int id = int.Parse(txtId.Text);
            var cliente = _context.Clientes.FirstOrDefault(c => c.id == id);

            if (cliente != null)
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDocumento.Text))
                {
                    MessageBox.Show("El nombre y el documento son obligatorios.");
                    return;
                }

                cliente.Nombre = txtNombre.Text;
                // cliente.Documento = txtDocumento.Text; // Ajusta según tu modelo

                _context.SaveChanges();
                MessageBox.Show("Cliente modificado exitosamente.");
                LimpiarCampos();
                CargarClientes();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Seleccione un cliente de la lista para eliminar.");
                return;
            }

            int id = int.Parse(txtId.Text);
            var cliente = _context.Clientes.FirstOrDefault(c => c.id == id);

            if (cliente != null)
            {
                var confirmacion = MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirmacion == DialogResult.Yes)
                {
                    _context.Clientes.Remove(cliente);
                    _context.SaveChanges();
                    MessageBox.Show("Cliente eliminado.");
                    LimpiarCampos();
                    CargarClientes();
                }
            }
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                txtId.Text = fila.Cells["Id"].Value?.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
                // txtDocumento.Text = fila.Cells["Documento"].Value?.ToString(); // Ajusta según tu modelo
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtDocumento.Clear();
        }
    }
}
