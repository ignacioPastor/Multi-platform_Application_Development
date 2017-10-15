using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

// (11.3.3) Crea un programa que lea el contenido de un fichero de texto, lo almacene línea por línea en una cola,
// luego muestre este contenido en pantalla y finalmente lo vuelque a otro fichero de texto.
namespace Ejercicio_11_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string linea;
            StreamReader fichero = File.OpenText("Ejercicio_11_3_3.txt");
            Queue miCola = new Queue();

            do
            {
                linea = fichero.ReadLine();
                if(linea != null)
                {
                    miCola.Enqueue(linea);
                }
            }
            while (linea != null);
            fichero.Close();
            StreamWriter volcadoFichero = File.AppendText("Volcado_Ejercicio_11_3_3.txt");

            while(miCola.Count > 0)
            volcadoFichero.WriteLine(miCola.Dequeue());
            volcadoFichero.Close();
        }
    }
}
