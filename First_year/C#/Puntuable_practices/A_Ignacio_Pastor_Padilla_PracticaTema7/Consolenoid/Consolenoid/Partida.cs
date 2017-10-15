using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; //Instrucción para poder utilizar el Thread.Sleep más adelante
//Aquí se controla la partida, se mueve la nave, cordinamos el movimiento y destrucción de los elementos así como qué se dibuja en cada momento
namespace Consolenoid
{
    class Partida
    {
        ConsoleKeyInfo tecla;
        Nave n = Singleton.GetNave(); //Objeto Nave, mediante Singleton para poder utilizar el mismo objeto en otras clases sin violar encapsulación
        Pelota p = new Pelota(); // Objeto Pelota
        BloqueLadrillos ladrillos1 = new BloqueLadrillos();//Objeto Bloque de Ladrillos
        int vidas = 5;// He optado por poner 5 vidas, no se especifica en la práctica, pero en el ejemplo se ven 3; me parecían pocas cuando he jugado
        bool continuar = true; //Para controlar la salida del bucle (partida)
        bool mostrarContador = false;
        int nivel = 1; //Con esta variable controlaremos el nivel en el que estamos, habrá 4 niveles de dificultad
       
        public void SetVidas(int vidas)
        {
            this.vidas = vidas;
        }
        public void RestarVida()
        {
            vidas -= 1;
        }
        public int  GetVidas()
        {
            return vidas;
        }
        public bool TocarSuelo()  //Caso de que la pelota supere la nave y toque el suelo, restamos una vida y devolvemos true
        {
            if (p.GetY() == 29)
            {
                RestarVida();
                return true;
            }
            else
                return false;
        }
        public void RestablecerPelotaNave()//Para poner la nave y la pelota en su posición original y centrada
        {
            n.SetX(40 - n.GetImagen().Length / 2);
            p.SetX(n.GetX() + n.GetImagen().Length / 2);
            p.SetY(n.GetY() - 1);
        }
        public void MostrarVidas() //Para mostrar la vida antes de empezar cada partida o pelota
        {
            Console.Clear();
            n.Dibujar();
            p.Dibujar();
         
            ladrillos1.Dibujar();
            EscribirCentroPantalla("Nivel: ", -1, nivel);
            EscribirCentroPantalla("Puntuación: ", 0, p.GetPuntuacion());
            EscribirCentroPantalla("Numero de vidas ", 1, vidas);
            Console.SetCursorPosition(0, 0);//Para que lo que eventualmente se escriba quede donde los ladrillos y sea tapado, en medida de lo posible
            //Este do/while es el que se lanza dentro del bucle, cuando ya jugando se empieza desde posición inicial porque pelota ha tocado suelo
            do // Para que se quede parado el juego en la posición inicial hasta que se pulse barra espaciadora
            {
                tecla = Console.ReadKey();
                ladrillos1.Dibujar();//Dibujo ladrillos porque si no se pulsa barra espaciadora, y se pulsan letras y cosas así, afean la pantalla
            }                        // y se nota que no es un juego sino un espacio de texto
            while (tecla.Key != ConsoleKey.Spacebar);
           // Console.ReadKey();
        }
        public void InicializarBloqueLadrillos() //Para volver a construir el bloque de ladrillos entero
        {
            ladrillos1.RestablecerBloqueLadrillos();
        }
        public void FinPartida() //Esta pantalla saltará cuando se finalice el juego (no queden vidas, y no se haya superado el último nivel, el 4)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            EscribirCentroPantalla("FIN DEL JUEGO",-2);
            EscribirCentroPantalla("Puntuación: ", 1, p.GetPuntuacion());
            EscribirCentroPantalla("Pulsa cualquier tecla para continuar", 0);
            Console.ResetColor();
            Console.ReadKey();
            nivel = 1;//Aprovechamos y en el momento de acabar la partida restablecemos los valores de todos los elementos, ladrillos, pelota, nave, vidas, etc
            RestablecerPelotaNave();
            InicializarBloqueLadrillos();
            SetVidas(5);
            continuar = true;
            p.SetPuntuacion(0);
        }
        public void Lanzar()//Aquí propiamente tenemos la partida. Se lanza aquí, y se entra en un bucle que da sensación de movimiento
        {
            
            EscribirCentroPantalla("Nivel: ",-2, nivel); //En el momento de empezar a jugar una pelota, se muestra en pantalla el nivel, puntos 
            EscribirCentroPantalla("Puntuación: ", -1, p.GetPuntuacion()); //y vidas que nos quedan
            EscribirCentroPantalla("Numero de vidas: ", 0, vidas);
            Console.ForegroundColor = ConsoleColor.Yellow;
            EscribirCentroPantalla("Cuidado! Los ladrillos amarillos son el doble de resistentes!", 1);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            EscribirCentroPantalla("Recuerda, pulsa barra espaciadora para empezar!", 2);
            Console.ResetColor();
            n.Dibujar();//Dibujamos la nave, los ladrillos y la pelota. Estamos dibujando antes de entrar en el bucle, será la primera
            ladrillos1.Dibujar(); //  imagen previa a comenzar el movimiento
            p.Dibujar();

            do // Para que se quede parado el juego en la posición inicial hasta que se pulse barra espaciadora
            {
                tecla = Console.ReadKey();
                ladrillos1.Dibujar();//Dibujo ladrillos porque si no se pulsa barra espaciadora, y se pulsan letras y cosas así, afean la pantalla
            }                        // y se nota que no es un juego sino un espacio de texto
            while (tecla.Key != ConsoleKey.Spacebar);

            do //Empieza el bucle que se repetirá en cada juego de pelota
            {
                if (Console.KeyAvailable) //Para dar sensacción de movimiento, comprobamos si hay una tecla disponible, 
                {                          // si la hay la leemos, si no; seguimos adelante en el bucle
                    tecla = Console.ReadKey();

                    if (tecla.Key == ConsoleKey.RightArrow)//Si se pulsa tecla, movemos nave o salimos de la partida, según se indique
                        n.MoverDerecha();
                    if (tecla.Key == ConsoleKey.LeftArrow)
                        n.MoverIzquierda();
                    if (tecla.Key == ConsoleKey.Escape)
                        continuar = false;
                }
                if (mostrarContador == true)//Para mostrar el contador, lo utilizaremos para mostrar las vidas antes de empezar una pelota, 
                    MostrarVidas();
                //Dentro del bucle, a cada pasada tenemos que limpiar la pantalla y dibujar todos los elementos en su nueva posición y situación
                Console.Clear();
                p.MoverPelota();
                ladrillos1.Dibujar();
                n.Dibujar();
                p.Dibujar();
                mostrarContador = false;//Para restablecer el valor de mostrarContador y que solo esté activo en los momentos deseados
                if (TocarSuelo() == true)//Comprobamos si se ha tocado el suelo, rebasando a la nave
                {
                    n.ComboTocarSuelo();//Si ha tocado suelo, hacemos un efecto visual en la nave
                    if (vidas == 0)//Si no quedan vidas, no seguimos en el bucle y salimos así de la partida
                        continuar = false;
                    else
                    {
                        RestablecerPelotaNave();//Si quedan aún vidas, ponemos pelota y nave en posición inicial, mostramos vidas, puntuacion y jugamos
                        mostrarContador = true;
                    }
                }
                if (ladrillos1.TodosLadrillosRotos() == true)//Vemos si están todos los ladrillos ya rotos
                {
                    continuar = false;//Si lo están, terminamos esta partida
                }
                switch (nivel)//Con esto controlaremos el funcionamiento de la partida en cada nivel. Cada nivel implica mayor velocidad en la pelota
                {
                    case 1: //Nivel 1
                        Thread.Sleep(50); //La velocidad del movimiento de la pelota la controlamos con Thread.Sleep e indicando el tiempo que debe
                        break;            //quedarse aquí "dormido", esperando, la ejecución del programa antes de seguir adelante y generando el bucle.
                    case 2: //Nivel 2     //Así, controlamos que el bucle no se ejecute tan rápido como permita nuestro procesador, sino a la velocidad
                        Thread.Sleep(40); //que a nosotros nos interesa en cada momento.
                        break;
                    case 3: //Nivel 3
                        Thread.Sleep(30);
                        break;
                    case 4: //Nivel 4
                        Thread.Sleep(20);
                        break;
                    default:
                        break;
                }
            }
            while (continuar == true);//La condición de salida será un bool, así podemos salir tanto con tecla ESC, vidas=0 como por destruir todos los ladrillos
            if(ladrillos1.TodosLadrillosRotos() == true)//Caso de que hayamos salido por destruir todos los ladrillos, lanzamos pantalla de felicitación
            {                                           // en color verde informamos de que se pasa de nivel
                Console.Clear();
                if (nivel < 4)//Si aún quedan niveles por delante tiramos esta pantalla
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    EscribirCentroPantalla("¡Enhorabuena, pasas al siguiente nivel!", 0);
                    EscribirCentroPantalla("Pulsa una tecla para continuar", 1);
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                }
                nivel++;//Aumentamos el nivel
                if (nivel == 5)
                    FinPartidaVictoriosa();//Si se ha completado el último nivel, lanzamos otra pantalla distinta
                else  //Caso de superar un nivel que no sea el final, restablecemos todos los elementos para iniciar el siguiente nivel
                {
                    tecla = Console.ReadKey();
                    RestablecerPelotaNave();
                    InicializarBloqueLadrillos();
                    SetVidas(5);
                    continuar = true;
                    Lanzar(); //Lanzamos de nuevo la partida con todo restablecido y ya en el siguiente nivel
                }
            }
            else
                FinPartida(); //Si hemos salido de la partida por tecla ESC o vidas = 0, Lanzamos una pantalla distinta de fin de partida
        }
        public void FinPartidaVictoriosa()//Pantalla para mostrar en caso de que hayamos conseguido terminar el juego
        {
            Console.ForegroundColor = ConsoleColor.Green;
            EscribirCentroPantalla("Felicidades, has completado el juego", 0);
            EscribirCentroPantalla("Puntuación = ", 1, p.GetPuntuacion());
            Console.ResetColor();
        }
        public void EscribirCentroPantalla(string texto, int bajarY) //Para escribir en medio de la pantalla
        {
            int espacios = (80 - texto.Length) / 2;
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 14 + bajarY; i++)
                Console.WriteLine();
            for (byte i = 0; i < espacios; i++)
                Console.Write(" ");
            Console.WriteLine(texto);
        }
        public void EscribirCentroPantalla(string texto, int bajarY, int variable) //Para escribir en medio de la pantalla incluyendo una variable
        {
            Console.SetCursorPosition(0, 0);
            int espacios = (80 - texto.Length) / 2;
            for (int i = 0; i < 14 + bajarY; i++)
                Console.WriteLine();
            for (byte i = 0; i < espacios; i++)
                Console.Write(" ");
            Console.WriteLine(texto + variable);
        }
    }
}
