using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    /*
        Esta clase tiene como objetivo la instrucción Singleton. Se utiliza para poder crear un objeto y que ese mismo objeto pueda ser utilizado
        en distintas clases sin tener que violar el principio de encapsulación a lo loco haciéndolo todo público y usando libremente lo que nos 
        haga falta.
        Esto lo he encontrado buscando una buena solución al problema de cómo usar un objeto con su información en distintas clases.
    */
namespace Consolenoid
{
    class Singleton
    {
        private static Nave n = null;
        private static Ladrillo[,] ladrillos1 = null;

        private Singleton() { }
        
        public static Nave GetNave()
        {
            if (n == null)
            {
                n = new Nave();  
            }
            return n;
        }
        public static Ladrillo[,] GetLadrillos1()
        {
            if (ladrillos1 == null)
            {
                ladrillos1 = new Ladrillo[4,10];
            }
            return ladrillos1;
        }
    }
}
