using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSolid
{
    public class Prestamo
    {
        public Libro Libro { get; }
        public Usuario Usuario { get; }
        public DateTime FechaPrestamo { get; }
        public DateTime FechaDevolucion { get; set; }
        public bool Devuelto { get; set; }

        public Prestamo(Libro libro, Usuario usuario)
        {
            Libro = libro;
            Usuario = usuario;
            FechaPrestamo = DateTime.Now;
            FechaDevolucion = DateTime.Now.AddDays(14);
            Devuelto = false;
        }
    }
}
