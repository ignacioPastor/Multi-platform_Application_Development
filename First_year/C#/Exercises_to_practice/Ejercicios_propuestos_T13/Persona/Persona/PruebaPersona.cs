using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona
{
    class PruebaPersona
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona();
            Persona p2 = new Persona();

            p1.Nombre = "Nacho";
            p2.Nombre = "Mario";

            p1.Saludar();
            p2.Saludar();
        }
    }
}
