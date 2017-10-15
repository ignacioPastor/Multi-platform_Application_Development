using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

/*
(12.4.1) Mejora el ejercicio 12.3.3 (la versión básica del programa "tipo Comandante Norton") para que,
si se pulsa Intro sobre un cierto fichero, lance el correspondiente proceso.
*/
namespace Ejercicio_12_4_1
{
    class Aplicacion
    {
        Process proceso;
        bool salir = false;
        int y;
        int yTope;
        string[] listaFicheros;
        ConsoleKeyInfo tecla;
        string direccion = ".";
        int soyDirectorio;
        bool irHijo = false;
        int soyFichero;
        bool lanzarProceso = false;

        DirectoryInfo dirActual = new DirectoryInfo(".");
        public Aplicacion()
        {

        }

        public void MostrarCosicas()
        {
            
            FileInfo[] ficheros = dirActual.GetFiles("*");
            DirectoryInfo[] directorios = dirActual.GetDirectories();
            if (irHijo == true)
            {
                //Console.WriteLine("Entra en el hijo");
                try
                {
                    //Console.WriteLine("Antes de dirActu");
                    dirActual = directorios[y - 1];
                    //Console.WriteLine("Antes de directorios");
                    directorios = dirActual.GetDirectories();
                    //Console.WriteLine("Antes de ficheros");
                    ficheros = dirActual.GetFiles("*");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                irHijo = false;
                // Console.WriteLine("Justo antes de salir del hijo");
            }
            else if (lanzarProceso == true)
            {
                proceso = Process.Start(ficheros[y - 1 - soyDirectorio].FullName);
                lanzarProceso = false;
            }



            //y = 0;
            yTope = 0;
            if (y == yTope)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("<..>");
            Console.ForegroundColor = ConsoleColor.White;
            yTope++;
            soyDirectorio = 0;
            soyFichero = 0;
            for (int i = 0; i < directorios.Length; i++)
            {

                if (y == yTope)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("<" + directorios[i].Name + ">");
                    Console.ForegroundColor = ConsoleColor.White;
                    yTope++;
                    soyDirectorio++;
                }
                else
                {
                    Console.WriteLine("<" + directorios[i].Name + ">");
                    yTope++;
                    soyDirectorio++;
                }
            }
            for (int i = 0; i < ficheros.Length; i++)
            {
                if (y == yTope)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ficheros[i].Name);
                    yTope++;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(ficheros[i].Name);
                    yTope++;
                }
                soyFichero++;
            }
            //y = yTope;

        }

        public void LanzarAplicacion()
        {
            do
            {
                Console.Clear();
                //yTope = 0;
                /*
                Console.WriteLine("Flechas Up y Dawn para moverte. Cualquier otra para salir.");
                listaFicheros = Directory.GetFiles(".");
                foreach (string aFichero in listaFicheros)
                {
                    if (y == yTope)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("yTope vale {0}, y vale {1} ", yTope, y);
                        Console.WriteLine(aFichero);
                        yTope++;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("yTope vale {0}, y vale {1} ", yTope, y);
                        Console.WriteLine(aFichero);
                        yTope++;
                    }
                }
                */
                MostrarCosicas();
                //Console.WriteLine("y vale {0}, yTope vale {1}, soyDirectorio vale {2}, soyFichero vale {3}", y, yTope, soyDirectorio, soyFichero);
                tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.UpArrow)
                {
                    // Console.WriteLine("Entra en el parriba tecla");
                    subirCursor();
                }
                else if (tecla.Key == ConsoleKey.DownArrow)
                {
                    bajarCursor();
                }
                else if (tecla.Key == ConsoleKey.Enter)
                {
                   // Console.WriteLine("Entra en el Enter");
                   // Console.ReadLine();
                    if (y == 0)
                    {
                        dirActual = dirActual.Parent;
                    }
                    else if (y <= soyDirectorio)
                    {
                        irHijo = true;
                    }
                    else if(soyFichero > 0)
                    {
                        lanzarProceso = true;
                    }
                }
                else
                {
                    salir = true;
                }
            }
            while (salir == false);
        }
        public void subirCursor()
        {
            //Console.WriteLine("Entra en el subirCursor()");

            // Console.ReadKey();
            if (y > 0)
                Console.SetCursorPosition(0, --y);
        }
        public void bajarCursor()
        {
            if (y < yTope - 1)
                Console.SetCursorPosition(0, ++y);
        }
    }
}
