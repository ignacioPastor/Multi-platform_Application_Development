using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor - Este ejercicio se me ha quedado a medias porque no he tenido más tiempo
namespace GuerraMundialSharp
{
    class Unidad
    {
        public string nombre;
        protected int nivel;
        public Unidad()
        {
            
        }
        public Unidad(string nombre, int nivel)
        {
            this.nombre = nombre;
            this.nivel = nivel;
        }
        public virtual void Mostrar()
        {
            Console.WriteLine("{0} ({1})", nombre, nivel);
        }
    }
}
