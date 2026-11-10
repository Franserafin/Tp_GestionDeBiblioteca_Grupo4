using System;
using System.Windows.Forms;
using AccesoDatos.Models;
using AccesoDatos.Repositories;

namespace Biblioteca.WinForms
{
    // Es CRÍTICO que diga ": Form" para que herede las propiedades visuales y se borren los errores
    public partial class FormLibros : Form
    {
        private readonly IGenericRepository<Libro> _libroRepository;

        public FormLibros(IGenericRepository<Libro> libroRepository)
        {
            InitializeComponent();
            _libroRepository = libroRepository;
        }

        private void FormLibros_Load(object sender, EventArgs e)
        {
            CargarLibros();
        }

        private void CargarLibros()
        {
            dgvLibros.DataSource = _libroRepository.ObtenerTodos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("El título es obligatorio.");
                return;
            }

            // Nueva validación para el autor
            if (string.IsNullOrWhiteSpace(txtAutor.Text))
            {
                MessageBox.Show("El autor es obligatorio.");
                return;
            }

            var nuevoLibro = new Libro
            {
                Titulo = txtTitulo.Text,
                Autor = txtAutor.Text // Asegúrate de que esta línea no esté comentada
            };

            _libroRepository.Agregar(nuevoLibro);

            MessageBox.Show("Libro agregado exitosamente.");
            LimpiarCampos();
            CargarLibros();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Seleccione un libro de la lista para modificar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("El título es obligatorio.");
                return;
            }

            // Nueva validación para el autor
            if (string.IsNullOrWhiteSpace(txtAutor.Text))
            {
                MessageBox.Show("El autor es obligatorio.");
                return;
            }

            int id = int.Parse(txtId.Text);
            var libro = _libroRepository.ObtenerPorId(id);

            if (libro != null)
            {
                libro.Titulo = txtTitulo.Text;
                libro.Autor = txtAutor.Text; // Asegúrate de que esta línea no esté comentada

                _libroRepository.Modificar(libro);
                MessageBox.Show("Libro modificado exitosamente.");
                LimpiarCampos();
                CargarLibros();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Seleccione un libro de la lista para eliminar.");
                return;
            }

            int id = int.Parse(txtId.Text);
            var libro = _libroRepository.ObtenerPorId(id);

            if (libro != null)
            {
                var confirmacion = MessageBox.Show("¿Está seguro de eliminar este libro?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirmacion == DialogResult.Yes)
                {
                    _libroRepository.Eliminar(id);
                    MessageBox.Show("Libro eliminado.");
                    LimpiarCampos();
                    CargarLibros();
                }
            }
        }

        private void dgvLibros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvLibros.Rows[e.RowIndex];

                txtId.Text = fila.Cells["Id"].Value?.ToString();
                txtTitulo.Text = fila.Cells["Titulo"].Value?.ToString();
                txtAutor.Text = fila.Cells["Autor"].Value?.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtTitulo.Clear();
            txtAutor.Clear();
        }
    }
}
