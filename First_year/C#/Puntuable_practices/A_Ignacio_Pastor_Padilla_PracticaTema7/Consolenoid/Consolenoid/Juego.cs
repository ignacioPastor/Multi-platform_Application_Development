using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Esta clase tiene un blucle donde muestra primero la pantalla de bienvenida, después lanza la partida si el usuario así lo indica, o sale si Escape
namespace Consolenoid
{
    class Juego
    {
        public void Lanzar()
        {
            Bienvenida b;
            do
            {
                b = new Bienvenida();
                b.Lanzar();//Lanzamos la pantalla de bienvenida
                if (b.GetSalir() == false)
                {
                    Console.Clear();
                    Partida p = new Partida();
                    p.Lanzar();//Lanzamos la partida
                    Console.Clear();
                }//Mientras no se indique salir, seguiremos lanzando la partida desde la pantalla de bienvenida
            } while (b.GetSalir() == false);
        }
    }
}
