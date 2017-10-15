using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ejercicio_enumeradores
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable miDiccionario = new Hashtable();

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


            IDictionaryEnumerator miEnumerador = miDiccionario.GetEnumerator();

            while (miEnumerador.MoveNext() == true)
                Console.WriteLine("{0} = {1}", miEnumerador.Key, miEnumerador.Value);

        }
    }
}
