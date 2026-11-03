namespace Biblioteca.WinForms
{
    partial class FormPrincipal
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnLibros = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnAlquileres = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(50, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(370, 30);
            this.lblTitulo.Text = "Plataforma de Gestión de Biblioteca";

            // btnLibros
            this.btnLibros.Location = new System.Drawing.Point(130, 80);
            this.btnLibros.Name = "btnLibros";
            this.btnLibros.Size = new System.Drawing.Size(200, 40);
            this.btnLibros.Text = "1. Gestión de Libros";
            this.btnLibros.Click += new System.EventHandler(this.btnLibros_Click);

            // btnClientes
            this.btnClientes.Location = new System.Drawing.Point(130, 130);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(200, 40);
            this.btnClientes.Text = "2. Gestión de Clientes";
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);

            // btnAlquileres
            this.btnAlquileres.Location = new System.Drawing.Point(130, 180);
            this.btnAlquileres.Name = "btnAlquileres";
            this.btnAlquileres.Size = new System.Drawing.Size(200, 40);
            this.btnAlquileres.Text = "3. Registrar Alquiler / Devolución";
            this.btnAlquileres.Click += new System.EventHandler(this.btnAlquileres_Click);

            // btnReportes
            this.btnReportes.Location = new System.Drawing.Point(130, 230);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(200, 40);
            this.btnReportes.Text = "4. Reportes y Consultas";
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);

            // btnSalir
            this.btnSalir.Location = new System.Drawing.Point(130, 290);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(200, 40);
            this.btnSalir.Text = "0. Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // FormPrincipal
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 360);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnLibros);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnAlquileres);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnSalir);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnLibros;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnAlquileres;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnSalir;
    }
}