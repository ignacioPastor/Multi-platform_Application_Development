using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - Proyecto Final Programación - 1º DAM Semipresencial - Grupo A

// Esta clase gestiona los giros o rotaciones de las piezas.
// Comprobará si puede rotar y en caso afirmativo llamará a la siguiente rotación de la pieza.

namespace Tetris2
{
    class GestionGiro
    {
        // Gira o rota la pieza.
        // Primero hace la rotación
        // Después comprobará si hay en el tablero otro tetraedro con la misma posición x,y que no sea el de la pieza
        // Si hubiera dos tetraedros en la misma posición sería porque al rotar la pieza ha ocupado un espacio que ya está ocupado
        // Entonces volvemos a la posición anterior, y a efectos prácticos, es como si no hubiéramos rotado.
        public void GirarPieza(Pieza p, List<Tetraedro> t)
         {
            p.SiguienteRotacion();
            
            if(VerSiPuedeRotar(t, p) == false)
            {
                p.AnteriorRotacion();
            }
        }
        // Comprueba si se puede rotar. Es decir, la rotación ya se ha efectuado, lo que hacemos aquí es comprobar si hay dos
        // tetraedros con la misma posición x,y; síntoma de que la pieza ha ocupado una posición ocupada al rotar. En tal caso
        // devolvemos false.
        // Recordemos que la pieza está metida en el tablero. Por lo que necesariamente habrá siempre un tetraedro que tenga la posición
        // del tetraedro de la pieza que estamos examinando en ese momento. Por eso tendremos que comprobar que el tetraedro detectado
        // no es propiamente el de la pieza.
        public bool VerSiPuedeRotar(List<Tetraedro> t, Pieza p)
        {
            for (int i = 0; i < p.Posicion.Length; i++)
            {
                for (int j = 0; j < t.Count; j++)
                {
                    if(p.Posicion[i].X == t[j].X && p.Posicion[i].Y == t[j].Y && p.Posicion[i] != t[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
