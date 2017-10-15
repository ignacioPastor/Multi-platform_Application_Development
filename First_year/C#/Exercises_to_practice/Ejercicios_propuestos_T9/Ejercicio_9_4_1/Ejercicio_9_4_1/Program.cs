using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_9_4_1
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

            Serializador s = new Serializador("Guardado.dat");
            s.Guardar(g1);
            g2 = s.Cargar();
            Console.WriteLine("Ahora Grupo 2:");
            g2.MostrarGrupo();
            Console.WriteLine();

        }
    }
}
