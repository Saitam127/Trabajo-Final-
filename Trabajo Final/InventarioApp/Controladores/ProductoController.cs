using System.Collections.Generic;
using System.Data.SQLite;
using InventarioApp.Modelos;
using InventarioApp.Helpers;

namespace InventarioApp.Controladores
{
    public class ProductoController
    {
        private DatabaseHelper dbHelper;

        public ProductoController(DatabaseHelper helper)
        {
            dbHelper = helper;
        }

        public List<Producto> ObtenerProductos()
        {
            var productos = new List<Producto>();

            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    var query = "SELECT * FROM Productos";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var producto = new Producto
                                {
                                    Id = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    Codigo = reader.GetString(2),
                                    CategoriaId = reader.GetInt32(3),
                                    Precio = reader.GetDouble(4),
                                    Existencia = reader.GetInt32(5),
                                    ProveedorId = reader.GetInt32(6)
                                };
                                productos.Add(producto);
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                System.Console.WriteLine("Error al obtener productos: " + ex.Message);
            }

            return productos;
        }

        public void AgregarProducto(Producto producto)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    var query = "INSERT INTO Productos (Nombre, Codigo, CategoriaId, Precio, Existencia, ProveedorId) " +
                                "VALUES (@Nombre, @Codigo, @CategoriaId, @Precio, @Existencia, @ProveedorId)";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        command.Parameters.AddWithValue("@Codigo", producto.Codigo);
                        command.Parameters.AddWithValue("@CategoriaId", producto.CategoriaId);
                        command.Parameters.AddWithValue("@Precio", producto.Precio);
                        command.Parameters.AddWithValue("@Existencia", producto.Existencia);
                        command.Parameters.AddWithValue("@ProveedorId", producto.ProveedorId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                System.Console.WriteLine("Error al agregar producto: " + ex.Message);
            }
        }

        public void EditarProducto(Producto producto)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    var query = "UPDATE Productos SET Nombre = @Nombre, Codigo = @Codigo, CategoriaId = @CategoriaId, " +
                                "Precio = @Precio, Existencia = @Existencia, ProveedorId = @ProveedorId WHERE Id = @Id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        command.Parameters.AddWithValue("@Codigo", producto.Codigo);
                        command.Parameters.AddWithValue("@CategoriaId", producto.CategoriaId);
                        command.Parameters.AddWithValue("@Precio", producto.Precio);
                        command.Parameters.AddWithValue("@Existencia", producto.Existencia);
                        command.Parameters.AddWithValue("@ProveedorId", producto.ProveedorId);
                        command.Parameters.AddWithValue("@Id", producto.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                System.Console.WriteLine("Error al editar producto: " + ex.Message);
            }
        }

        public void EliminarProducto(int productoId)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    var query = "DELETE FROM Productos WHERE Id = @Id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", productoId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                System.Console.WriteLine("Error al eliminar producto: " + ex.Message);
            }
        }
    }
}