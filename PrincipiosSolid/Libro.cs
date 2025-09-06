using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSolid
{
    public class Libro
    {
        public string Titulo { get; }
        public string Autor { get; }
        public string ISBN { get; }
        public bool Disponible { get; set; }

        public Libro(string titulo, string autor, string isbn)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            Disponible = true;
        }
    }
}
