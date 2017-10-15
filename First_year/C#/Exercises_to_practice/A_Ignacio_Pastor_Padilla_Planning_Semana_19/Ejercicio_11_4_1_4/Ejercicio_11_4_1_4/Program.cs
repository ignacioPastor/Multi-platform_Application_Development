using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

// (11.4.1.4) Crea un programa que lea el contenido de un fichero de texto, lo almacene línea por línea en un ArrayList,
// luego muestre en pantalla las líneas impares (primera, tercera, etc.) y finalmente vuelque a otro fichero de texto
// las líneas pares (segunda, cuarta, etc.).
namespace Ejercicio_11_4_1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string linea;
            int contador;
            StreamReader fichero = File.OpenText("Ejercicio_11_4_1_4.txt");
            StreamWriter volcadoFichero = File.CreateText("Volcado_Ejercicio_11_4_1_4.txt");
            ArrayList miLista = new ArrayList();

            do
            {
                linea = fichero.ReadLine();
                if(linea != null)
                {
                    miLista.Add(linea);
                }
            }
            while (linea != null);

            for (int i = 0; i < miLista.Count; i++)
            {
                if (i == 0 || i % 2 == 0)
                    Console.WriteLine(miLista[i]);
                else
                    volcadoFichero.WriteLine(miLista[i]);
            }

            fichero.Close();
            volcadoFichero.Close();
        }
    }
}
