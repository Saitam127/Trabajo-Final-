using System.Collections.Generic;
using System.Data.SQLite;
using InventarioApp.Modelos;
using InventarioApp.Helpers;

namespace InventarioApp.Controladores
{
    public class ProveedorController
    {
        private DatabaseHelper dbHelper;

        public ProveedorController(DatabaseHelper helper)
        {
            dbHelper = helper;
        }

        public List<Proveedor> ObtenerProveedores()
        {
            var proveedores = new List<Proveedor>();

            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    var query = "SELECT * FROM Proveedores";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var proveedor = new Proveedor
                                {
                                    Id = reader.GetInt32(0),
                                    NombreEmpresa = reader.GetString(1),
                                    Contacto = reader.GetString(2),
                                    Direccion = reader.GetString(3),
                                    Telefono = reader.GetString(4)
                                };
                                proveedores.Add(proveedor);
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                System.Console.WriteLine("Error al obtener proveedores: " + ex.Message);
            }

            return proveedores;
        }

        public void AgregarProveedor(Proveedor proveedor)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    var query = "INSERT INTO Proveedores (NombreEmpresa, Contacto, Direccion, Telefono) VALUES (@NombreEmpresa, @Contacto, @Direccion, @Telefono)";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreEmpresa", proveedor.NombreEmpresa);
                        command.Parameters.AddWithValue("@Contacto", proveedor.Contacto);
                        command.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                        command.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                System.Console.WriteLine("Error al agregar proveedor: " + ex.Message);
            }
        }

        public void EditarProveedor(Proveedor proveedor)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    var query = "UPDATE Proveedores SET NombreEmpresa = @NombreEmpresa, Contacto = @Contacto, Direccion = @Direccion, Telefono = @Telefono WHERE Id = @Id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreEmpresa", proveedor.NombreEmpresa);
                        command.Parameters.AddWithValue("@Contacto", proveedor.Contacto);
                        command.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                        command.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                        command.Parameters.AddWithValue("@Id", proveedor.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                System.Console.WriteLine("Error al editar proveedor: " + ex.Message);
            }
        }

        public void EliminarProveedor(int proveedorId)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    var query = "DELETE FROM Proveedores WHERE Id = @Id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", proveedorId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                System.Console.WriteLine("Error al eliminar proveedor: " + ex.Message);
            }
        }
    }
}