using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - Proyecto Final Programación - 1º DAM Semipresencial - Grupo A

// Esta clase gestiona las impresiones y borrados específicos por pantalla

namespace Tetris2
{
    class Sprite
    {
        // Imprime el tablero. Para ello recorremos el tablero, nos fijamos en el color de cada tetraedro
        // y lo imprimimos del color que corresponda. Imprimiremos dos espacios con el fondo de color.
        // Dos espacios porque de esa forma quedan las piezas más cuadradas y proporcionadas. Con esto
        // en realidad se está falseando lo que se ve con lo que hay en realidad.
        public void ImprimirTablero(List<Tetraedro> t)
        {
            for (int k = 0; k < t.Count; k++)
            {// La posición del cursor tendrá en cuenta la ubicación del tablero más la de la posición que toque
                Console.SetCursorPosition(20 + (t[k].X * 2), 5 + t[k].Y);
                SeleccionarColorTetraedro(t[k]);
                Console.Write("  ");
            }
            Console.SetCursorPosition(0, 0); // Cuando terminamos de imprimir ponemos el cursor en una esquina
                                            // para evitar que se quede por ahí en medio
            Console.BackgroundColor = ConsoleColor.Black;
        }
        // Imprime solo la pieza. De esta forma evitamos que todo se esté imprimiendo continuamente.
        // Mejora la eficiencia y evita el parpadeo generalizado de las cosas que vemos en la pantalla
        public void ImprimirPieza(Pieza p)
        {
            for (int i = 0; i < p.Posicion.Length; i++)
            {
                Console.SetCursorPosition(20 + (p.Posicion[i].X * 2), 5 + p.Posicion[i].Y);
                SeleccionarColorTetraedro(p.Posicion[i]);
                Console.Write("  ");
            }
            Console.SetCursorPosition(0, 0); //Apartamos el cursor para que no se vea al lado de la pieza
            Console.BackgroundColor = ConsoleColor.Black;
        }
        // Borra el tetraedo indicado de la pantalla.
        // Lo utilizaremos en cada movimiento de la pieza
        public void BorrarTetraedro(Tetraedro tetra)
        {
            Console.SetCursorPosition(20 + (tetra.X * 2), 5 + tetra.Y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
        }
        // Muestra los tetraedros del tablero. Útil para el programador que quiera corregir bugs
        public void VerTablero(List<Tetraedro> t)
        {
            Console.Clear();
            for (int k = 0; k < t.Count; k++)
            {
                Console.WriteLine("x = {0}, y = {1}, color = {3}", t[k].X, t[k].Y, t[k].AColor);
            }
        }
        // Método para ver las propiedades de la pieza. Útil para el programador que esté depurando fallos.
        public void VerPieza(Pieza p)
        {
            Console.Clear();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("x = {0}, y = {1}", p.Posicion[i].X, p.Posicion[i].Y);
            }
            Console.ReadKey();
        }
        // Imprime la puntuación y el nivel al lado del tablero
        public void ImprimirPanel(int puntuacion, int nivel)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(60, 12);
            Console.WriteLine("Puncuación: {0}", puntuacion);

            Console.SetCursorPosition(60, 14);
            Console.WriteLine("Nivel: {0}", nivel);
            Console.ForegroundColor = ConsoleColor.White;

        }
        // Escribe el texto centrado en la pantalla
        public void EscribirCentrado(string texto)
        {
            int n = (Console.WindowWidth - texto.Length) / 2;
            if (n < 0)
                n = 0;
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(texto);
        }
        // Escribe centrado en la pantalla. Combina distintos colores en una linea
        public void EscribirCentrado(string t1, string t2)
        {
            int n = (Console.WindowWidth - (t1.Length + t2.Length)) / 2;
            if (n < 0)
                n = 0;
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(t1);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(t2);
        }
        // Escribe centrado en la pantalla. Combina distintos colores. Se utilizará para mostrar el ranking
        public void EscribirCentrado(string texto, string texto2, string texto3, int numero, string texto4, DateTime fecha)
        {
            int n = (Console.WindowWidth - (texto.Length + texto2.Length + texto3.Length + 2
                + texto4.Length + fecha.ToShortDateString().Length)) / 2;
            if (n < 0)
                n = 0;
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(texto);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(texto2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(texto3);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(numero);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(texto4);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(fecha.ToShortDateString());
        }
        // Muestra los distintos mensajes que se lanzan durante la partida
        // Incluyen un aderezo gráfico
        public void Mensaje(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(29, 10);
            for (int i = 0; i < 22; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            EscribirCentrado(texto);

            Console.SetCursorPosition(29, 12);
            for (int i = 0; i < 22; i++)
            {
                Console.Write("*");
            }
        }
        // Antes de imprimir un tetraedro ya sea en el tablero o la pieza, lo pasaremos por aquí, así centralizamos en un sitio
        // la identificación del color de cada tetraedro y evitamos duplicaciones de código, con el consiguiente problema de mantenimiento
        public void SeleccionarColorTetraedro(Tetraedro tetra)
        {
            switch (tetra.AColor)
            {
                case Tetraedro.Color.amarillo:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case Tetraedro.Color.azul:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case Tetraedro.Color.blanco:
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                case Tetraedro.Color.cian:
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
                case Tetraedro.Color.gris:
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case Tetraedro.Color.magenta:
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
                case Tetraedro.Color.negro:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case Tetraedro.Color.rojo:
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case Tetraedro.Color.verde:
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
            }
        }
    }
}
