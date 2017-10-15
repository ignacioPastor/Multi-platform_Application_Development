using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla  - Practica Programación Tema 9 - 1º DAM Semi, Grupo A

namespace T9_E1
{
    class Program
    {
        public static void Menu() // Menú de opciones disponibles para el usuario.
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Dar de alta un nuevo libro.");
            Console.WriteLine("2. Borrar un libro del listado.");
            Console.WriteLine("3. Mostrar listado de libros.");
            Console.WriteLine("0. Salir.");
        }
        public static void MostrarListado(List<Libro> lista) // Para mostrar el listado de libros
        {
            if (lista.Count == 0) // En caso de que la lista esté vacía, informamos de que no hay libros para mostrar. En caso contrario, los mostramos.
                Console.WriteLine("No hay libros para mostrar.");
            else
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    Console.WriteLine("{0}. ISBN: {1}; Título: {2}; Autor: {3}; Precio: {4}",
                        i + 1, lista[i].Isbn, lista[i].Titulo, lista[i].Autor, lista[i].Precio);
                }
            }
        }
        static void Main(string[] args)
        {
            const string NOMBRE = "libros.dat"; // Declaramos el nombre del archivo como una constante, así facilitaremos su uso, y no podremos variarlo durante su uso.
            Serializador s = new Serializador(NOMBRE); // Objeto serializador al que le pasamos directamente el nombre del archivo.
            List<Libro> listaLibros;
            Libro libro;

            bool salir = false;
            string opcion;
            int libroBorrar;

            if (File.Exists(NOMBRE)) // Si existe un fichero de libros, cargamos su contenido en la lista
                listaLibros = s.Cargar();
            else
                listaLibros = new List<Libro>(); // Caso de no existir ningún fichero crearemos una lista vacía, y el fichero lo crearemos al guardar antes de salir.

            do // do/while para gestionar el proceder del programa según las instrucciones del usuario.
            {
                Menu();
                opcion = Console.ReadLine(); // Como utilizamos un string para pedir la opción a elegir del usuario, no tenemos que tener precauciones respecto a los datos insertados

                switch(opcion)
                {
                    case "1": // Dar de alta un nuevo libro. Pedimos la información que iremos almacenando.
                        libro = new Libro();
                        Console.WriteLine("Introduce el ISBN del libro");
                        libro.Isbn = Console.ReadLine();
                        Console.WriteLine("Introduce el título del libro");
                        libro.Titulo = Console.ReadLine();
                        Console.WriteLine("Introduce el autor del libro");
                        libro.Autor = Console.ReadLine();
                        Console.WriteLine("Introduce el precio del libro");
                        try
                        {
                            libro.Precio = Convert.ToSingle(Console.ReadLine()); // Controlamos los posibles errores derivados de introducir un formato distinto al esperado.
                        }
                        catch(Exception e) // En caso de que se produzca un error, informamos del mismo al usuario, y volvemos al menú sin guardar el libro.
                        {
                            Console.WriteLine("Ha habido un error: " + e.Message);
                            Console.WriteLine("No se ha podido guardar el precio del libro");
                            break;
                        }
                        listaLibros.Add(libro); // Si todo ha ido bien, añadimos el libro a la lista.
                        break;

                    case "2": // Borrar un libro del listado.
                        MostrarListado(listaLibros); // Primero mostramos el contenido de la lista de libros.
                        Console.WriteLine("Indica el libro que quieres borrar");
                        try
                        {
                            libroBorrar = Convert.ToInt32(Console.ReadLine()); // Controlamos que la cadena introducida tenga el formato correcto.
                            listaLibros.RemoveAt(libroBorrar - 1); // Borramos el libro indicado por el usuario. Teniendo en cuenta que en realidad, ha indicado un número más
                            Console.WriteLine("Se ha borrado el libro"); // de la posición real en la lista de libros.
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Ha habido un error: " + e.Message); // Caso de error, informamos de él y no se borrará el libro.
                        }
                        break;

                    case "3": // Mostrar listado
                        MostrarListado(listaLibros);
                        break;

                    case "0": // Salir del programa. Salimos del programa. Antes de salir guardamos la lista en el fichero.
                        salir = true;
                        Console.WriteLine("Guardando las modificaciones...");
                        s.Guardar(listaLibros);
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default: // En caso de que se introduzca un valor distinto a los contemplados, informamos de que no es una opción válida.
                        Console.WriteLine("No es una opción válida.");
                        break;
                }
            }
            while (salir == false);
        }
    }
}
