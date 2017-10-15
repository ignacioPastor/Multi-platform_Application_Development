using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Clase para el ladrillo azul, resiste solo un golpe
namespace Consolenoid
{
    class LadrilloAzul : Ladrillo
    {
        public LadrilloAzul(int x, int y, bool roto)
        {
            this.x = x;
            this.y = y;
            this.roto = roto;
            nGolpes = 1; 
        }
        
        public override void Dibujar()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            base.Dibujar();
            Console.ResetColor();
        }
    }
}
