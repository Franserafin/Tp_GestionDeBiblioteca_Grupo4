using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{
    public class Cancion
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public int duracionsegundos { get; set; }

        public int ArtistaId { get; set; }
        public Artista Artista { get; set; }

    }
}
