using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSolid
{
    public class GestorPrestamos
    {
        private readonly ICalculadoraMulta _calculadoraMulta;
        private readonly INotificador _notificador;
        private readonly List<Prestamo> _prestamos;

        public GestorPrestamos(ICalculadoraMulta calculadoraMulta, INotificador notificador)
        {
            _calculadoraMulta = calculadoraMulta;
            _notificador = notificador;
            _prestamos = new List<Prestamo>();
        }

        public Prestamo RealizarPrestamo(Libro libro, Usuario usuario)
        {
            if (!libro.Disponible)
            {
                Console.WriteLine($"El libro '{libro.Titulo}' no está disponible");
                return null;
            }

            libro.Disponible = false;
            var prestamo = new Prestamo(libro, usuario);
            _prestamos.Add(prestamo);

            string mensaje = $"Has prestado '{libro.Titulo}'. Fecha de devolución: {prestamo.FechaDevolucion:yyyy-MM-dd}";
            _notificador.Enviar(mensaje, usuario.Nombre);

            Console.WriteLine($"Préstamo realizado: '{libro.Titulo}' para {usuario.Nombre}");
            return prestamo;
        }

        public void DevolverLibro(Prestamo prestamo)
        {
            if (prestamo.Devuelto)
            {
                Console.WriteLine("Este libro ya fue devuelto");
                return;
            }

            DateTime fechaActual = DateTime.Now;
            if (fechaActual > prestamo.FechaDevolucion)
            {
                int diasRetraso = (fechaActual - prestamo.FechaDevolucion).Days;
                decimal multa = _calculadoraMulta.Calcular(diasRetraso);
                Console.WriteLine($"Retraso de {diasRetraso} días. Multa: ${multa:F2}");
            }
            else
            {
                Console.WriteLine("Libro devuelto a tiempo");
            }

            prestamo.Devuelto = true;
            prestamo.Libro.Disponible = true;
            Console.WriteLine($"'{prestamo.Libro.Titulo}' devuelto por {prestamo.Usuario.Nombre}");
        }
    }
}
