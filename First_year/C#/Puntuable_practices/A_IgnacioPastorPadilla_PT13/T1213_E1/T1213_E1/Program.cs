using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ignacio Pastor Padilla - Ejercicio 1, Práctica Tema 13 - 1º DAM Semipresencial Grupo-A

    //Se nos pide un programa que liste ficheros del tipo indicado por el usuario, de la carpeta y subcarpeta indicadas por el usuario.
    //Se imprimirán ordenados por nombre. Y se dará la opción de mostrarlos también ordenados por tamaño y fecha.

namespace T1213_E1
{
    class Program
    {
        enum ordenar { NOMBRE, TAMANYO, FECHA }; //Enumerador para gestionar el orden

        static void Main(string[] args)
        {
            List<Archivo> listaArchivos = new List<Archivo>();
            string nombre;
            string tipo;
            Archivo a;
            int opcion;
            bool salir = false;
            string espacios = "        ";
            
            //Pedimos el nombre del directorio y el tipo de archivos
            Console.WriteLine("Indica un nombre de carpeta (por ejemplo \"C:\\datos\")");
            nombre = Console.ReadLine();
            Console.WriteLine("Indica una expresión del tipo (\"*.bmp\" o \"A?.temp\")");
            tipo = Console.ReadLine();
            //Constrolamos los posibles errores que nos salten, caso de error cerramos programa
            try
            {
                string[] listaFicheros = Directory.GetFiles(nombre, tipo, SearchOption.AllDirectories); //Metemos los ficheros que cumplen requisitos en array 
            
                // Sacamos la información del fichero, y almacenamos los datos en un objeto Archivo que metemos en una Lista
                FileInfo fich;
                foreach (string fichero in listaFicheros)
                {
                    fich = new FileInfo(fichero);
                    a = new Archivo();
                    a.Nombre = fich.FullName;
                    a.Tamanyo = fich.Length;
                    a.Fecha = fich.CreationTime;
                    listaArchivos.Add(a);
                }
                opcion = 1;
                do // do/while para mostrar al usuario los ficheros seleccionados en el orden que él prefiera
                {
                    opcion--;
                    switch (opcion)
                    {
                        case (int)ordenar.NOMBRE:
                            var ordNombre =// Utilizamos LINQ para ordenar la lista.
                                from item in listaArchivos
                                orderby item.Nombre
                                select item;
                        
                            foreach (var i in ordNombre)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(i.Nombre + espacios);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(i.Tamanyo + espacios);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine(i.Fecha.ToShortDateString() + espacios);
                            }
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine("ORDERNAR : 1.NOMBRE  2.TAMAÑO  3.FECHA  0.SALIR");
                            opcion = Convert.ToInt32(Console.ReadLine());
                            break;

                        case (int)ordenar.TAMANYO:
                            var ordTam =
                                from item in listaArchivos
                                orderby item.Tamanyo
                                select item;
                        
                            foreach (var i in ordTam)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(i.Nombre + espacios);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(i.Tamanyo + espacios);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine(i.Fecha.ToShortDateString() + espacios);
                            }
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine("ORDERNAR : 1.NOMBRE  2.TAMAÑO  3.FECHA  0.SALIR");
                            opcion = Convert.ToInt32(Console.ReadLine());
                            break;

                        case (int)ordenar.FECHA:
                            var ordFe =
                                from item in listaArchivos
                                orderby item.Fecha
                                select item;
                            
                            foreach (var i in ordFe)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(i.Nombre + espacios);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(i.Tamanyo + espacios);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine(i.Fecha.ToShortDateString() + espacios);
                            }

                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine("ORDERNAR : 1.NOMBRE  2.TAMAÑO  3.FECHA  0.SALIR");
                            opcion = Convert.ToInt32(Console.ReadLine());
                            break;

                        case -1:
                            Console.WriteLine("Cerrando programa...");
                            salir = true;
                            break;

                        default:
                            Console.WriteLine("Opción no válida");
                            Console.WriteLine("Cerrando programa...");
                            salir = true;
                            break;
                        }
                }
                while (salir == false);
            }
            catch (Exception e) //Caso de que haya un error con la ruta de acceso o tipo de fichero, mostramos mensaje de error y salimos del programa
            {
                Console.WriteLine("Ha habido un error: " + e.Message);
                Console.WriteLine("Cerrando el programa...");
            }
        }
    }
}
