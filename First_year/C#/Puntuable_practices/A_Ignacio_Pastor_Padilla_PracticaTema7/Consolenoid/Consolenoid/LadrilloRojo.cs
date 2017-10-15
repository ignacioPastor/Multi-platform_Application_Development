using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Clase para el ladrillo rojo, resiste un golpe
namespace Consolenoid
{
    class LadrilloRojo : Ladrillo
    {
        public LadrilloRojo(int x, int y, bool roto)
        {
            this.x = x;
            this.y = y;
            this.roto = roto;
            nGolpes = 1;
        }
        public override void Dibujar()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            base.Dibujar();
            Console.ResetColor();
        }

    }
}
