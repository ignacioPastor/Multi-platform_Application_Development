using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ignacio Pastor Padilla - Ejercicio 4, Práctica Tema 13 - 1º DAM Semipresencial Grupo-A

//Crear una agenda que registre los nombres, teléfonos, y fechas de nacimiento de los amigos.
//Y que además nos informe de los días que quedan para sus cumpleaños.

namespace T1213_E4
{
    class Program
    {
        static void Main(string[] args)
        {
            Amigo a;
            bool salir = false;
            List<Amigo> listaAmigos = new List<Amigo>(); // Almacenaremos los amigos en una lista genérica
            bool ok;

            Console.WriteLine("Introduce los datos de tus amigos");
            Console.WriteLine();
            do  // do/while para ir añadiendo amigos hasta que el usuario introduzca una cadena vacía en el nombre
            {
                a = new Amigo();
                Console.Write("Amigo {0}: ", listaAmigos.Count + 1);
                Console.Write("Nombre: ");
                a.Nombre = Console.ReadLine();
                //Console.WriteLine();
                if (a.Nombre == "")
                    salir = true;
                else
                {
                    Console.Write("Telefono: ");
                    a.Telefono = Console.ReadLine();
                    //Console.WriteLine();
                    do
                    {
                        try // Controlamos que el formato de fecha que se introduce es válido. Si no es así, lo pediremos reiterativamente
                        {
                            ok = true;
                            Console.Write("Introduce la fecha de nacimiento en formato dd/mm/aaaa: ");
                            a.FechaNacimiento = Convert.ToDateTime(Console.ReadLine());
                           // Console.WriteLine();
                        }
                        catch (Exception)
                        {
                            ok = false;
                            Console.WriteLine("No es un formato de fecha válido");
                        }
                    }
                    while (ok == false);

                    listaAmigos.Add(a); // Una vez completados todos los datos del amigo, lo añadimos a la lista
                }
            }
            while (salir == false);

            Console.WriteLine("Fin de la introducción de amigos.");
            Console.WriteLine();
            Console.WriteLine("Listado de datos completo:");
            foreach(Amigo amiguete in listaAmigos) // Imprimimos los datos de los amigos con un foreach
            {
                Console.Write("{0}. {1}. Nació el {2}. Faltan {3} días para su próximo cumpleaños.",
                        amiguete.Nombre, amiguete.Telefono, amiguete.FechaNacimiento.ToShortDateString(), amiguete.DiasCumple);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
