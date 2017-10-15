using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Esta clase Contendrá la pantalla inicial y a la que volveremos cuando terminemos una partida, da la opción de jugar o de salir del juego (programa)
namespace Consolenoid
{
    class Bienvenida
    {
        bool salir;

        // Lanza la pantalla de bienvenida, y se guarda si queremos salir o jugar en la variable "salir"
        public void Lanzar()
        {
            // Sprite sprite = new Sprite();
            Console.Clear();
            //Console.SetCursorPosition(0, 0);
            string bienvenido = "Bienvenido a Consolenoid";
            string pulseTecla = "Pulse Intro para jugar o ESC para salir";


            for (int i = 0; i < 4; i++) //for para dejar un espacio libre arriba (estética)
                Console.WriteLine();



            // primera linea de asteriscos amarillos
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 79; i++)
                Console.Write("*");
            Console.ResetColor();
            Console.WriteLine();


            //Texto en medio de los asteriscos, en verde
            Console.ForegroundColor = ConsoleColor.Green;
            EscribirCentrado(bienvenido);
            EscribirCentrado(pulseTecla);
            Console.ResetColor();

            // Segunda línea de asteriscos amarillos
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 79; i++)
                Console.Write("*");
            Console.ResetColor();
            Console.WriteLine();

            // Texto explicativo, debajo del cuadro de bienvenida. Verde
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Para mover la nave a un lado u otro, utilice las flechas de cursor izquierda y derecha."
                + "Para iniciar la partida, o reanudarla tras perder una vida, pulse la barra espaciadora.");
            Console.ResetColor();

            // Leemos la acción del Usuario
            ConsoleKeyInfo tecla = Console.ReadKey();
            if (tecla.Key == ConsoleKey.Escape)
                salir = true;
            else if (tecla.Key == ConsoleKey.Enter)
                salir = false;
            else
            {
                Console.WriteLine("Opción incorrecta. Saliendo del juego");
                salir = true;
            }
        }
            // Para escribir texto centrado en pantalla
            public void EscribirCentrado(string texto)
            {
            int espacios = (80 - texto.Length) / 2;
            for (byte i = 0; i < espacios; i++)
                Console.Write(" ");
            Console.WriteLine(texto);
            }
    

        // Obtiene si queremos salir del juego
        public bool GetSalir()
        {
            return salir;
        }
    }
}
