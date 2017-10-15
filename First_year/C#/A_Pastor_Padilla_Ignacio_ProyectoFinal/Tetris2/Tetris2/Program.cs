using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - Proyecto Final Programación - 1º DAM Semipresencial - Grupo A

// Main del programa. Lanzará la pantalla de bienvenida, dando así comienzo al juego.

namespace Tetris2
{
    class Program
    {
        static void Main(string[] args)
        {
            Bienvenida b = new Bienvenida();

            b.PantallaBienvenida();
        }
    }
}
