using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - Proyecto Final Programación - 1º DAM Semipresencial - Grupo A

// Esta clase gestiona la última pantalla que se muestra. Principalmente pide el nombre del usuario y gestiona el ranking

namespace Tetris2
{
    class PantallaFinal
    {
        string nombreUsuario;
        Ranking user;
        Ranking temporal;
        Ranking[] ranking = new Ranking[6]; // Creamos un array de ranking de 6. Solo mostraremos 5
        Serializador se = new Serializador();
        string FICHERO_RANKING = "ranking.dat"; // Nombre del fichero donde se almacenarán las mejores puntuaciones
        Sprite s = new Sprite();
        DateTime fecha;

        public PantallaFinal()
        {

        }
        // Pedimos el nombre al usuario
        public void PedirDatos(int puntos) // Recibimos la puntuación conseguida por el usuario
        {
            Console.Clear();
            for (int i = 0; i < 7; i++)
                Console.WriteLine();
            fecha = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Red;
            s.EscribirCentrado("Fin de la partida!");
            Console.WriteLine();
            s.EscribirCentrado("Introduce tu nombre");
            Console.SetCursorPosition(37, 10);

            nombreUsuario = Console.ReadLine(); //Almacenamos el nombre del usuario en una variable string
            Console.Clear();
            user = new Ranking(nombreUsuario, puntos, fecha); // Creamos un nuevo objeto Ranking, con el nombre de usuario introducido y la puntuación recibida
            ComprobarRanking(); // Llamamos al archivo ranking 
        }
        // Mira el ranking guardado en el fichero
        public void ComprobarRanking()
        {
            try
            {
                ranking = se.CargarRanking(FICHERO_RANKING); // Carga el ranking.
            }
            catch
            {
                InicializarVacioRanking(); // Si el fichero no existe o hay un error, inicializa el ranking a vacío
            }

            ranking[5] = user; // Metemos la nueva puntuación y nombre en la sexta posición.
            OrdenarRanking(); // Ordenamos el array
            se.GuardarRanking(ranking, FICHERO_RANKING); // Guardamos el array
            MostrarRanking(); // Mostramos el array. El funcionamiento es que solo mostramos las mejores 5 puntuaciones. No obstante, trabajamos con un
            // array de 6 posiciones. Como lo guardamos ordenado, la última posición siempre la machacaremos, porque no nos interesa. La última posición
            // es la última puntuación realizada, o la actual, nunca una de las 5 mejores puntuaciones. Simplemente mostraremos las 5 primeras.
        }
        // Ordenamos el array por puntuación más alta
        public void OrdenarRanking()
        {
            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (ranking[i].Puntuacion < ranking[i + 1].Puntuacion)
                    {
                        temporal = ranking[i];
                        ranking[i] = ranking[i + 1];
                        ranking[i + 1] = temporal;
                    }
                }
            }
        }
        // Muestra el ranking por pantalla
        public void MostrarRanking()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 7; i++)
                Console.WriteLine();

            s.EscribirCentrado("Ranking:");
            for (int i = 0; i < 5; i++) // Imprimimos las 5 mejores puntuaciones. La recien realizada por el usuario estará aquí si ha entrado en el ranking
            {
                s.EscribirCentrado("Nombre: ", ranking[i].Nombre, "; Puntuacion: ", ranking[i].Puntuacion, "; Fecha: ", ranking[i].Fecha);
            }
            Console.WriteLine();

            s.EscribirCentrado("Tu partida: " + user.Nombre + "; Puntos: " + user.Puntuacion); // Mostramos la puntuación recien realizada por el usuario
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey(true); // Para que el texto "Pulse tecla para finalizar programa..." no nos fastide la imagen,
                                   // esperamos que el usuario pulse una tecla para salir definitivamente del programa
            Console.Clear();
        }
        // Caso de error o que no exista el archivo de ranking, inicializamos el array con valores iniciales.
        public void InicializarVacioRanking()
        {
            ranking = new Ranking[6];
            
            for (int i = 0; i < 6; i++)
            {
                ranking[i] = new Ranking("Vacío", 0, new DateTime(1, 1, 1));
            }
        }

    }
}
