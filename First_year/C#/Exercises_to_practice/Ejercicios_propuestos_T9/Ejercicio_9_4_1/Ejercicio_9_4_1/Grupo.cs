using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_9_4_1
{
    [Serializable]
    class Grupo
    {
        public Grupo(int n)
        {
            CrearGrupo(n);
        }
        Persona p;
        Persona[] grupoPersonas = new Persona[20];

        public void CrearGrupo(int n)
        {
            for (int i = 0; i < grupoPersonas.Length; i++)
            {
                p = new Persona();
                p.SetNombre(Convert.ToString(n * i));
                grupoPersonas[i] = p;
            }
        }
        public void MostrarGrupo()
        {
            for (int i = 0; i < grupoPersonas.Length; i++)
            {
                Console.Write(grupoPersonas[i].GetNombre() + " ");
            }
            Console.WriteLine();
        }
    }
}
