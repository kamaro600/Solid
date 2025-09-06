using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSolid
{
    public class NotificadorEmail : INotificador
    {
        public bool Enviar(string mensaje, string destinatario)
        {
            Console.WriteLine($"Email a {destinatario}: {mensaje}");
            return true;
        }
    }
}
