using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

//(11.4.2.1) Crea un programa que, cuando el usuario introduzca el nombre de un número del 1 al 10 en inglés
// (por ejemplo, "two"), diga su traducción en español(por ejemplo, "dos").

namespace Ejercicio_11_4_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto;
            SortedList miDiccionario = new SortedList();

            miDiccionario.Add("one", "uno");
            miDiccionario.Add("two", "dos");
            miDiccionario.Add("three", "tres");
            miDiccionario.Add("four", "cuatro");
            miDiccionario.Add("five", "cinco");
            miDiccionario.Add("six", "seis");
            miDiccionario.Add("seven", "siete");
            miDiccionario.Add("eight", "ocho");
            miDiccionario.Add("nine", "nueve");
            miDiccionario.Add("ten", "diez");

            do
            {
                Console.WriteLine("Escribe un número del 1 al 10 en inglés (teclea \"salir\" para salir del programa");
                texto = Console.ReadLine();
                if (texto != "salir")
                {
                    try
                    {
                        // Console.WriteLine("{0}", miDiccionario[texto]);
                        Console.WriteLine("{0}", miDiccionario.GetByIndex(miDiccionario.IndexOfKey(texto)));
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Ha habido un error: {0}", e.Message);
                    }
                }
            }
            while (texto != "salir");
        }
    }
}
