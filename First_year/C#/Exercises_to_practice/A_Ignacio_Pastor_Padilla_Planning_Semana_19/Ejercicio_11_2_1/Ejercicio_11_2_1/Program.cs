using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ejercicio_11_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero, contador;
            Stack miPila = new Stack();
            Console.WriteLine("Introduce 5 números enteros (de uno en uno");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Introduce un número entero");
                numero = Convert.ToInt32(Console.ReadLine());
                miPila.Push(numero);
            }
            Console.WriteLine();
            Console.WriteLine("Los datos que has introducido, mostrados de forma inversa son:");
            contador = miPila.Count;
            for (int i = 0; i < contador; i++)
            {
                numero = (int) miPila.Pop();
                Console.Write(numero + " ");
            }
            Console.WriteLine();
            
            

        }
    }
}
