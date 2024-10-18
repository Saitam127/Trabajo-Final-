using InventarioApp.Controladores;
using InventarioApp.Helpers;
using System.Windows.Forms;
using System;

namespace InventarioApp.Vistas
{
    public partial class MainForm : Form
    {
        private DatabaseHelper dbHelper;
        private ProductoController productoController;
        private CategoriaController categoriaController;
        private ProveedorController proveedorController;

        public MainForm()
        {
            InitializeComponent();

            dbHelper = new DatabaseHelper("ruta_a_tu_base_de_datos.db");
            dbHelper.CreateTables();

            productoController = new ProductoController(dbHelper);
            categoriaController = new CategoriaController(dbHelper);
            proveedorController = new ProveedorController(dbHelper);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void btnGestionarProductos_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm(productoController);
            productForm.ShowDialog();
        }

        private void btnGestionarCategorias_Click(object sender, EventArgs e)
        {
            var categoriaForm = new CategoriaForm(categoriaController);
            categoriaForm.ShowDialog();
        }

        private void btnGestionarProveedores_Click(object sender, EventArgs e)
        {
            var proveedorForm = new ProveedorForm(proveedorController);
            proveedorForm.ShowDialog();
        }
    }
}

namespace InventarioApp.Vistas
{
    partial class MainForm
    {
        private System.Windows.Forms.Button btnGestionarProductos;
        private System.Windows.Forms.Button btnGestionarCategorias;
        private System.Windows.Forms.Button btnGestionarProveedores;

        private void InitializeComponent()
        {
            this.btnGestionarProductos = new System.Windows.Forms.Button();
            this.btnGestionarCategorias = new System.Windows.Forms.Button();
            this.btnGestionarProveedores = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.btnGestionarProductos.Location = new System.Drawing.Point(12, 12);
            this.btnGestionarProductos.Name = "btnGestionarProductos";
            this.btnGestionarProductos.Size = new System.Drawing.Size(150, 40);
            this.btnGestionarProductos.TabIndex = 0;
            this.btnGestionarProductos.Text = "Gestionar Productos";
            this.btnGestionarProductos.UseVisualStyleBackColor = true;
            this.btnGestionarProductos.Click += new System.EventHandler(this.btnGestionarProductos_Click);

            this.btnGestionarCategorias.Location = new System.Drawing.Point(12, 60);
            this.btnGestionarCategorias.Name = "btnGestionarCategorias";
            this.btnGestionarCategorias.Size = new System.Drawing.Size(150, 40);
            this.btnGestionarCategorias.TabIndex = 1;
            this.btnGestionarCategorias.Text = "Gestionar Categorías";
            this.btnGestionarCategorias.UseVisualStyleBackColor = true;
            this.btnGestionarCategorias.Click += new System.EventHandler(this.btnGestionarCategorias_Click);

            this.btnGestionarProveedores.Location = new System.Drawing.Point(12, 110);
            this.btnGestionarProveedores.Name = "btnGestionarProveedores";
            this.btnGestionarProveedores.Size = new System.Drawing.Size(150, 40);
            this.btnGestionarProveedores.TabIndex = 2;
            this.btnGestionarProveedores.Text = "Gestionar Proveedores";
            this.btnGestionarProveedores.UseVisualStyleBackColor = true;
            this.btnGestionarProveedores.Click += new System.EventHandler(this.btnGestionarProveedores_Click);

            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnGestionarProveedores);
            this.Controls.Add(this.btnGestionarCategorias);
            this.Controls.Add(this.btnGestionarProductos);
            this.Name = "MainForm";
            this.Text = "Gestión de Inventario";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
        }
    }
}