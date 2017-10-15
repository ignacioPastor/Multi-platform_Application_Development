using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor - Este ejercicio se me ha quedado a medias porque no he tenido más tiempo
namespace GuerraMundialSharp
{
    class Marina : Unidad
    {
        public Marina()
        {
            nombre = "Marina";
            nivel = 100;
        }
        public override void Mostrar()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            base.Mostrar();
            Console.ResetColor();
        }
    }
}
