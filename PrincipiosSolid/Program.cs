namespace PrincipiosSolid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SISTEMA DE BIBLIOTECA - PRINCIPIOS SOLID");
            Console.WriteLine(new string('=', 50));

            // Crear libros
            var libro1 = new Libro("1984", "George Orwell", "978-0-452-28423-4");
            var libro2 = new Libro("Cien años de soledad", "Gabriel García Márquez", "978-84-376-0494-7");

            // Crear usuarios
            var usuario1 = new Usuario("Ana García", "U001");
            var usuario2 = new Usuario("Carlos López", "U002");

            // Crear diferentes gestores con distintas configuraciones
            Console.WriteLine("\nGESTOR PARA USUARIOS REGULARES:");
            var gestorRegular = new GestorPrestamos(new MultaEstandar(), new NotificadorEmail());

            Console.WriteLine("\nGESTOR PARA ESTUDIANTES:");
            var gestorEstudiante = new GestorPrestamos(new MultaEstudiante(), new NotificadorSMS());

            // Realizar préstamos
            Console.WriteLine("\nREALIZANDO PRÉSTAMOS:");
            var prestamo1 = gestorRegular.RealizarPrestamo(libro1, usuario1);
            var prestamo2 = gestorEstudiante.RealizarPrestamo(libro2, usuario2);

            // Simular devolución tardía
            Console.WriteLine("\nSIMULANDO DEVOLUCIÓN TARDÍA:");
            if (prestamo1 != null)
            {
                prestamo1.FechaDevolucion = DateTime.Now.AddDays(-3);
                gestorRegular.DevolverLibro(prestamo1);
            }

            // Devolución a tiempo
            Console.WriteLine("\nDEVOLUCIÓN A TIEMPO:");
            if (prestamo2 != null)
            {
                gestorEstudiante.DevolverLibro(prestamo2);
            }
        }
    }
}
