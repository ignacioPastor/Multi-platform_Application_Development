using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_9_3_1b
{
    [Serializable]
    class Grupo
    {
        Persona p;
        Persona[] grupoPersonas = new Persona[20];

        public Grupo(int n)
        {
            CrearGrupo(n);
        }

        public void CrearGrupo(int n)
        {
            for (int i = 0; i < grupoPersonas.Length; i++)
            {
                p = new Persona();
                p.SetNombre(Convert.ToString(i * n));
                grupoPersonas[i] = p;
            }
        }
        public void MostrarGrupo()
        {
            for (int i = 0; i < grupoPersonas.Length; i++)
            {
                Console.Write("{0}  ", grupoPersonas[i].GetNombre());
            }
            Console.WriteLine();
        }
    }
}
