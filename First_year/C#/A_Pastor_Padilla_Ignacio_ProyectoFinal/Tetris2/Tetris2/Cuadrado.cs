using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - Proyecto Final Programación - 1º DAM Semipresencial - Grupo A

// Esta clase caracteriza la pieza Cuadrado, su color particular y la distribución particular de
// sus tetraedros en cada una de sus rotaciones.
// La posición de cada parte de la pieza irá en torno a una posición de referencia, que serán
// los valores x e y que recibirá. Ese será el "centro" de la pieza en torno al cual se construirá y girará

namespace Tetris2
{
    class Cuadrado : Pieza
    {
        public Cuadrado()
        {
        }
        public Cuadrado(int x, int y)
        {
            DarPropiedades();
            Rotar0(x, y);
        }

        public override void Rotar0(int x, int y)
        {
            posicion[0].X = x;
            posicion[0].Y = y;
            posicion[1].X = x + 1;
            posicion[1].Y = y;
            posicion[2].X = x;
            posicion[2].Y = y + 1;
            posicion[3].X = x + 1;
            posicion[3].Y = y + 1;

        }
        public override void Rotar1(int x, int y)
        {
            this.Rotar0(x, y);
        }
        public override void Rotar2(int x, int y)
        {
            this.Rotar0(x, y);
        }
        public override void Rotar3(int x, int y)
        {
            this.Rotar0(x, y);
        }
        public void DarPropiedades()
        {
            for (int i = 0; i < 4; i++)
            {
                posicion[i].AColor = Tetraedro.Color.blanco;
            }
        }

    }
}
