using System;
using System.Collections.Generic;

namespace GestorEstudiantes
{
    class Program
    {
        static List<Estudiante> estudiantes = new List<Estudiante>();
        static int contadorId = 1;

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("===== GESTOR DE ESTUDIANTES =====");
                Console.WriteLine("1. Agregar Estudiante");
                Console.WriteLine("2. Listar Estudiantes");
                Console.WriteLine("3. Editar Estudiante");
                Console.WriteLine("4. Eliminar Estudiante");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida. Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        AgregarEstudiante();
                        break;
                    case 2:
                        ListarEstudiantes();
                        break;
                    case 3:
                        EditarEstudiante();
                        break;
                    case 4:
                        EliminarEstudiante();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 5);
        }

        static void AgregarEstudiante()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Edad: ");
            if (!int.TryParse(Console.ReadLine(), out int edad))
            {
                Console.WriteLine("Edad inválida.");
                return;
            }

            estudiantes.Add(new Estudiante
            {
                Id = contadorId++,
                Nombre = nombre,
                Edad = edad
            });

            Console.WriteLine("Estudiante agregado con éxito.");
        }

        static void ListarEstudiantes()
        {
            Console.WriteLine("=== LISTA DE ESTUDIANTES ===");
            if (estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            foreach (var est in estudiantes)
            {
                Console.WriteLine($"ID: {est.Id} | Nombre: {est.Nombre} | Edad: {est.Edad}");
            }
        }

        static void EditarEstudiante()
        {
            Console.Write("Ingrese el ID del estudiante a editar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var est = estudiantes.Find(e => e.Id == id);
            if (est == null)
            {
                Console.WriteLine("Estudiante no encontrado.");
                return;
            }

            Console.Write("Nuevo nombre: ");
            est.Nombre = Console.ReadLine();

            Console.Write("Nueva edad: ");
            if (!int.TryParse(Console.ReadLine(), out int edad))
            {
                Console.WriteLine("Edad inválida.");
                return;
            }
            est.Edad = edad;

            Console.WriteLine("Estudiante editado con éxito.");
        }

        static void EliminarEstudiante()
        {
            Console.Write("Ingrese el ID del estudiante a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var est = estudiantes.Find(e => e.Id == id);
            if (est == null)
            {
                Console.WriteLine("Estudiante no encontrado.");
                return;
            }

            estudiantes.Remove(est);
            Console.WriteLine("Estudiante eliminado con éxito.");
        }
    }

    class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}
