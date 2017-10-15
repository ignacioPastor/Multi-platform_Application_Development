using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

// Ignacio Pastor Padilla  - Practica Programación Tema 9 - 1º DAM Semi, Grupo A

// Clase Serializador que gestiona la selializacion y deseialización de ficheros. En esta clase estarán los métodos para guardar y cargar
// la información que introduzcamos. Trabajaremos con Listas genéricas en el programa. Pero como guardamos en ficheros xml, tendremos que
// guardar un array, ya que las listas genéricas dan problemas al guardarlas en estos ficheros. Para ello trabajaremos con listas, pero 
// antes de guardar pasaremos la información a un array, que será lo que guardemos. De igual manera, cargaremos un array y lo pasaremos a lista.

namespace T9_E1
{
    class Serializador
    {
        string nombre; 
        Libro[] arrayLibros; // Array que utilizaremos para guardar / cargar en el fichero.
        
        public Serializador(string nombre) // Al crear el objeto Serializador, le pasaremos directamente el nombre del fichero.
        {
            this.nombre = nombre;
        }

        public void Guardar(List<Libro> objeto) // Para guardar en el fichero
        {
            arrayLibros = objeto.ToArray(); // La lista que traemos la pasamos a un array.
            IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream(nombre, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, arrayLibros); // Guardamos el array
            stream.Close();
        }

        public List<Libro> Cargar() // Para cargar del fichero.
        {
            IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream(nombre, FileMode.Open, FileAccess.Read, FileShare.Read);
            arrayLibros = (Libro[])formatter.Deserialize(stream); // Cargamos un array
            stream.Close();
            List<Libro> objeto = arrayLibros.ToList<Libro>(); // Pasamos el array a lista
            return objeto; // Lo que devolvemos es pues, una lista.
        }
    }
}
