using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Main del programa, simplemente lanzará el juego
namespace Consolenoid
{
    class Consolenoid
    {
        static void Main(string[] args)
        {

            Juego j = new Juego();

            j.Lanzar();
        }
    }
}
