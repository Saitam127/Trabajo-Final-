using System;
using System.Windows.Forms;
using InventarioApp.Modelos;
using InventarioApp.Controladores;

namespace InventarioApp.Vistas
{
    public partial class ProveedorForm : Form
    {
        private ProveedorController proveedorController;

        public ProveedorForm(ProveedorController controller)
        {
            InitializeComponent();
            proveedorController = controller;
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            var proveedores = proveedorController.ObtenerProveedores();
            dgvProveedores.DataSource = proveedores;
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            var proveedor = new Proveedor
            {
                NombreEmpresa = txtNombreProveedor.Text,
                Contacto = txtContactoProveedor.Text,
                Direccion = txtDireccionProveedor.Text,
                Telefono = txtTelefonoProveedor.Text
            };

            proveedorController.AgregarProveedor(proveedor);
            LimpiarCampos();
            CargarProveedores();
        }

        private void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                var proveedorId = Convert.ToInt32(dgvProveedores.SelectedRows[0].Cells["Id"].Value);
                var proveedor = new Proveedor
                {
                    Id = proveedorId,
                    NombreEmpresa = txtNombreProveedor.Text,
                    Contacto = txtContactoProveedor.Text,
                    Direccion = txtDireccionProveedor.Text,
                    Telefono = txtTelefonoProveedor.Text
                };

                proveedorController.EditarProveedor(proveedor);
                LimpiarCampos();
                CargarProveedores();
            }
        }

        private void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                var proveedorId = Convert.ToInt32(dgvProveedores.SelectedRows[0].Cells["Id"].Value);
                proveedorController.EliminarProveedor(proveedorId);
                CargarProveedores();
            }
        }

        private void LimpiarCampos()
        {
            txtNombreProveedor.Clear();
            txtContactoProveedor.Clear();
            txtDireccionProveedor.Clear();
            txtTelefonoProveedor.Clear();
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                var proveedor = (Proveedor)dgvProveedores.SelectedRows[0].DataBoundItem;
                txtNombreProveedor.Text = proveedor.NombreEmpresa;
                txtContactoProveedor.Text = proveedor.Contacto;
                txtDireccionProveedor.Text = proveedor.Direccion;
                txtTelefonoProveedor.Text = proveedor.Telefono;
            }
        }
    }
}

namespace InventarioApp.Vistas
{
    partial class ProveedorForm
    {
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.TextBox txtNombreProveedor;
        private System.Windows.Forms.TextBox txtContactoProveedor;
        private System.Windows.Forms.TextBox txtDireccionProveedor;
        private System.Windows.Forms.TextBox txtTelefonoProveedor;
        private System.Windows.Forms.Button btnAgregarProveedor;
        private System.Windows.Forms.Button btnEditarProveedor;
        private System.Windows.Forms.Button btnEliminarProveedor;

        private void InitializeComponent()
        {
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.txtNombreProveedor = new System.Windows.Forms.TextBox();
            this.txtContactoProveedor = new System.Windows.Forms.TextBox();
            this.txtDireccionProveedor = new System.Windows.Forms.TextBox();
            this.txtTelefonoProveedor = new System.Windows.Forms.TextBox();
            this.btnAgregarProveedor = new System.Windows.Forms.Button();
            this.btnEditarProveedor = new System.Windows.Forms.Button();
            this.btnEliminarProveedor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();

            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Location = new System.Drawing.Point(12, 12);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(600, 200);
            this.dgvProveedores.TabIndex = 0;
            this.dgvProveedores.SelectionChanged += new System.EventHandler(this.dgvProveedores_SelectionChanged);

            this.txtNombreProveedor.Location = new System.Drawing.Point(12, 220);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(150, 20);
            this.txtNombreProveedor.TabIndex = 1;

            this.txtContactoProveedor.Location = new System.Drawing.Point(12, 250);
            this.txtContactoProveedor.Name = "txtContactoProveedor";
            this.txtContactoProveedor.Size = new System.Drawing.Size(150, 20);
            this.txtContactoProveedor.TabIndex = 2;

            this.txtDireccionProveedor.Location = new System.Drawing.Point(12, 280);
            this.txtDireccionProveedor.Name = "txtDireccionProveedor";
            this.txtDireccionProveedor.Size = new System.Drawing.Size(150, 20);
            this.txtDireccionProveedor.TabIndex = 3;

            this.txtTelefonoProveedor.Location = new System.Drawing.Point(12, 310);
            this.txtTelefonoProveedor.Name = "txtTelefonoProveedor";
            this.txtTelefonoProveedor.Size = new System.Drawing.Size(150, 20);
            this.txtTelefonoProveedor.TabIndex = 4;

            this.btnAgregarProveedor.Location = new System.Drawing.Point(200, 220);
            this.btnAgregarProveedor.Name = "btnAgregarProveedor";
            this.btnAgregarProveedor.Size = new System.Drawing.Size(100, 30);
            this.btnAgregarProveedor.TabIndex = 5;
            this.btnAgregarProveedor.Text = "Agregar";
            this.btnAgregarProveedor.UseVisualStyleBackColor = true;
            this.btnAgregarProveedor.Click += new System.EventHandler(this.btnAgregarProveedor_Click);

            this.btnEditarProveedor.Location = new System.Drawing.Point(200, 260);
            this.btnEditarProveedor.Name = "btnEditarProveedor";
            this.btnEditarProveedor.Size = new System.Drawing.Size(100, 30);
            this.btnEditarProveedor.TabIndex = 6;
            this.btnEditarProveedor.Text = "Editar";
            this.btnEditarProveedor.UseVisualStyleBackColor = true;
            this.btnEditarProveedor.Click += new System.EventHandler(this.btnEditarProveedor_Click);

            this.btnEliminarProveedor.Location = new System.Drawing.Point(200, 300);
            this.btnEliminarProveedor.Name = "btnEliminarProveedor";
            this.btnEliminarProveedor.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarProveedor.TabIndex = 7;
            this.btnEliminarProveedor.Text = "Eliminar";
            this.btnEliminarProveedor.UseVisualStyleBackColor = true;
            this.btnEliminarProveedor.Click += new System.EventHandler(this.btnEliminarProveedor_Click);

            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.btnEliminarProveedor);
            this.Controls.Add(this.btnEditarProveedor);
            this.Controls.Add(this.btnAgregarProveedor);
            this.Controls.Add(this.txtTelefonoProveedor);
            this.Controls.Add(this.txtDireccionProveedor);
            this.Controls.Add(this.txtContactoProveedor);
            this.Controls.Add(this.txtNombreProveedor);
            this.Controls.Add(this.dgvProveedores);
            this.Name = "ProveedorForm";
            this.Text = "Gestión de Proveedores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}