using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - Proyecto Final Programación - 1º DAM Semipresencial - Grupo A

// Esta clase caracteriza el objeto Ranking. Se compone por una puntuación, nombre y fecha.
// Lo utilizaremos para guardar las distintas y mejores puntuaciones

namespace Tetris2
{
    [Serializable]
    class Ranking
    {
        string nombre; // Nombre del jugador
        int puntuacion;
        DateTime fecha; // Fecha de la partida

        public Ranking(string nombre, int puntuacion, DateTime fecha)
        {
            this.nombre = nombre;
            this.puntuacion = puntuacion;
            this.fecha = fecha;
        }
        public Ranking()
        {

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

        public int Puntuacion
        {
            get
            {
                return puntuacion;
            }
            set
            {
                puntuacion = value;
            }
        }
        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
            }
        }

    }
}
