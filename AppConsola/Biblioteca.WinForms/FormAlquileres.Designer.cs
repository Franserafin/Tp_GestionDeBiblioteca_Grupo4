namespace Biblioteca.WinForms
{
    partial class FormAlquileres
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvAlquileres = new System.Windows.Forms.DataGridView();
            this.cmbLibro = new System.Windows.Forms.ComboBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.dtpFechaDevolucion = new System.Windows.Forms.DateTimePicker();
            this.txtCostoReserva = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.lblLibro = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCostoReserva = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquileres)).BeginInit();
            this.SuspendLayout();

            // dgvAlquileres
            this.dgvAlquileres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlquileres.Location = new System.Drawing.Point(12, 12);
            this.dgvAlquileres.Name = "dgvAlquileres";
            this.dgvAlquileres.Size = new System.Drawing.Size(550, 200);
            this.dgvAlquileres.TabIndex = 0;

            // lblLibro
            this.lblLibro.AutoSize = true;
            this.lblLibro.Location = new System.Drawing.Point(12, 230);
            this.lblLibro.Name = "lblLibro";
            this.lblLibro.Size = new System.Drawing.Size(37, 15);
            this.lblLibro.Text = "Libro:";

            // cmbLibro
            this.cmbLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLibro.FormattingEnabled = true;
            this.cmbLibro.Location = new System.Drawing.Point(70, 227);
            this.cmbLibro.Name = "cmbLibro";
            this.cmbLibro.Size = new System.Drawing.Size(200, 23);

            // lblCliente
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(12, 265);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(47, 15);
            this.lblCliente.Text = "Cliente:";

            // cmbCliente
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(70, 262);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(200, 23);

            // lblFecha
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 300);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(71, 15);
            this.lblFecha.Text = "Devolución:";

            // dtpFechaDevolucion
            this.dtpFechaDevolucion.Location = new System.Drawing.Point(90, 297);
            this.dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            this.dtpFechaDevolucion.Size = new System.Drawing.Size(180, 23);

            // lblCostoReserva
            this.lblCostoReserva.AutoSize = true;
            this.lblCostoReserva.Location = new System.Drawing.Point(12, 335);
            this.lblCostoReserva.Name = "lblCostoReserva";
            this.lblCostoReserva.Size = new System.Drawing.Size(78, 15);
            this.lblCostoReserva.Text = "Costo reserva:";

            // txtCostoReserva
            this.txtCostoReserva.Location = new System.Drawing.Point(90, 332);
            this.txtCostoReserva.Name = "txtCostoReserva";
            this.txtCostoReserva.Size = new System.Drawing.Size(180, 23);

            // btnRegistrar
            this.btnRegistrar.Location = new System.Drawing.Point(320, 225);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(120, 40);
            this.btnRegistrar.Text = "Registrar Alquiler";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            // btnDevolver
            this.btnDevolver.Location = new System.Drawing.Point(320, 280);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(120, 40);
            this.btnDevolver.Text = "Marcar Devuelto";
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);

            // FormAlquileres
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 375);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtCostoReserva);
            this.Controls.Add(this.lblCostoReserva);
            this.Controls.Add(this.dtpFechaDevolucion);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cmbLibro);
            this.Controls.Add(this.lblLibro);
            this.Controls.Add(this.dgvAlquileres);
            this.Name = "FormAlquileres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Alquileres";
            this.Load += new System.EventHandler(this.FormAlquileres_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquileres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvAlquileres;
        private System.Windows.Forms.ComboBox cmbLibro;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.DateTimePicker dtpFechaDevolucion;
        private System.Windows.Forms.TextBox txtCostoReserva;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Label lblLibro;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCostoReserva;
    }
}