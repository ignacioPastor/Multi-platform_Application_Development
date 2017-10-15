using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor - Este ejercicio se me ha quedado a medias porque no he tenido más tiempo
namespace GuerraMundialSharp
{
    class Aviacion : Unidad
    {
        public Aviacion()
        {
            nombre = "Aviacion";
            nivel = 80;
        }
        public override void Mostrar()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            base.Mostrar();
            Console.ResetColor();
        }
    }
}
