using System.Collections.Generic;
using System.Data.SQLite;
using InventarioApp.Modelos;
using InventarioApp.Helpers;

namespace InventarioApp.Controladores
{
    public class CategoriaController
    {
        private DatabaseHelper dbHelper;

        public CategoriaController(DatabaseHelper helper)
        {
            dbHelper = helper;
        }

        public List<Categoria> ObtenerCategorias()
        {
            var categorias = new List<Categoria>();

            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    var query = "SELECT * FROM Categorias";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var categoria = new Categoria
                                {
                                    Id = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    Descripcion = reader.GetString(2)
                                };
                                categorias.Add(categoria);
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                System.Console.WriteLine("Error al obtener categorías: " + ex.Message);
            }

            return categorias;
        }

        public void AgregarCategoria(Categoria categoria)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    var query = "INSERT INTO Categorias (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                System.Console.WriteLine("Error al agregar categoría: " + ex.Message);
            }
        }

        public void EditarCategoria(Categoria categoria)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    var query = "UPDATE Categorias SET Nombre = @Nombre, Descripcion = @Descripcion WHERE Id = @Id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
                        command.Parameters.AddWithValue("@Id", categoria.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                System.Console.WriteLine("Error al editar categoría: " + ex.Message);
            }
        }

        public void EliminarCategoria(int categoriaId)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    var query = "DELETE FROM Categorias WHERE Id = @Id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", categoriaId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                System.Console.WriteLine("Error al eliminar categoría: " + ex.Message);
            }
        }
    }
}