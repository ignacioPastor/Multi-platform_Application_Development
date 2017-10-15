using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

//Ignacio Pastor Padilla - Ejercicio 2 - Practica Memoria Dinámica - Tema 11 - Programación - DAM Semi Grupo A

//En este ejercicio vamos a leer una serie de mensajes de un fichero y almacenarlos en una cola.
//Después el usuario elegirá si quiere ir viéndo los mensajes o añadiendo nuevos.
//Finalmente guardaremos los mensajes que queden por leer en el fichero.

namespace MD_E2
{
    class Program
    {
        static void Main(string[] args)
        {
            char opcion;//Elegir opción en el menú será mediante un caracter
            string linea;
            Queue miCola = new Queue();//Creamos la cola que utilizaremos para almacenar y gestionar los mensajes

            if (File.Exists("mensajes.txt"))//Antes de abrir el archivo, comprobamos que existe. En el caso de que el archivo no exista
            {                               //pasaremos directamente a la cola, no habrán mensajes que mostrar pero podrán añadirse
                StreamReader fichero = File.OpenText("mensajes.txt");//Abrimos el fichero
                do//Cargamos los mensajes del fichero en la cola
                {
                    linea = fichero.ReadLine();
                    if (linea != null)//Cuando acaben las líneas de mensaje, al tratar de leer la siguiente recibirá null
                        miCola.Enqueue(linea);
                }
                while (linea != null);//Cuando llegue a la primera línea del fichero vacía, salimos del bucle
                fichero.Close();//Cerramos el fichero
            }
            else
                Console.WriteLine("No se ha podido encontrar el archivo desde el que cargar los mensajes");

            do//Mostramos el menú de opciones al usuario
            {      
                Console.WriteLine("Indica qué es lo que quieres hacer:");
                Console.WriteLine("S. Leer el siguiente mensaje.");
                Console.WriteLine("N. Nuevo mensaje.");
                Console.WriteLine("Q. Salir del programa.");
                try
                {
                    opcion = Convert.ToChar(Console.ReadLine());
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Ha habido un error: {0}", e.Message);
                    opcion = 'z';
                }
                Console.WriteLine();

                switch (opcion)
                {
                    case 'S'://Leer el siguiente mensaje
                        if (miCola.Count > 0)
                            Console.WriteLine("{0}", miCola.Dequeue());
                        else
                            Console.WriteLine("No hay mensajes pendientes");//Si la cola está vacía
                        Console.WriteLine();
                        break;
                    case 's'://Controlamos que el programa funcione tanto si indica la opción tanto en mayúscula como en minúscula
                        goto case 'S';
                    case 'N'://Añadir un nuevo mensaje
                        Console.WriteLine("Introduce el texto del nuevo mensaje");
                        linea = Console.ReadLine();
                        if (linea != "")
                            miCola.Enqueue(linea);
                        Console.WriteLine();
                        break;
                    case 'n':
                        goto case 'N';
                    case 'Q'://Salir del programa
                        Console.WriteLine("Guardando mensajes pendientes de leer en el fichero...");
                        StreamWriter ficheroEscritura = File.CreateText("mensajes.txt");

                        while (miCola.Count > 0)
                            ficheroEscritura.WriteLine(miCola.Dequeue());//Guardamos los mensajes que quedan en la cola en el fichero

                        ficheroEscritura.Close();//Cerramos fichero
                        Console.WriteLine("Fin del programa");
                        break;
                    case 'q':
                        goto case 'Q';
                    default:
                        Console.WriteLine("No es una opción válida");
                        break;
                }
            }
            while (opcion != 'Q' && opcion != 'q');   
        }
    }
}
