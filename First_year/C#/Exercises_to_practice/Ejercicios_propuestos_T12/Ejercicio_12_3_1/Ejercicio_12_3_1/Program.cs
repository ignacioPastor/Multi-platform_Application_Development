using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
(12.3.1) Crea un programa que muestre en pantalla el contenido de un fichero de texto,
cuyo nombre escoja el usuario. Si el usuario no sabe el nombre, podrá pulsar "Intro" y
se le mostrará la lista de ficheros existentes en el directorio actual ,
para luego volver a preguntarle el nombre del fichero.
    */
namespace Ejercicio_12_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fichero;
            string nombreFichero;
            string linea;
            string[] listaFicheros;
            bool salir = false;

            do
            {
                Console.WriteLine("Itroduce el nombre del fichero que quieres abrir");
                Console.WriteLine("Pulsa Intro para mostrar los archivos del directorio actual");
                Console.WriteLine("Introduce 0 para salir del programa");
                nombreFichero = Console.ReadLine();
                if (nombreFichero == "")
                {
                    listaFicheros = Directory.GetFiles(".");
                    Console.WriteLine("Listado de archivos en el directorio actual");
                    foreach (string aFichero in listaFicheros)
                        Console.WriteLine(aFichero);
                    Console.WriteLine("Pulsa cualquier tecla para volver al programa.");
                    Console.ReadLine();
                }
                else if(nombreFichero =="0")
                {
                    salir = true;
                }
                else
                {
                    if (File.Exists(nombreFichero))
                    {
                        fichero = File.OpenText(nombreFichero);
                        do
                        {
                            linea = fichero.ReadLine();
                            if (linea != null)
                                Console.WriteLine(linea);
                        }
                        while (linea != null);
                        fichero.Close();
                        salir = true;
                    }
                    else
                        Console.WriteLine("No se ha encontrado el archivo indicado");
                }
            }
            while (salir == false);
        }
    }
}
