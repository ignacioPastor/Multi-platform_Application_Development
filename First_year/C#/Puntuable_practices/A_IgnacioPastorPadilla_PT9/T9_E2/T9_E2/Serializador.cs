using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - Practica Programación Tema 9 - 1º DAM Semi, Grupo A

// Clase para serializar los archivos, y poder así guardar y cargar toda la información.
// En un primer momento he intentado trabajar con archivos xml, pero han surgido muchos problemas al tratar de serializarlos.
// Finalmente, la opción para que funcione ha sido trabajar con fichero xml en el catálogo, y binarios en las peticiones.

namespace T9_E2
{
    [Serializable]
    class Serializador
    {
        string nombre;
        Libro[] arrayLibros;
        public Serializador(string nombre)
        {
            this.nombre = nombre;
        }

        public void GuardarPeticiones(List<Peticion> objeto) // Guarda la lista de peticiones en un archivo binario.
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(nombre, FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                formatter.Serialize(stream, objeto);
            }
            catch (Exception o)
            {
                Console.WriteLine("Ha habido un error: {0}", o.Message);
                stream.Close();
            }
            stream.Close();
        }

        public List<Peticion> CargarPeticiones() // Carga la lista de peticiones desde un archivo binario
        {
            List<Peticion> objeto;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(nombre, FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                objeto = (List<Peticion>)formatter.Deserialize(stream);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ha habido un error: {0}", e.Message);
                stream.Close();
                objeto = null;
            }
            stream.Close();
            return objeto;
        }

        public List<Libro> CargarCatalogo() // Carga el catálogo desde un archivo xml. En los archivos xml no se pueden guardar Listas genéricas,
        {                                   // así que antes de guardar paso la lista a array, y al cargar, cargo un array, que paso a lista inmediatamente. Para trabajar con listas
            IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream(nombre, FileMode.Open, FileAccess.Read, FileShare.Read);
            arrayLibros  = (Libro[])formatter.Deserialize(stream); // Cargamos un array
            stream.Close();
            List<Libro> objeto = arrayLibros.ToList<Libro>(); // Pasamos el array a Lista genérica
            return objeto;
        }
    }
}
