using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

//Ignacio Pastor Padilla - DAM Semi - A

//(12.1.2) Crea un reloj que se muestre en pantalla, y que se actualice cada segundo (usando "Sleep").
//En esta primera aproximación, el reloj se escribirá con "WriteLine", de modo que aparecerá en la primera línea de pantalla,
//luego en la segunda, luego en la tercera y así sucesivamente (en el próximo apartado veremos cómo hacer que se mantenga fijo
//en unas ciertas coordenadas de la pantalla).

namespace Ejercicio_12_1_2
{
    class Program
    {
        static void Main(string[] args)
        {

            ConsoleKeyInfo tecla;
            bool salir = false;;
            do
            {
                if (Console.KeyAvailable)
                {
                    tecla = Console.ReadKey();
                    if (tecla.Key == ConsoleKey.Escape)
                        salir = true;
                }

                DateTime reloj = DateTime.Now;
                Console.WriteLine("{0}:{1}:{2}", reloj.Hour, reloj.Minute, reloj.Second);

                Thread.Sleep(1000);
            }
            while (salir == false);
        }
    }
}
