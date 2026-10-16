using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }

        public ICollection<Alquiler> Alquileres { get; set; } = new List<Alquiler>();
    }
}
