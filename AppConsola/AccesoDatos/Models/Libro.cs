using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Estado { get; set; } = "Disponible";

        public int IdCategoria { get; set; }
        public Categoria? Categoria { get; set; }

        public ICollection<Alquiler> Alquileres { get; set; } = new List<Alquiler>();

    }
}
