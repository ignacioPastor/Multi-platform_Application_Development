using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
//Ignacio Pastor Padilla - Grupo A - Examen de Programacion, Ejercicio 3

namespace TraductorJerga
{
    class Program
    {
        static void Main(string[] args)
        {

            string linea;
            Hashtable diccionarioJerga = new Hashtable();
            string[] lineaPartida = new string[2];

            //Leemos el fichero de diccinario jerga y lo guardamos en una tabla Hash "diccionarioJerga"
            if (File.Exists("jerga.txt"))
            {
                StreamReader ficheroJerga = File.OpenText("jerga.txt");
                do
                {
                    linea = ficheroJerga.ReadLine();
                    if(linea != null)
                    {
                        lineaPartida = linea.Split(';');
                        diccionarioJerga.Add(lineaPartida[0], lineaPartida[1]);
                    }
                }
                while (linea != null);

                ficheroJerga.Close();

                //Pedimos al usuario que introduzca el nombre del fichero que quiere traducir
                Console.WriteLine("Introduce el nombre del fichero que quieres traducir");
                string nombreFichero = Console.ReadLine();

                //Traducimos el fichero.
                if (File.Exists(nombreFichero))
                {
                    StreamReader ficheroTexto = File.OpenText(nombreFichero);
                    List<string> listaTraducir = new List<string>();//Creamos una lista para almacenar cada línea del fichero a traducir
                    //Rellenamos la lista con las líneas del fichero a traducir
                    do
                    {
                        linea = ficheroTexto.ReadLine();
                        if (linea != null)
                        {
                            listaTraducir.Add(linea);
                        }
                    }
                    while (linea != null);

                    ficheroTexto.Close();

                    int tamanyoLista = listaTraducir.Count();
                    IDictionaryEnumerator enumerador;//Creamos un enumerador para recorrer la tabla Hash
                    //Para cada línea del fichero a traducir, recorremos el enumerador y vemos si hay alguna palabra susceptible de traducir
                    for (int i = 0; i < tamanyoLista; i++)
                    {
                        enumerador = diccionarioJerga.GetEnumerator();
                        while (enumerador.MoveNext() == true)
                        {
                            if (listaTraducir[i].IndexOf((string)enumerador.Key) >= 0)//Si en un elemento de la lista encontramos un Key, entramos en el if para sustituir por value
                                listaTraducir[i] = listaTraducir[i].Replace((string)enumerador.Key, (string)enumerador.Value);
                        }
                    }
                    //Imprimirmos por pantalla la lista, que es ahora la traducción completa del texto
                    for (int i = 0; i < tamanyoLista; i++)
                    {
                        Console.WriteLine(listaTraducir[i]);
                    }
                    Console.ReadKey();
                }
                else
                    Console.WriteLine("No se ha encontrado el fichero a traducir!");
            }
            else
                Console.WriteLine("No se ha encontrado el fichero que almacena el diccionario de jerga!");
        }
    }
}
