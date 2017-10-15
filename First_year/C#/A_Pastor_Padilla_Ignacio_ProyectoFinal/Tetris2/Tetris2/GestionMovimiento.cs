using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - Proyecto Final Programación - 1º DAM Semipresencial - Grupo A

// Esta clase gestionará los movimientos de las piezas, tanto hacia abajo como los laterales.
// Aquí comprobaremos si puede moverse, o por el contrario, hay otro objeto que se lo impide

namespace Tetris2
{
    class GestionMovimiento
    {
        Sprite s = new Sprite();

        public GestionMovimiento()
        {
        }
        //Mover Pieza hacia abajo. Primero comprobamos si no hay ningún objeto debajo.
        // Si no lo hay, movemos la pieza y devolvemos true
        public bool MoverPiezaAbajo(List<Tetraedro> t, Pieza p)
        {
            if (VerSiHayContactoAbajo(t, p) == false)
            {
                p.MoverAbajo();
                return true;
            }
            else
                return false;
        }

        // Comprueba si hay un objeto abajo comprobando si ya ha hecho contacto
        // Recorremos cada una de los cuatro tetraedros de la pieza y cada uno de los tetraedros
        // que están en el tablero. Nos fijaremos en que su x sea igual, y la Y del del tablero sea uno más.
        // En caso de que haya detectado un tetraedro debajo del tetraedro de la pieza que estamos examinando,
        // recorremos de nuevo la pieza para comprobar que ese tetraedro encontrado no pertenece a la pieza.
        // Recordemos que la pieza está dentro del tablero, y cuando examinamos cada una de sus partes, tendrá
        // cada uno de sus tetraedros otros alrededor de la misma pieza, que no nos interesan como contacto

        // Será un método booleano porque a diferencia de los movimientos laterales (si detectan contacto
        // simplemente no llevan a cabo el movimiento), en caso de contacto abajo debemos informar a la partida
        // para dejar la pieza en el tablero como parte del bloque de piezas y crear una nueva pieza.
        public bool VerSiHayContactoAbajo(List<Tetraedro> t, Pieza p)
        {
            for (int k = 0; k < p.Posicion.Length; k++)
            {
                for (int i = 0; i < t.Count; i++)
                {
                    if (t[i].X == p.Posicion[k].X && t[i].Y == p.Posicion[k].Y + 1)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if(t[i] == p.Posicion[j])
                            {
                                break; // Si el tetraedro encontrado resulta ser una parte inferior de la misma
                            }           // pieza, salimos del bucle
                            else if(j == 3)
                                return true; // Si recorremos la pieza y no le pertenece, será que hemos topado
                        }                   // con un tetraedro del borde, o del bloque de piezas. Hay Contacto
                    }
                }
            }
            return false; // Si recorremos la pieza y el tablero y no encontramos nada debajo, no hay contacto
        }
        // Mueve la pieza a la derecha. Misma lógica que para mover la pieza hacia abajo
        // Si no detecta ningún objeto a la derecha de la pieza, realizará el movimiento.
        public void MoverPiezaDerecha(List<Tetraedro> t, Pieza p)
        {
            if (VerSiHayContactoDerecha(t, p) == false)
            {
                p.MoverDerecha();
            }
        }
        // Comprueba si hay algún objeto a la derecha de la pieza. Misma lógica que para detectar contacto abajo
        // Recorremos pieza y tablero viendo si hay algún objeto a la derecha de la pieza, caso afirmativo,
        // recorremos de nuevo la pieza para comprobar que no es ninguno de los elementos de nuestra pieza.
        public bool VerSiHayContactoDerecha(List<Tetraedro> t, Pieza p)
        {
            for (int k = 0; k < p.Posicion.Length; k++)
            {
                for (int i = 0; i < t.Count; i++)
                {
                    if (t[i].X == p.Posicion[k].X + 1 && t[i].Y == p.Posicion[k].Y)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (t[i] == p.Posicion[j])
                            {
                                break;
                            }
                            else if (j == 3)
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        // Mueve la pieza a la izquierda. Misma lógica que el resto de movimientos
        public void MoverPiezaIzquierda(List<Tetraedro> t, Pieza p)
        {
            if (VerSiHayContactoIzquierda(t, p) == false)
            {
                p.MoverIzquierda();
            }
        }
        // Detecta si se puede mover la pieza a la izquierda, misma lógica que en el resto de movimientos
        public bool VerSiHayContactoIzquierda(List<Tetraedro> t, Pieza p)
        {
            for (int k = 0; k < p.Posicion.Length; k++)
            {
                for (int i = 0; i < t.Count; i++)
                {
                    if (t[i].X == p.Posicion[k].X - 1 && t[i].Y == p.Posicion[k].Y)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (t[i] == p.Posicion[j])
                            {
                                break;
                            }
                            else if (j == 3)
                                return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
