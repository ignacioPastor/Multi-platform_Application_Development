using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Clase para el ladrillo fuerte, o ladrillo amarillo, el cual resiste dos golpes
namespace Consolenoid
{
    class LadrilloFuerte : Ladrillo
    {
        public LadrilloFuerte(int x, int y, bool roto)
        {
            this.x = x;
            this.y = y;
            this.roto = false;
            nGolpes = 2; //Es necesario golpearlo dos veces para romperlo
        }
        public override void Dibujar()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            base.Dibujar();
            Console.ResetColor();
        }
    }
}
