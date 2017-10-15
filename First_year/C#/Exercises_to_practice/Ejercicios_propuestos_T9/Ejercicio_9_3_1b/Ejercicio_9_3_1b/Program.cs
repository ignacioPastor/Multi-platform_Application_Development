using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_9_3_1b
{
    class Program
    {
        static void Main(string[] args)
        {
            Grupo g1 = new Grupo(2);
            Console.WriteLine("Grupo 1:");
            g1.MostrarGrupo();
            Console.WriteLine();

            Grupo g2 = new Grupo(4);
            Console.WriteLine("Grupo 2:");
            g2.MostrarGrupo();
            Console.WriteLine();

            Serializador s = new Serializador("pruebaGuardado.dat");
            s.Guardar(g1);
            g2 = s.Cargar();
            Console.WriteLine("Grupo 2 cargado:");
            g2.MostrarGrupo();
            Console.WriteLine();

        }
    }
}
