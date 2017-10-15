using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_9_2_1
{
    [Serializable]
    public class Persona
    {
        string nombre;

        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public string GetNombre()
        {
            return nombre;
        }


        public static void Guardar(string nombre, Persona objeto)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(nombre, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, objeto);
            stream.Close();
        }
        public static Persona Cargar(string nombre)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(nombre, FileMode.Open, FileAccess.Read, FileShare.Read);
            Persona objeto = (Persona)formatter.Deserialize(stream);
            stream.Close();
            return objeto;
        }
        static void Main(string[] args)
        {
            Persona p1 = new Persona();
            p1.SetNombre("Paco");
            Console.WriteLine("p1 se llama {0}", p1.GetNombre());

            Persona p2 = new Persona();
            p2.SetNombre("Rodolfo");
            Console.WriteLine("p2 se llama {0}", p2.GetNombre());

            Guardar("guardado.dat", p1);
            p2 = Cargar("guardado.dat");
            Console.WriteLine("p2 se llama {0}", p2.GetNombre());
        }
    }
}
