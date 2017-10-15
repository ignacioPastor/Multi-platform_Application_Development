using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
// Hereda de Sprite pues es un elemento que se dibujará en pantalla.
//En esta clase tenemos aquello relativo a la nave, sus características, consideraciones particulares en su movimiento, y efecto visual  si pelota toca suelo
namespace Consolenoid
{
    class Nave : Sprite
    {
        public Nave()
        {
            SetImagen("          "); //La nave ocupará 10 espacios
            SetX(40 - GetImagen().Length / 2);
            SetY(26);
        }
        public void MoverDerecha()//Previo a mover la nave, consideramos el movimiento a la derecha y tenemos en cuenta su extensión y movimiento de 4 en 4
        {
            if(x + GetUnidadX() > 70) // La nave ocupa 10 espacios, tenemos que tener en cuenta el extremo derecho en el movimiento a la derecha
                MoverA(70, y);        // Así, el límite será la posición de x == 70. Además hay que tener en cuenta que la nave se mueve de 4 en 4
            else                      // por lo que antes tenemos que controlar que la posición previa + 4 deja la nave dentro de los límites. Si no es
                MoverA(x + GetUnidadX(), y);//así la moveremos a la posición límite para que pueda limitar bien con la pared y no quede hueco

        }
        public void MoverIzquierda()//Mover nave a la izquierda. Igual que en la derecha, controlamos de límite el borde establecido y el movimiento de 4 en 4
        {
            if (x - GetUnidadX() < 0)
                MoverA(0, y);
            else
                MoverA(x - GetUnidadX(), y);
        }
        public override void Dibujar() //Dibujaremos la nave de color blanco
        {
            Console.BackgroundColor = ConsoleColor.White;
            base.Dibujar();
            Console.ResetColor();
        }
        public void ComboTocarSuelo() // Efecto visual de la nave cuando la pelota toca el suelo de la consola y se pierde una vida
        {
            for (int i = 0; i < 12; i++) //Se usa un for y la instrucción Thread.Sleep para conseguir que parpade (rojo, desaparece, blanco) 12 veces
            {
                if (i % 2 == 0)
                {
                    
                    Console.BackgroundColor = ConsoleColor.Red;//Primero se dibuja en rojo
                    Console.SetCursorPosition(GetX(), GetY());
                    Console.Write("          ");
                    Console.ResetColor();
                    Thread.Sleep(140);
                    Console.SetCursorPosition(GetX(), GetY());
                    Console.Write("          ");//Después desaparece

                }
                else
                {
                    Dibujar();//Se dibuja en color original (blanco)
                }
                Thread.Sleep(140);
            }
        }
    }
}
