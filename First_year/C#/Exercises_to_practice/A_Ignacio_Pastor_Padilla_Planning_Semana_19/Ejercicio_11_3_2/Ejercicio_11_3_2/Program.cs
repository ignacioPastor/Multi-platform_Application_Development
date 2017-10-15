using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ejercicio_11_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string frase;
            Queue miCola = new Queue();
            do
            {
                Console.WriteLine("Introduce una frase");
                frase = Console.ReadLine();
                if(frase != "")
                    miCola.Enqueue(frase);
            }
            while (frase != "");

            while (miCola.Count > 0)
                Console.WriteLine(miCola.Dequeue());
        }
    }
}
