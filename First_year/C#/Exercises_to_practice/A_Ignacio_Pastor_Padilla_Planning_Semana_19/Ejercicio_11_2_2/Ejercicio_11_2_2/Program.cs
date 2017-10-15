using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Ejercicio_11_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack miPila = new Stack();
            StreamReader fichero;
            string nombreFichero, linea;
            int contador;

            Console.WriteLine("Introduce el nombre de un fichero");
            nombreFichero = Console.ReadLine();

            if (File.Exists(nombreFichero))
            {
                fichero = File.OpenText(nombreFichero);

                do
                {
                    linea = fichero.ReadLine();
                    if (linea != null)
                        miPila.Push(linea);
                }
                while (linea != null);
            }
            contador = miPila.Count;
            for (int i = 0; i < contador; i++)
            {
                linea = (string) miPila.Pop();
                Console.WriteLine(linea);
            }
        }
    }
}
