using System;
using System.Windows.Forms;
using InventarioApp.Modelos;
using InventarioApp.Controladores;

namespace InventarioApp.Vistas
{
    public partial class CategoriaForm : Form
    {
        private CategoriaController categoriaController;

        public CategoriaForm(CategoriaController controller)
        {
            InitializeComponent();
            categoriaController = controller;
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            var categorias = categoriaController.ObtenerCategorias();
            dgvCategorias.DataSource = categorias;
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            var categoria = new Categoria
            {
                Nombre = txtNombreCategoria.Text,
                Descripcion = txtDescripcionCategoria.Text
            };

            categoriaController.AgregarCategoria(categoria);
            LimpiarCampos();
            CargarCategorias();
        }

        private void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                var categoriaId = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["Id"].Value);
                var categoria = new Categoria
                {
                    Id = categoriaId,
                    Nombre = txtNombreCategoria.Text,
                    Descripcion = txtDescripcionCategoria.Text
                };

                categoriaController.EditarCategoria(categoria);
                LimpiarCampos();
                CargarCategorias();
            }
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                var categoriaId = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["Id"].Value);
                categoriaController.EliminarCategoria(categoriaId);
                CargarCategorias();
            }
        }

        private void LimpiarCampos()
        {
            txtNombreCategoria.Clear();
            txtDescripcionCategoria.Clear();
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                var categoria = (Categoria)dgvCategorias.SelectedRows[0].DataBoundItem;
                txtNombreCategoria.Text = categoria.Nombre;
                txtDescripcionCategoria.Text = categoria.Descripcion;
            }
        }
    }
}

namespace InventarioApp.Vistas
{
    partial class CategoriaForm
    {
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.TextBox txtNombreCategoria;
        private System.Windows.Forms.TextBox txtDescripcionCategoria;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.Button btnEditarCategoria;
        private System.Windows.Forms.Button btnEliminarCategoria;

        private void InitializeComponent()
        {
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.txtNombreCategoria = new System.Windows.Forms.TextBox();
            this.txtDescripcionCategoria = new System.Windows.Forms.TextBox();
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.btnEditarCategoria = new System.Windows.Forms.Button();
            this.btnEliminarCategoria = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.SuspendLayout();

            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Location = new System.Drawing.Point(12, 12);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategorias.Size = new System.Drawing.Size(600, 200);
            this.dgvCategorias.TabIndex = 0;
            this.dgvCategorias.SelectionChanged += new System.EventHandler(this.dgvCategorias_SelectionChanged);

            this.txtNombreCategoria.Location = new System.Drawing.Point(12, 220);
            this.txtNombreCategoria.Name = "txtNombreCategoria";
            this.txtNombreCategoria.Size = new System.Drawing.Size(150, 20);
            this.txtNombreCategoria.TabIndex = 1;

            this.txtDescripcionCategoria.Location = new System.Drawing.Point(12, 250);
            this.txtDescripcionCategoria.Name = "txtDescripcionCategoria";
            this.txtDescripcionCategoria.Size = new System.Drawing.Size(150, 20);
            this.txtDescripcionCategoria.TabIndex = 2;

            this.btnAgregarCategoria.Location = new System.Drawing.Point(200, 220);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(100, 30);
            this.btnAgregarCategoria.TabIndex = 3;
            this.btnAgregarCategoria.Text = "Agregar";
            this.btnAgregarCategoria.UseVisualStyleBackColor = true;
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);

            this.btnEditarCategoria.Location = new System.Drawing.Point(200, 260);
            this.btnEditarCategoria.Name = "btnEditarCategoria";
            this.btnEditarCategoria.Size = new System.Drawing.Size(100, 30);
            this.btnEditarCategoria.TabIndex = 4;
            this.btnEditarCategoria.Text = "Editar";
            this.btnEditarCategoria.UseVisualStyleBackColor = true;
            this.btnEditarCategoria.Click += new System.EventHandler(this.btnEditarCategoria_Click);

            this.btnEliminarCategoria.Location = new System.Drawing.Point(200, 300);
            this.btnEliminarCategoria.Name = "btnEliminarCategoria";
            this.btnEliminarCategoria.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarCategoria.TabIndex = 5;
            this.btnEliminarCategoria.Text = "Eliminar";
            this.btnEliminarCategoria.UseVisualStyleBackColor = true;
            this.btnEliminarCategoria.Click += new System.EventHandler(this.btnEliminarCategoria_Click);

            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.btnEliminarCategoria);
            this.Controls.Add(this.btnEditarCategoria);
            this.Controls.Add(this.btnAgregarCategoria);
            this.Controls.Add(this.txtDescripcionCategoria);
            this.Controls.Add(this.txtNombreCategoria);
            this.Controls.Add(this.dgvCategorias);
            this.Name = "CategoriaForm";
            this.Text = "Gestión de Categorías";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}