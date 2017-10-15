using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - Proyecto Final Programación - 1º DAM Semipresencial - Grupo A

// Clase que contiene las propiedades generales de las piezas. De esta heredarán todas las piezas.

namespace Tetris2
{
    class Pieza
    {
        Sprite s = new Sprite();
        protected Tetraedro[] posicion; // Una pieza es un array de cuatro tetraedros (cuadritos)
        protected int rotacion = 0; // Toda pieza se inicirá en su rotación 0
        
        public Pieza()
        {
            posicion = new Tetraedro[4]; // Toda pieza se compone de cuatro tetraedros (cuadritos)
            for (int i = 0; i < 4; i++) // Creamos los cuatro tetraedros de la pieza
                posicion[i] = new Tetraedro();
        }

        // Cuando se indica que hay que rotar, se aumenta la variable rotación, y se llama mediante un swich al método que
        // asignará la pieza a la rotación que corresponda. Cada rotación o posición de la pieza estará construida en torno
        // a una posición de referencia (el centro de la pieza). Este centro será siempre el primer tetraedro del array, lo 
        // cual está controlado, y se guardará el centro siempre en ese lugar.
        public void SiguienteRotacion()
        {
            int x = posicion[0].X; //Asignamos a la x e y de referencia los valores de x e y de la primera posición del array
            int y = posicion[0].Y;

            rotacion++;
            if (rotacion == 4)
                rotacion = 0;
            switch (rotacion) // Mandaremos la posición de referencia al algoritmo de asignación que corresponda
            {
                case 0:
                    Rotar0(x, y);
                    break;
                case 1:
                    Rotar1(x, y);
                    break;
                case 2:
                    Rotar2(x, y);
                    break;
                case 3:
                    Rotar3(x, y);
                    break;
            }
        }
        // Para volver a la rotación anterior
        public void AnteriorRotacion()
        {
            int x = posicion[0].X;
            int y = posicion[0].Y;

            rotacion--;
            if (rotacion == -1)
                rotacion = 3;
            switch (rotacion)
            {
                case 0:
                    Rotar0(x, y);
                    break;
                case 1:
                    Rotar1(x, y);
                    break;
                case 2:
                    Rotar2(x, y);
                    break;
                case 3:
                    Rotar3(x, y);
                    break;
            }
        }

        // Cuando se llame a la rotación de la pieza, la función de rotación será la de cada una de las piezas hijas
        public virtual void Rotar0(int x, int y)
        {

        }
        public virtual void Rotar1(int x, int y)
        {

        }
        public virtual void Rotar2(int x, int y)
        {

        }
        public virtual void Rotar3(int x, int y)
        {

        }
        // Propiedad para asignar y acceder al array de posiciones de cada tetraedro de nuestra pieza
        public Tetraedro[] Posicion
        {
            get
            {
                return posicion;
            }
            set
            {
                posicion = value;
            }
        }
        // Método para mover la pieza. Una vez que en GestionMovimiento hemos comprobado que se puede hacer el movimiento
        // indicamos a la pieza que se mueva. Para moverse hacia abajo aumentará su posición Y
        public void MoverAbajo()
        {
            for (int i = 0; i < posicion.Length; i++)
            {
                s.BorrarTetraedro(posicion[i]);
                posicion[i].Y += 1;
            }
        }
        // Mover pieza a la derecha. Aumenta posición X
        public void MoverDerecha()
        {
            for (int i = 0; i < posicion.Length; i++)
            {
                s.BorrarTetraedro(posicion[i]); //Antes de cambiar la posición de un tetraedro, borramos la posición anterior
                posicion[i].X += 1;
            }
        }
        // Mover pieza a la izquierda, decrece posición X
        public void MoverIzquierda()
        {
            for (int i = 0; i < posicion.Length; i++)
            {
                s.BorrarTetraedro(posicion[i]);
                posicion[i].X -= 1;
            }
        }
    }
}
