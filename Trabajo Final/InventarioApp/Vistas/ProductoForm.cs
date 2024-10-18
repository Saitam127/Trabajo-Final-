using System;
using System.Windows.Forms;
using InventarioApp.Modelos;
using InventarioApp.Controladores;

namespace InventarioApp.Vistas
{
    public partial class ProductForm : Form
    {
        private ProductoController productoController;

        public ProductForm(ProductoController controller)
        {
            InitializeComponent();
            productoController = controller;
            CargarProductos();
        }

        private void CargarProductos()
        {
            var productos = productoController.ObtenerProductos();
            dgvProductos.DataSource = productos;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            var producto = new Producto
            {
                Nombre = txtNombreProducto.Text,
                Codigo = txtCodigoProducto.Text,
                CategoriaId = Convert.ToInt32(txtCategoriaProducto.Text),
                Precio = Convert.ToDouble(txtPrecioProducto.Text),
                Existencia = Convert.ToInt32(txtExistenciaProducto.Text),
                ProveedorId = Convert.ToInt32(txtProveedorProducto.Text)
            };

            productoController.AgregarProducto(producto);
            LimpiarCampos();
            CargarProductos();
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                var productoId = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["Id"].Value);
                var producto = new Producto
                {
                    Id = productoId,
                    Nombre = txtNombreProducto.Text,
                    Codigo = txtCodigoProducto.Text,
                    CategoriaId = Convert.ToInt32(txtCategoriaProducto.Text),
                    Precio = Convert.ToDouble(txtPrecioProducto.Text),
                    Existencia = Convert.ToInt32(txtExistenciaProducto.Text),
                    ProveedorId = Convert.ToInt32(txtProveedorProducto.Text)
                };

                productoController.EditarProducto(producto);
                LimpiarCampos();
                CargarProductos();
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                var productoId = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["Id"].Value);
                productoController.EliminarProducto(productoId);
                CargarProductos();
            }
        }

        private void LimpiarCampos()
        {
            txtNombreProducto.Clear();
            txtCodigoProducto.Clear();
            txtCategoriaProducto.Clear();
            txtPrecioProducto.Clear();
            txtExistenciaProducto.Clear();
            txtProveedorProducto.Clear();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                var producto = (Producto)dgvProductos.SelectedRows[0].DataBoundItem;
                txtNombreProducto.Text = producto.Nombre;
                txtCodigoProducto.Text = producto.Codigo;
                txtCategoriaProducto.Text = producto.CategoriaId.ToString();
                txtPrecioProducto.Text = producto.Precio.ToString();
                txtExistenciaProducto.Text = producto.Existencia.ToString();
                txtProveedorProducto.Text = producto.ProveedorId.ToString();
            }
        }
    }
}

namespace InventarioApp.Vistas
{
    partial class ProductForm
    {
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.TextBox txtCodigoProducto;
        private System.Windows.Forms.TextBox txtCategoriaProducto;
        private System.Windows.Forms.TextBox txtPrecioProducto;
        private System.Windows.Forms.TextBox txtExistenciaProducto;
        private System.Windows.Forms.TextBox txtProveedorProducto;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnEditarProducto;
        private System.Windows.Forms.Button btnEliminarProducto;

        private void InitializeComponent()
        {
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.txtCategoriaProducto = new System.Windows.Forms.TextBox();
            this.txtPrecioProducto = new System.Windows.Forms.TextBox();
            this.txtExistenciaProducto = new System.Windows.Forms.TextBox();
            this.txtProveedorProducto = new System.Windows.Forms.TextBox();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnEditarProducto = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();

            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(12, 12);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(600, 200);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);

            this.txtNombreProducto.Location = new System.Drawing.Point(12, 220);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(150, 20);
            this.txtNombreProducto.TabIndex = 1;

            this.txtCodigoProducto.Location = new System.Drawing.Point(12, 250);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.Size = new System.Drawing.Size(150, 20);
            this.txtCodigoProducto.TabIndex = 2;

            this.txtCategoriaProducto.Location = new System.Drawing.Point(12, 280);
            this.txtCategoriaProducto.Name = "txtCategoriaProducto";
            this.txtCategoriaProducto.Size = new System.Drawing.Size(150, 20);
            this.txtCategoriaProducto.TabIndex = 3;

            this.txtPrecioProducto.Location = new System.Drawing.Point(12, 310);
            this.txtPrecioProducto.Name = "txtPrecioProducto";
            this.txtPrecioProducto.Size = new System.Drawing.Size(150, 20);
            this.txtPrecioProducto.TabIndex = 4;

            this.txtExistenciaProducto.Location = new System.Drawing.Point(12, 340);
            this.txtExistenciaProducto.Name = "txtExistenciaProducto";
            this.txtExistenciaProducto.Size = new System.Drawing.Size(150, 20);
            this.txtExistenciaProducto.TabIndex = 5;

            this.txtProveedorProducto.Location = new System.Drawing.Point(12, 370);
            this.txtProveedorProducto.Name = "txtProveedorProducto";
            this.txtProveedorProducto.Size = new System.Drawing.Size(150, 20);
            this.txtProveedorProducto.TabIndex = 6;

            this.btnAgregarProducto.Location = new System.Drawing.Point(200, 220);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(100, 30);
            this.btnAgregarProducto.TabIndex = 7;
            this.btnAgregarProducto.Text = "Agregar";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);

            this.btnEditarProducto.Location = new System.Drawing.Point(200, 260);
            this.btnEditarProducto.Name = "btnEditarProducto";
            this.btnEditarProducto.Size = new System.Drawing.Size(100, 30);
            this.btnEditarProducto.TabIndex = 8;
            this.btnEditarProducto.Text = "Editar";
            this.btnEditarProducto.UseVisualStyleBackColor = true;
            this.btnEditarProducto.Click += new System.EventHandler(this.btnEditarProducto_Click);

            this.btnEliminarProducto.Location = new System.Drawing.Point(200, 300);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarProducto.TabIndex = 9;
            this.btnEliminarProducto.Text = "Eliminar";
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);

            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.btnEditarProducto);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.txtProveedorProducto);
            this.Controls.Add(this.txtExistenciaProducto);
            this.Controls.Add(this.txtPrecioProducto);
            this.Controls.Add(this.txtCategoriaProducto);
            this.Controls.Add(this.txtCodigoProducto);
            this.Controls.Add(this.txtNombreProducto);
            this.Controls.Add(this.dgvProductos);
            this.Name = "ProductForm";
            this.Text = "Gestión de Productos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}