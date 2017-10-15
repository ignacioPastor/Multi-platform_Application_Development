using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor - Este ejercicio se me ha quedado a medias porque no he tenido más tiempo
namespace GuerraMundialSharp
{
    class Infanteria : Unidad
    {
        public Infanteria()
        {
            nombre = "Infanteria";
            nivel = 50;
        }
        public override void Mostrar()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            base.Mostrar();
            Console.ResetColor();
        }
    }
}
