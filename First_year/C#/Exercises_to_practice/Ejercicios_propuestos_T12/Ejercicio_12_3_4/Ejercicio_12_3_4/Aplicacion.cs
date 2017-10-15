using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejercicio_12_3_4
{
    class Aplicacion
    {
        bool salir = false;
        int y;
        int yTope;
        string[] listaFicheros;
        ConsoleKeyInfo tecla;
        string direccion = ".";
        int soyDirectorio;
        bool irHijo = false;

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
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                irHijo = false;
               // Console.WriteLine("Justo antes de salir del hijo");
            }



            //y = 0;
            yTope = 0;
            if (y == yTope)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("<..>");
            Console.ForegroundColor = ConsoleColor.White;
            yTope++;
            soyDirectorio = 0;
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
                //Console.WriteLine("y vale {0}, yTope vale {1}, soyDirectorio vale {2}", y, yTope, soyDirectorio);
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
                    if (y == 0)
                    {
                        dirActual = dirActual.Parent;
                    }
                    else if (y <= soyDirectorio)
                    {
                        irHijo = true;

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
