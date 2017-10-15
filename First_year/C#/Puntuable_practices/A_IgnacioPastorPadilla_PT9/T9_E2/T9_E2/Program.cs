using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - Practica Programación Tema 9 - 1º DAM Semi, Grupo A

/*
Un programa principal que cargará un catálogo de libros . Después, cargará
la lista de peticiones de un archivo peticiones.dat . Después, pedirá al usuario con un menú si quiere añadir o quitar
peticiones de la lista, y al finalizar guardará la lista de peticiones en el mismo archivo peticiones.dat
*/

namespace T9_E2
{
    class Program
    {

        public static void MostraMenu() // Muestra el menú de opciones disponibles
        {
            Console.WriteLine();
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Dar de alta una nueva petición.");
            Console.WriteLine("2. Quitar una petición de la lista.");
            Console.WriteLine("3. Mostrar la lista de peticiones.");
            Console.WriteLine("4. Mostrar catálogo.");
            Console.WriteLine("0. Salir.");
        }

        public static bool MostrarPeticiones(List<Peticion> listaPeti) // Muestra el listado de Peticiones
        {
            if (listaPeti.Count == 0) // Si la lista está vacía indica que no hay peticiones que mostrar
            {
                Console.WriteLine("No hay peticiones que mostrar.");
                return false;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Listado de Peticiones:");
                for (int i = 0; i < listaPeti.Count; i++)
                {
                    Console.WriteLine("{0}. Fecha de inicio: {1}; Fecha de finalización: {2}; Libro pedido: {3}.",
                        i + 1, listaPeti[i].FechaInicio.ToShortDateString(), listaPeti[i].FechaFin.ToShortDateString(), listaPeti[i].LibroPedido.Titulo);
                }
                Console.WriteLine();
                return true;
            }
        }
        static void Main(string[] args)
        {
            const string NOMBRE_PETICIONES = "peticiones.dat"; // Constante que almacena el nombre del archivo sobre el que trabajaremos con las peticiones
            string opcion;
            bool salir = false;
            int opcionLibro;
            int opcionPeticion;

            Peticion p = new Peticion();
            List<Peticion> listaPeticiones;
            Serializador s = new Serializador(NOMBRE_PETICIONES);


            p.CargarCatalogoPet(); // Cargamos el catálogo

            if (File.Exists(NOMBRE_PETICIONES)) // Si no existe un fichero de peticiones creamos una lista vacía (el fichero lo crearemos al ir a guardar la lista antes de salir)
            {
                try
                {
                    listaPeticiones = s.CargarPeticiones();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Ha habido un error: {0}", e.Message);
                    Console.WriteLine("Se creará una lista de peticiones vacía...");
                    listaPeticiones = new List<Peticion>();
                }
            }
            else
                listaPeticiones = new List<Peticion>();

            do // bucle do/while para gestionar el menú de opciones
            {
                MostraMenu();
                opcion = Console.ReadLine(); // No hay que tener precauciones especiales porque es un string

                switch (opcion) // Gestionamos el menú de opciones con un swicth
                {
                    case "1": // Añadir petición
                        p.MostrarCatalogo(); // Mostramos el Catálogo
                        Peticion pe = new Peticion(); // Creamos un objeto que será el que añadiremos a la lista de peticniones
                        Console.WriteLine("Elige el libro que quieres pedir");
                        try
                        {
                            opcionLibro = Convert.ToInt32(Console.ReadLine()); // Controlamos que se introduzca un entero
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Ha habido un error: {0}", e.Message); // Si no se introduce entero, capturamos el error y volvemos al menú.
                            break;
                        }
                        if (opcionLibro < 1 || opcionLibro > p.Catalogo.Count) // Controlamos que eliga una opción de las disponibles en el catálogo
                        {
                            Console.WriteLine("Debes elegir un libro del catálogo."); 
                            break;
                        }
                        pe.LibroPedido = p.LibroElegido(opcionLibro - 1); // Enviamos a la clase Petición la posición del libro elegido, y traemos el libro en cuestión.
                        Console.WriteLine("Has pedido el libro \"{0}\"", pe.LibroPedido.Titulo);
                        pe.FechaInicio = DateTime.Today; // La fecha de inicio será la de hoy. Utilizamos Today en lugar de Now porque la hora no resulta significativa para una biblioteca
                        Console.WriteLine("La petición comienza a día de hoy, {0}. Tienes 15 días para devolver el libro", pe.FechaInicio.ToShortDateString());
                        pe.FechaFin = pe.FechaInicio.AddDays(15); // Asignamos una fecha de fin de 15 días más tarde que la fecha de inicio. Plazo habitual en los préstamos.
                        Console.WriteLine("La fecha de devolución es el día {0}", pe.FechaFin.ToShortDateString()); // Mostramos los DateTime pasándolos a shortString para no mostrar la hora
                        listaPeticiones.Add(pe); // Áñadimos finalmente el objeto a la lista.
                        break;

                    case "2": // Quitar petición
                        if (MostrarPeticiones(listaPeticiones) == false) // Si la lista está vacía, se avisa en el método de que no hay nada que mostrar, y volvemos al menú.
                            break;
                        Console.WriteLine("Indica la petición que quieres eliminar"); // En caso de haber peticiones, las mostramos y preguntamos cuál quiere eliminar.
                        try
                        {
                            opcionPeticion = Convert.ToInt32(Console.ReadLine()); // Controlamos que introduzca un entero.
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Ha habido un error: {0}", e.Message); // Caso de que no se introduzca un entero, volvemos al menú.
                            break;
                        }
                        if (opcionPeticion < 1 || opcionPeticion > listaPeticiones.Count) // Controlamos que se elija una petición del listado. Caso negativo volvemos al menú.
                        {
                            Console.WriteLine("Debes elegir una petición del listado.");
                            break;
                        }
                        listaPeticiones.RemoveAt(opcionPeticion - 1); // Eliminamos la petición indicada de la lista de peticiones.
                        Console.WriteLine("Se ha borrado la petición.");
                        break;

                    case "3": // Mostrar lista
                        MostrarPeticiones(listaPeticiones);

                        break;

                    case "4": // Mostrar catálogo
                        p.MostrarCatalogo();
                        break;

                    case "0": // Salir del programa
                        Console.WriteLine("Guardando cambios realizadados...");
                        s.GuardarPeticiones(listaPeticiones); // Guardamos la lista de peticiones en un fichero antes de salir.
                        Console.WriteLine("Los cambios se han guardado correctamente.");
                        salir = true;
                        break;

                    default: // Caso de que se introduzca una instrucción o valor diferente a los esperados, informamos de que no es una opción válida.
                        Console.WriteLine("No es una opción válida");
                        break;
                }
            }
            while (salir == false);
        }
    }
}
