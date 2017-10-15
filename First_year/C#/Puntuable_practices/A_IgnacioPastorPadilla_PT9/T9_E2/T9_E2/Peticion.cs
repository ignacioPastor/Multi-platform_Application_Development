using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - Practica Programación Tema 9 - 1º DAM Semi, Grupo A

// Clase para caracterizar y gestionar las peticiones.

namespace T9_E2
{
    [Serializable]
    class Peticion
    {
        public Peticion()
        {

        }
        const string NOMBRE_LIBROS = "libros.dat"; // Constante para el archivo xml donde está almacenado el catálogo de libros

        private DateTime fechaInicio;
        private DateTime fechaFin;
        private Libro libroPedido; // Para almacenar el libro sobre el que se realiza la petición.
        private List<Libro> catalogo; // Almacena la lista de libros sobre los cuales realizaremos peticiones.

        Serializador s = new Serializador(NOMBRE_LIBROS); // Objeto Serializador para enviar desde aquí la instrucción de cargar catálogo

        public DateTime FechaInicio
        {
            get
            {
                return fechaInicio;
            }
            set
            {
                fechaInicio = value;
            }
        }
        public DateTime FechaFin
        {
            get
            {
                return fechaFin;
            }
            set
            {
                fechaFin = value;
            }
        }
        public List<Libro> Catalogo
        {
            get
            {
                catalogo = s.CargarCatalogo();
                return catalogo;
            }
        }
        public Libro LibroPedido
        {
            get
            {
                return libroPedido;
            }
            set
            {
                libroPedido = value;
            }
        }
        public void CargarCatalogoPet() // Carga el catálogo. Informa de que va a hacerlo, y de que se ha cargado correctamente.
        {
            Console.WriteLine("Cargando catálogo...");
            catalogo = s.CargarCatalogo();
            Console.WriteLine("Catálogo cargado correctamente");
        }

        public void MostrarCatalogo() // Muestra el catálogo
        {
            Console.WriteLine();
            Console.WriteLine("Catálogo:");
            for (int i = 0; i < catalogo.Count; i++)
            {
                Console.WriteLine("{0}. ISBN: {1}; Título: {2}; Autor: {3}; Precio: {4}",
                    i + 1, catalogo[i].Isbn, catalogo[i].Titulo, catalogo[i].Autor, catalogo[i].Precio);
            }
            Console.WriteLine();
        }

        public Libro LibroElegido(int posicion) // Recibe un entero donde se indica la posición en el catálogo del libro elegido. Devuelve ese libro.
        {
            return catalogo[posicion];
        }
    }
}
