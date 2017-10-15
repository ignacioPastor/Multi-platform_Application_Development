using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - Proyecto Final Programación - 1º DAM Semipresencial - Grupo A

// Clase que caracteriza al objeto Tetraedro. Un tetraedro es un cuadrito.
// Cada pieza se compone de cuatro cuadritos (Tetris, Tetra...)
// Los bordes también serán tetraedros, así gestionaremos mejor que el tablero aumente en distintos niveles y
// el movimiento de la pieza.

namespace Tetris2
{
    [Serializable]
    class Tetraedro
    {
        //Cada tetraedro tendrá un valor X, Y; y será también el que tenga el color.
        // De esta forma, no es la pieza la que tiene un color determinado, sino los tetraedros de esa pieza.
        // Esto será muy adecuado para imprimir cada cosa del color correspondiente con una sola función y distinguir los bordes.
        int x;
        int y;
        public enum Color { verde, gris, blanco, azul, magenta, rojo, cian, amarillo, negro };
        protected Color aColor;

        public Tetraedro()
        {
        }
        public Tetraedro(int x, int y, Color aColor)
        {
            this.x = x;
            this.y = y;
            this.aColor = aColor;
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public Color AColor
        {
            get
            {
                return aColor;
            }
            set
            {
                aColor = value;
            }
        }
    }
}
