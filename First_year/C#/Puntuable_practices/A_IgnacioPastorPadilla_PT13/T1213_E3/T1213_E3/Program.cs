using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Ignacio Pastor Padilla - Ejercicio 3, Práctica Tema 13 - 1º DAM Semipresencial Grupo-A

    /*
    Se nos pide conectar dos ordenadores, y hacer un programa donde un Jugador elige un número y el otro tiene que intentar adivinarlo.
    El primer jugador informa de si el número elegido es mayor o menor que el propuesto. Si miente, el programa lo detecta y se cierra.
    */

namespace T1213_E3
{
    class Program
    {
        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------GESTION CONEXION ENTRE AMBOS ORDENADORES---------------------------------------------
        static NetworkStream conexionRecibir;
        static NetworkStream conexionEnvio;
        static TcpListener listener;
        static TcpClient clienteRecibe;
        static TcpClient clienteEnvia;
        static string direccionPrueba = "localhost";
        static int puertoPruebaEnvia;
        static int puertoPruebaRecibe;
        static int puertoPrueba1 = 2112;
        static int puertoPrueba2 = 1221;

        public static void ConectarRecepcion(int puertoRecibe)//Conectamos para ruta de recepción
        {
            bool ok = false;
            IPAddress direccionIP = Dns.GetHostEntry(direccionPrueba).AddressList[0];
            listener = new TcpListener(direccionIP, puertoRecibe);
            listener.Start();
            do
            {
                if (listener.Pending())
                {
                    clienteRecibe = listener.AcceptTcpClient();
                    conexionRecibir = clienteRecibe.GetStream();
                    ok = true;
                }
            }
            while (ok == false);
        }
        public static void ConectarEnvio(int puertoEnvia)//Conectamos para ruta de envío
        {
            bool ok = false;
            do
            {
                clienteEnvia = new TcpClient(direccionPrueba, puertoEnvia);
                conexionEnvio = clienteEnvia.GetStream();
                ok = true;
            }
            while (ok == false);
            Console.WriteLine("Conectado");
        }

        public static void Enviar(string texto) //Gestión de envios
        {
            byte[] secuenciaLetras = Encoding.ASCII.GetBytes(texto + "\n");//Muy importante el "\n", si no, el listener en recibir se queda colgado
            conexionEnvio.Write(secuenciaLetras, 0, secuenciaLetras.Length);
        }
        public static string Recibir()//Gestión de recepción
        {
            string linea = null;

            if (conexionRecibir.DataAvailable) //Si hay datos disponibles, los leemos
            {
                StreamReader lector = new StreamReader(conexionRecibir);
                linea = lector.ReadLine();
            }
            return linea;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------ GESTION PARTIDA -------------------------------------------------------------------

        public static bool InvertirEsperarRespuesta(bool aEsperarRespuesta) //Gestiona los turnos, cuando no es tu turno y dices algo,
        {                                                                  //salta mensaje de que debes esperar
            if (aEsperarRespuesta == true)
                return false;
            else
                return true;
        }
        public static string SupervisarRespuesta(string aRespuesta, int aRecibido, int aNumero) //Controla que el jugador 1 no mienta
        { //Si dice algo distinto a mayor, menor o correcto, o lo que dice no corresponde con la verdad, lo detecta y finaliza el programa previo mensaje
            if (((aRespuesta.ToUpper() == "MAYOR") && (aRecibido < aNumero)) 
                || ((aRespuesta.ToUpper() == "MENOR") && (aRecibido > aNumero)) 
                || ((aRespuesta.ToUpper() == "CORRECTO") && (aRecibido == aNumero)))
            {

                return aRespuesta; //Devuelve la respuesta original si es legítima
            }
            else
            {
                return ("El Jugador 1 ha intentado hacer trampas!"); //Devuelve otra respuesta si ha mentido. Posteriormente controlaré que la respuesta
                //que da el Jugador 1, y la respuesta supervisada son iguales. Si no, se entiende que ha mentido y finaliza programa
            }
        }
        public static bool EsEnteroValido(string aComentario) //Controlamos que el Jugador 2 envía un entero como propuesta de acierto.
        {
                try
                {
                    int n = Convert.ToInt32(aComentario);
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------MAIN DEL PROGRAMA---------------------------------------------------------
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            bool problemaConexion = false;
            string respuestaSupervisada;
            bool numeroCorrecto;
            bool esperarRespuesta;
            var comentario = "";
            bool salir = false;
            bool usuarioCorrecto = false;
            string usuario;
            var recibido = "";
            var recibidoEstable = "";
            int numero = 0;

            do   //Primero hacemos un do/while para preguntar si nos conectamos como usuario 1 o como usuario 2.
            {    //Cualquier otra opción no se acepta y se vuelve a pedir
                Console.WriteLine("Indica si eres el usuario 1 o el usuario 2");
                usuario = Console.ReadLine();
                if (usuario == "1" || usuario == "2")
                    usuarioCorrecto = true;
                else
                    Console.WriteLine("Debes indicar \"1\" o \"2\"");
            }
            while (usuarioCorrecto == false);
            try    //Conectamos al Usuario 1 con el Usuario 2. Si la primera conexión se hace como usuario 2 el programa lanzará una excepción.
            {       // La capturamos, lanzamos un mensaje informativo del problema, decimos que conecte primero como Usuario 1 y finalizamos programa.
                if (usuario == "1")    //Asignamos a cada usuario un puerto e envío y un puerto de recepción. El envío del Usuario 1 será el recepción del usuario 2
                {
                    puertoPruebaEnvia = puertoPrueba1;
                    puertoPruebaRecibe = puertoPrueba2;
                    ConectarRecepcion(puertoPruebaRecibe);
                    ConectarEnvio(puertoPruebaEnvia);
                }
                else
                {
                    puertoPruebaEnvia = puertoPrueba2;
                    puertoPruebaRecibe = puertoPrueba1;
                    ConectarEnvio(puertoPruebaEnvia);
                    ConectarRecepcion(puertoPruebaRecibe);
                }
            }
            catch (Exception e)
            {
                problemaConexion = true;
                Console.WriteLine(e.Message);
            }
            if (problemaConexion == false) // Si no ha habido problemas en la conexión, empezamos con el juego.
            {                               //Primero lanzamos un mensaje distinto a cada Jugador donde damos información sobre el juego.
                if (usuario == "2") // Mensaje para el Jugador 2
                {
                    esperarRespuesta = true;
                    Console.WriteLine("Eres el Jugador 2, el otro jugador elegirá un número y tú tendrás que intentar adivinarlo.");
                    Console.WriteLine("Prueba diciéndole un número, y el oponente te contestará si el número a acertar es mayor o menor");
                }
                else // Mensaje para el Jugador 1
                {
                    esperarRespuesta = false;
                    Console.WriteLine("Eres el Jugador 1, elige un número y el Jugador 2 intentará adivinarlo.");
                    Console.WriteLine("Indica si el número a acertar es \"Mayor\", \"Menor\" que el número indicado");
                    Console.WriteLine("Indica \"Correcto\" si ha acertado");
                    Console.WriteLine("Pero cuidado, si intentas hacer trampas nos daremos cuenta!");

                    do // Pedimos al Jugador 1 que introduzca el número que el Jugador 2 deberá adivinar. Si el número no es válido, voveremos a pedírselo.
                    {
                        numeroCorrecto = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Introduce el número a adivinar: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        try // Controlamos que el número que introduce es válido y capturamos posibles excepciones. Si no es válido lo pediremos reiterativamente
                        {
                            numero = Convert.ToInt32(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Red;

                            Enviar("Ya se ha elegido un numero. Intenta adivinarlo!");
                            esperarRespuesta = InvertirEsperarRespuesta(esperarRespuesta);
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("No es un número válido");
                            Console.WriteLine("Debes introducir un número entero entre -2147483648 y 2147483647");
                            numeroCorrecto = false;
                        }
                        
                    }
                    while (numeroCorrecto == false);
                }
                do   //do/while propiamente del juego. 
                {
                    if (Console.KeyAvailable) // Detectamos cuándo se está escribiendo para leer.
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Tu: ");
                        comentario = Console.ReadLine(); //Leemos el comentario
                        Console.ForegroundColor = ConsoleColor.Red;

                        
                        if (usuario == "2" && EsEnteroValido(comentario) == false) // En caso de que el Jugador 2 proponga un número no válido, volvemos a pedírselo
                        {
                            Console.WriteLine("Debes introducir un número entero entre -2147483648 y 2147483647");
                        }
                        else //Si el número es válido, seguimos adelante
                        {
                            if (esperarRespuesta == false) //Si es nuestro turno...
                            {
                                if (usuario == "1") //Si eres el Jugador 1...
                                {   //Supervisamos que no esté mintiendo
                                    respuestaSupervisada = SupervisarRespuesta(comentario, Convert.ToInt32(recibidoEstable), numero);

                                    Enviar(comentario); //Enviamos el comentario original

                                    if (comentario != respuestaSupervisada)   //Comprobamos si el comentario original es igual a nuestra respuesta supervisada
                                    {
                                        Console.WriteLine("Has intentado hacer trampas!");  //Si no es igual, es que hemos mentido, y se envía un mensaje
                                        Enviar(respuestaSupervisada);   //informando de que se ha mentido. 
                                        salir = true; //Finalizamos el programa.
                                    }
                                    else if (comentario.ToUpper() == "CORRECTO") // Si no se ha mentido, y la respuesta es Correcto. Entendemos que se ha acertado
                                    {
                                        salir = true; //Salimos del programa
                                        Console.WriteLine("El Jugador 2 ha acertado. Fin de la Partida.");
                                    }
                                }
                                else //Si eres el jugador 2, enviamos el comentario (ya filtrada su validez antes de intentar enviarlo) e invertimos turno
                                    Enviar(comentario);
                                esperarRespuesta = InvertirEsperarRespuesta(esperarRespuesta); // Una vez se ha enviado el comentario, invertimos el turno
                            }
                            else
                                Console.WriteLine("Debes esperar respuesta del otro jugador"); // Caso de que digas algo y no sea tu turno, no se envía y se
                        }                                                                      // informa de que debes esperar a que sea tu turno
                    }
                    recibido = Recibir(); //Continuamente estamos recibiendo (estamos en un bucle)

                    if (recibido != null) //Si lo que recibimos no es nulo...
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (usuario == "2" && ((recibido.ToUpper() == "CORRECTO") || (recibido.ToUpper() == "MAYOR") || (recibido.ToUpper() == "MENOR")))
                        {
                            Console.Write("Jugador 1:  ");  // Si somos el Jugador 2, y se nos envía info válida, la imprimimos. Antemponemos que eso que
                            Console.WriteLine(recibido);    // estamos imprimiendo lo dice el otro jugador
                        }
                        else if (usuario == "1") // Si somos el jugador 1, antes de imprimir lo que dice el jugador dos anteponemos una cadena informando
                        {                           //  de que eso lo dice el otro jugador
                            Console.Write("Jugador 2: ");
                            Console.WriteLine(recibido);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(recibido);
                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        recibidoEstable = recibido; //Para controlar que lo que propone el jugador 2 es o no cierto, necesitamos guardarlo en una variable
                        //nueva, ya que "recibido" se va actualizando a null cada vuelta de bucle. Así que cuando se ha propuesto algo, lo guardamos aquí
                        esperarRespuesta = InvertirEsperarRespuesta(esperarRespuesta); // Invertimos turno
                        // En caso de que seamos el Jugador 2, y recibamos "Correcto" o que el Jugador 1 ha hecho trampas, decimos que has ganado y fin programa
                        if (usuario == "2" && ((recibido.ToUpper() == "CORRECTO") || (recibido == "El Jugador 1 ha intentado hacer trampas!")))
                        {
                            Console.WriteLine("Has ganado!!");
                            salir = true;
                        }
                    }
                }
                while (salir == false);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Reinicia el programa y conecta primero el Usuario 1");   // En caso de problema de conexión, fin programa y mensaje.
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
