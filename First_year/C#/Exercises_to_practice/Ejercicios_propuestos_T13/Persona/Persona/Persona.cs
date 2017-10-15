using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona
{
    class Persona
    {
        private string nombre;

        public string Nombre
        {
            set
            {
                nombre = value;
            }
        }


        public void Saludar()
        {
            Console.WriteLine("Hola, soy " + nombre);
        }
    }
}
