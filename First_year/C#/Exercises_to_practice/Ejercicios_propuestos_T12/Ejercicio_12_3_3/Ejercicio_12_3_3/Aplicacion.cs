using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejercicio_12_3_3
{
    class Aplicacion
    {
        bool salir = false;
        int y;
        int yTope;
        string[] listaFicheros;
        ConsoleKeyInfo tecla;


        public void LanzarAplicacion()
        {
            do
            {
                Console.Clear();
                yTope = 0;

                Console.WriteLine("Flechas Up y Dawn para moverte. Cualquier otra para salir.");
                listaFicheros = Directory.GetFiles(".");
                foreach (string aFichero in listaFicheros)
                {
                    if (y == yTope)
                    {
                        Console.ForegroundColor =  ConsoleColor.Red;
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
                tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.UpArrow)
                {
                    subirCursor();
                }
                else if (tecla.Key == ConsoleKey.DownArrow)
                {
                    bajarCursor();
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
            if(y > 0)
                Console.SetCursorPosition(0, --y);
        }
        public void bajarCursor()
        {
            if (y < yTope - 1)
                Console.SetCursorPosition(0, ++y);
        }
        public void colorear()
        {

        }
    }
}
