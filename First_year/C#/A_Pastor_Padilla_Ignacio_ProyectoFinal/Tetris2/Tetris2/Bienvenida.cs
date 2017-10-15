using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - Proyecto Final Programación - 1º DAM Semipresencial - Grupo A

// Esta clase gestiona la pantalla de bienvenida, donde se muestran los comandos disponibles
namespace Tetris2
{
    class Bienvenida
    {
        Sprite s = new Sprite();
        Partida p = new Partida();

        //Estructura de la pantalla de bienvenida
        public void PantallaBienvenida()
        {
            int nL = 40;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < nL; i++)
            {
                Console.Write("*+");
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            s.EscribirCentrado("Bienvenido al Tetris");
            s.EscribirCentrado("Pulsa una tecla para empezar a jugar");

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < nL; i++)
            {
                Console.Write("*+");
            }
            Console.WriteLine();

            Instrucciones(); //Lanzamos la muestra de los comandos

            Console.ReadKey(true);
            Console.Clear();
            p.Lanzar(); // Lanzamos el juego
        }

        // Imprime el texto con comandos disponibles
        public void Instrucciones()
        {
            s.EscribirCentrado("Teclas:");
            s.EscribirCentrado("Flechas Izq / Drch ", "para mover la pieza lateralmente");
            s.EscribirCentrado("Flecha abajo ", "para acelerar el movimiento de la pieza");
            s.EscribirCentrado("Barra Espaciadora ", "para rotar");
            s.EscribirCentrado("F10 ", "para Pusar la partida");
            s.EscribirCentrado("F11 ", "para Guardar la partida");
            s.EscribirCentrado("F12 ", "para Cargar una partida anterior");
            s.EscribirCentrado("F9 ", "para entrar en Modo Corrector");
        }
    }
}