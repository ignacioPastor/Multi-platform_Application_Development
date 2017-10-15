using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Hereda de Sprite, en esta clase tenemos la estructura básica que heredarán las tres subclases de ladrillo
namespace Consolenoid
{
    class Ladrillo : Sprite
    {
        protected bool roto;
        protected int nGolpes; //Contador de los golpes que resisten y los que le quedan

        public Ladrillo()
        {
            imagen = "        "; //Los ladrillos ocupan 8 espacios
            roto = false;
        }
        public override void Dibujar()
        {
            base.Dibujar();
        }
        public void SetRoto(bool roto)
        {
            this.roto = roto; 
        }
        public bool GetRoto()
        {
            return roto;
        }
        public int  GetNGolpes()
        {
            return nGolpes;
        }
        public void SetNGolpes()
        {
            nGolpes -= 1;
        }
        

    }
}
