namespace AccesoDatos.Models
{
    public class Alquiler
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public bool Devuelto { get; set; }

        public Libro Libro { get; set; } = null!;
        public Cliente Cliente { get; set; } = null!;
    }
}
