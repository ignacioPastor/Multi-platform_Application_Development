using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - Practica Programación Tema 9 - 1º DAM Semi, Grupo A

// Esta clase es la misma que la del Ejercicio 1. Caracteriza el objeto Libro y alberga sus atributos y propiedades

namespace T9_E2
{
    [Serializable]
    class Libro
    {
        private string isbn;
        private string titulo;
        private string autor;
        private float precio;

        public Libro()
        {

        }
        public string Isbn
        {
            set
            {
                isbn = value;
            }
            get
            {
                return isbn;
            }
        }
        public string Titulo
        {
            set
            {
                titulo = value;
            }
            get
            {
                return titulo;
            }
        }
        public string Autor
        {
            set
            {
                autor = value;
            }
            get
            {
                return autor;
            }
        }
        public float Precio
        {
            set
            {
                precio = value;
            }
            get
            {
                return precio;
            }
        }
    }
}
