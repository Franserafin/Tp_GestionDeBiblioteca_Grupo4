using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{

    public class Artista
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        List<Cancion> canciones=new List<Cancion>();
    }
}
