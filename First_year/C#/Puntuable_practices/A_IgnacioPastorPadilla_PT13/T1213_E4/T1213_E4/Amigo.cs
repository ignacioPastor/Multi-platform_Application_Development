using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ignacio Pastor Padilla - Ejercicio 4, Práctica Tema 13 - 1º DAM Semipresencial Grupo-A

// Esta clase caracteriza y gestiona las características de los Amigos que vamos a guardar en la agenda

namespace T1213_E4
{
    class Amigo
    {
        private string nombre;
        private string telefono; // El teléfono lo almacenamos en un string para controlar los eventuales prefijos internacionales (Ej: +34 123456789)
        private DateTime fechaNacimiento;
        private DateTime fechaActual;

        public Amigo()
        {

        }
        public Amigo(string nombre, string telefono, DateTime fechaNacimiento)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.fechaNacimiento = fechaNacimiento;
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }
        public string Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
            }
        }
        public DateTime FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }
            set
            {
                fechaNacimiento = value;
            }
        }
        public int DiasCumple 
        {
            get
            {
                return CalcularDiasCumple(); // Los días que faltan para el próximo cumpleaños los calcularemos cada vez que nos lo pregunten
            }
        }
        
        public int CalcularDiasCumple()
        {
            fechaActual = DateTime.Today;
            if (fechaActual.DayOfYear < fechaNacimiento.DayOfYear)
            {
                return fechaNacimiento.DayOfYear - fechaActual.DayOfYear + 1; //Dia del año de nacimiento + dia año actual + 1 para que asemeje a cómo lo entendemos
            }
            else if (fechaActual.DayOfYear > fechaNacimiento.DayOfYear)
                return 365 - fechaActual.DayOfYear + fechaNacimiento.DayOfYear + 1; // Dias de un año  - dia año actual + dia año nacimiento + 1
            else
                return 0 + 1; // Si mañana es tu cumple falta un día para tu cumpleaños
        }// Nunca devolverá 0 porque tu próximo cumpleaños es dentro de 365 días en caso de que hoy sea tu cumpleaños.
    }
}
