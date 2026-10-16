using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{

    public class Alquiler
    {
        public int IdAlquiler { get; set; }

        public DateTime FechaRetiro { get; set; }
        public DateTime FechaLimiteDevolucion { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }

        public decimal MontoReserva { get; set; }
        public decimal Penalizacion { get; set; } 

        public int IdLibro { get; set; }
        public Libro? Libro { get; set; }
       
        public int IdCliente { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
