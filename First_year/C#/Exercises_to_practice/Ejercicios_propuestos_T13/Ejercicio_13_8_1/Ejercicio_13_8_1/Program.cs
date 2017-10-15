using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
(13.8.1) Crea un programa que pida al usuario varios números enteros, los guarde en una lista
y luego muestre todos los que sean positivos, ordenados, empleando LINQ.
*/

namespace Ejercicio_13_8_1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<int> listaEnteros = new List<int>();
            int numero;

            do
            {
                try
                {
                    Console.WriteLine("Introduce un número entero, \"1111\" para dejar de introducir números");
                    numero = Convert.ToInt16(Console.ReadLine());
                    if(numero != 1111)
                        listaEnteros.Add(numero);
                }
                catch(Exception)
                {
                    Console.WriteLine("No es un número entero");
                    numero = 1;
                }
            }
            while (numero != 1111);

            var ordenados =
                from n in listaEnteros
                orderby n
                where n > 0
                select n;

            foreach (var cosa in ordenados)
                Console.Write(cosa + " ");
            Console.WriteLine();
        }
    }
}
