namespace InventarioApp.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int CategoriaId { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public int ProveedorId { get; set; }
    }
}
