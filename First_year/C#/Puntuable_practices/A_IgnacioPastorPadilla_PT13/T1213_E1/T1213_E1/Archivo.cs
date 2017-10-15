using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ignacio Pastor Padilla - Ejercicio 1, Práctica Tema 13 - 1º DAM Semipresencial Grupo-A

    //Clase que caracteriza y gestiona las características del objeto Archivo

namespace T1213_E1
{
    class Archivo
    {
        public Archivo()
        {

        }
        private string nombre;
        private long tamanyo;
        private DateTime fecha;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public long Tamanyo
        {
            get { return tamanyo; }
            set { tamanyo = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

    }
}
