using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

/*
Crea un programa que monitorice cambios en una página web, comparando el contenido actual
con una copia guardada en fichero. Deberá mostrar en pantalla un mensaje que avise al usuario de si hay cambios o no.
*/
namespace Ejercicio_12_6_3
{
    class Program
    {
        
        

        public static void HacerCopia()
        {
            WebClient cliente = new WebClient();
            Stream conexion = cliente.OpenRead("http://www.nachocabanes.com");
            StreamReader lector = new StreamReader(conexion);
            string linea;
            int contador = 0;
            StreamWriter copiaGuardada = File.CreateText("copiaAntigua.txt");

            while((linea = lector.ReadLine()) != null)
            {
               // copiaGuardada.Write(++contador + ": ");
                copiaGuardada.WriteLine(linea);
               
            }
            //copiaGuardada.WriteLine(contador);
            copiaGuardada.Close();
            conexion.Close();
        }
        public static void ComprobarCambios()
        {
            
            if (File.Exists("copiaAntigua.txt"))
            {
                WebClient cliente = new WebClient();
                Stream conexion = cliente.OpenRead("http://www.nachocabanes.com");
                StreamReader lector = new StreamReader(conexion);
                StreamReader ficheroLectura = File.OpenText("copiaAntigua.txt");
                string lineaWeb;
                string lineaFichero;
                int contadorLinea = 0;
                int contadorCambios = 0;
                while(((lineaWeb = lector.ReadLine()) != null) && ((lineaFichero = ficheroLectura.ReadLine()) != null))
                {
                    ++contadorLinea;
                    if (lineaWeb != lineaFichero)
                    {
                        contadorCambios++;
                        SenyalarLineaCambio(contadorLinea);
                    }
                    
                }

                if (contadorCambios != 0)
                    Console.WriteLine("Ha habido {0} cambios", contadorCambios);
                else
                    Console.WriteLine("No ha habido ningún cambio");
                ficheroLectura.Close();
                conexion.Close();
            }
            else
                Console.WriteLine("No se ha encontrado el fichero");
        }
        static void SenyalarLineaCambio(int lCambio)
        {
            Console.WriteLine("Cambio producido en la linea {0}", lCambio);
        }
        static void Main(string[] args)
        {
            bool salir = false;
            string opcion;
            do
            {
                Console.WriteLine("Indica qué quieres hacer:");
                Console.WriteLine("1. Hacer copia de la web");
                Console.WriteLine("2. Comprobar si ha habido cambios");
                Console.WriteLine("0. Salir");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1"://Hacer copia de la web
                        Console.WriteLine("Realizando copia en fichero...");
                        HacerCopia();
                        Console.WriteLine("Copia realizada con éxito");
                        break;
                    case "2"://Comprobar si ha habido cambios
                        Console.WriteLine("Comprobando si ha habido cambios...");
                        ComprobarCambios();
                        break;
                    case "0"://Salir
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("No es una opción válida");
                        break;

                }
            }
            while (salir == false); 
        }
    }
}
