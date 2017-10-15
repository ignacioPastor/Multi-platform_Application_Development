using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

//(11.8.2) Crea un programa que lea todo el contenido de un fichero, lo guarde en una lista de strings
// y luego lo muestre en orden inverso (de la última línea a la primera).
namespace Ejercicio_11_8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fichero = File.OpenText("Ejercicio_11_8_2.txt");
            List<string> miLista = new List<string>();
            string linea;

            do
            {
                linea = fichero.ReadLine();
                if(linea != null)
                    miLista.Add(linea);
            }
            while (linea != null);

            for (int i = miLista.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(miLista[i]);
            }

            fichero.Close();
        }
    }
}
