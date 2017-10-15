using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Ejercicio_9_3_1
{
    class AuxiliarSerial
    {
        string nombre;

        public AuxiliarSerial(string nombre)
        {
            this.nombre = nombre;
        }
        public void Guardar(Persona objeto)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(nombre, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, objeto);
            stream.Close();
        }
        public Persona Cargar()
        {
            Persona objeto;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(nombre, FileMode.Open, FileAccess.Read, FileShare.Read);
            objeto = (Persona)formatter.Deserialize(stream);
            stream.Close();
            return objeto;
        }

    }
}
