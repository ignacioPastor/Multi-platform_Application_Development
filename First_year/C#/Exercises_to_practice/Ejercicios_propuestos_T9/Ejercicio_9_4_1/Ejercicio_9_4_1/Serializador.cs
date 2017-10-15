using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;
using System.IO;

namespace Ejercicio_9_4_1
{
    class Serializador
    {
        string nombre;
        public Serializador(string nombre)
        {
            this.nombre = nombre;
        }

        public void Guardar(Grupo objeto)
        {
            IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream(nombre, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, objeto);
            stream.Close();
        }

        public Grupo Cargar()
        {
            Grupo objeto;
            IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream(nombre, FileMode.Open, FileAccess.Read, FileShare.Read);
            objeto = (Grupo)formatter.Deserialize(stream);
            stream.Close();
            return objeto;
        }
    }
}
