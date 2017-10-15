using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
(9.3.1) Crea una variante del ejercicio 9.2.1, que use una clase auxiliar para la serialización.
*/
namespace Ejercicio_9_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona();
            p1.SetNombre("Paco");
            Console.WriteLine("p1 se llama {0}", p1.GetNombre());

            Persona p2 = new Persona();
            p2.SetNombre("Rodolfo");
            Console.WriteLine("p2 se llama {0}", p2.GetNombre());

            AuxiliarSerial s = new AuxiliarSerial("ejemplo.dat");
            s.Guardar(p1);
            p2 = s.Cargar();
            Console.WriteLine("Ahora p2 se llama {0}", p2.GetNombre());
        }
    }
}
