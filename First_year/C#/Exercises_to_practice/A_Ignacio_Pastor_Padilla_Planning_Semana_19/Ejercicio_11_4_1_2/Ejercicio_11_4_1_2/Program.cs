using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

//(11.4.1.2) Crea un programa que lea el contenido de un fichero de texto, lo almacene línea por línea en un ArrayList,
// y luego pregunte de forma repetitiva al usuario qué texto desea buscar y muestre las líneas que contienen ese texto.
//Terminará cuando el usuario introduzca una cadena vacía.
namespace Ejercicio_11_4_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir;
            bool textoEncontrado;
            int posicion, inicio, contador, lineas = 0;
            string linea;
            string textoBuscar;
            StreamReader fichero = File.OpenText("Ejercicio_11_4_1_2.txt");
            ArrayList miLista = new ArrayList();

            do
            {
                linea = fichero.ReadLine();
                if(linea != null)
                {
                    miLista.Add(linea);
                    lineas++;
                }
            }
            while (linea != null);
            Console.WriteLine("Contador de lineas guardadas = {0} (debería valer 5)", lineas);
            do
            {
                salir = false;
                textoEncontrado = false;
                inicio = 0;
                contador = miLista.Count;
                Console.WriteLine("Introduce el texto que quieres buscar");
                textoBuscar = Console.ReadLine();
                if (textoBuscar != "")
                {
                    Console.WriteLine("Entra en el if");
                    do
                    {
                        Console.WriteLine("Entra en el el do/while");
                        posicion = miLista.IndexOf(textoBuscar, inicio);
                        Console.WriteLine("Posición vale {0}", posicion);
                        if (posicion >= 0)
                        {
                            Console.WriteLine("El texto se encuentra en la posición {0}", posicion);
                            Console.WriteLine("\" {0} \"", (string)miLista[posicion]);
                            inicio = posicion + 1;
                            textoEncontrado = true;
                        }
                        else
                            salir = true;
                    }
                    while (inicio < contador && salir == false);
                        if (textoEncontrado == false)
                        Console.WriteLine("No se han encontrado resultados");
                }
            }
            while (textoBuscar != "");
        }
    }
}
