using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSolid
{
    public class Usuario
    {
        public string Nombre { get; }
        public string IdUsuario { get; }

        public Usuario(string nombre, string idUsuario)
        {
            Nombre = nombre;
            IdUsuario = idUsuario;
        }
    }
}
