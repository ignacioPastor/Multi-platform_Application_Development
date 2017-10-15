using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//Ignacio Pastor - Este ejercicio se me ha quedado a medias porque no he tenido más tiempo
namespace GuerraMundialSharp
{
    class Ejercito
    {
        int nInfanteria, nMarina, nAviacion;
        string nombre;
        List<Unidad> ejercito = new List<Unidad>();
        Random r = new Random();

        public Ejercito(string nombre)
        {
            this.nombre = nombre;
            CrearEjercito();

        }
        public void CrearEjercito()
        {
            nInfanteria = r.Next(4, 11);
            nMarina = r.Next(3, 8);
            nAviacion = r.Next(1, 5);

            for (int i = 0; i < nInfanteria; i++)
                ejercito.Add(new Infanteria());

            for (int i = 0; i < nMarina; i++)
                ejercito.Add(new Marina());

            for (int i = 0; i < nAviacion; i++)
                ejercito.Add(new Aviacion());
        }
    }
}
