using System.Data.SQLite;

namespace InventarioApp.Helpers
{
    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper(string dbFilePath)
        {
            connectionString = $"Data Source={dbFilePath};Version=3;";
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        public void CreateTables()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string productosTable = @"
                    CREATE TABLE IF NOT EXISTS Productos (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nombre TEXT NOT NULL,
                        Codigo TEXT NOT NULL,
                        CategoriaId INTEGER,
                        Precio REAL,
                        Existencia INTEGER,
                        ProveedorId INTEGER
                    );";

                string categoriasTable = @"
                    CREATE TABLE IF NOT EXISTS Categorias (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nombre TEXT NOT NULL,
                        Descripcion TEXT
                    );";

                string proveedoresTable = @"
                    CREATE TABLE IF NOT EXISTS Proveedores (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        NombreEmpresa TEXT NOT NULL,
                        Contacto TEXT NOT NULL,
                        Direccion TEXT NOT NULL,
                        Telefono TEXT NOT NULL
                    );";

                using (var command = new SQLiteCommand(productosTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(categoriasTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(proveedoresTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}