using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

    /*
    (12.6.2) Crea un programa básico de chat, en el que dos usuarios puedan comunicarse, sin necesidad de seguir turnos estrictos.
    */
namespace Ejercicio_12_6_2
{
    class Program
    {
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

        public static void ConectarRecepcion(int puertoEnvia, int puertoRecibe)
        {
            bool ok = false;
           // Console.WriteLine("Entra en recibir");
            IPAddress direccionIP = Dns.GetHostEntry(direccionPrueba).AddressList[0];
            listener = new TcpListener(direccionIP, puertoRecibe);
            //Console.WriteLine("PuertoRecibe vale {0}", puertoRecibe);
           // Console.WriteLine("Antes de listener.Start");
            listener.Start();
            do
            {
                if (listener.Pending())
                {
                    clienteRecibe = listener.AcceptTcpClient();
                    //Console.WriteLine("Después de cliente");
                    conexionRecibir = clienteRecibe.GetStream();
                    Console.WriteLine("Conectado para recibir");
                    ok = true;
                }
            }
            while (ok == false);
        }
        public static void ConectarEnvio(int puertoEnvia, int puertoRecibe)
        {
            bool ok = false;
            Console.WriteLine("Conectando para enviar...");
            //Console.WriteLine("PuertoEnvia vale {0}", puertoEnvia);
            do
            {
                clienteEnvia = new TcpClient(direccionPrueba, puertoEnvia);
                conexionEnvio = clienteEnvia.GetStream();
                ok = true;
            }
            while (ok == false);
            Console.WriteLine("Conectado");
        }

        public static void Enviar(string texto)
        {
            byte[] secuenciaLetras = Encoding.ASCII.GetBytes(texto + "\n");//Muy importante el "\n", si no, el listener en recibir se queda colgado
            conexionEnvio.Write(secuenciaLetras, 0, secuenciaLetras.Length);
            //conexion.Close();
            //cliente.Close();
        }
        public static string Recibir()
        {
            string linea = null;

            if (conexionRecibir.DataAvailable)
            {
                Console.WriteLine("Leyendo...");
                //listener.Stop();
                StreamReader lector = new StreamReader(conexionRecibir);
                //Console.WriteLine("ConexionRecibir vale {0}", conexionRecibir);
                //Console.WriteLine("Aqui te quedas");
                linea = lector.ReadLine();
                //Console.WriteLine("Aqui has pasado");
            }
            return linea;
        }
        static void Main(string[] args)
        {
            string comentario;
            bool salir = false;
            bool usuarioCorrecto = false;
            string usuario;
            string recibido;
            //ConsoleKeyInfo tecla;
            Console.WriteLine("Escribe \"salir\" para salir del programa");
            do
            {
                Console.WriteLine("Indica si eres el usuario 1 o el usuario 2");
                usuario = Console.ReadLine();
                if (usuario == "1" || usuario == "2")
                    usuarioCorrecto = true;
                else
                    Console.WriteLine("Debes indicar \"1\" o \"2\"");
            }
            while (usuarioCorrecto == false);

            if (usuario == "1")
            {
                puertoPruebaEnvia = puertoPrueba1;
                puertoPruebaRecibe = puertoPrueba2;
                ConectarRecepcion(puertoPruebaEnvia, puertoPruebaRecibe);
                ConectarEnvio(puertoPruebaEnvia, puertoPruebaRecibe);
            }
            else
            {
                puertoPruebaEnvia = puertoPrueba2;
                puertoPruebaRecibe = puertoPrueba1;
                ConectarEnvio(puertoPruebaEnvia, puertoPruebaRecibe);
                ConectarRecepcion(puertoPruebaEnvia, puertoPruebaRecibe);
            }
            do
            {
               // Console.WriteLine("Principio do/While del main");
                if (Console.KeyAvailable)
                {
                    comentario = Console.ReadLine();

                    if (comentario == "salir")
                    {
                        salir = true;
                    }
                    else
                    {
                        Console.WriteLine("Justo antes de enviar");
                        Enviar(comentario);
                        Console.WriteLine("Justo después de enviar");
                    }
                }
                //else
               // {
                     //Console.WriteLine("Justo antes de Recibir2");
                    recibido = Recibir();
                    if(recibido != null)
                        Console.WriteLine(recibido);
                   // Console.WriteLine("Justo después de Recibir2");
                //{ 
            }
            while (salir == false); 
        } 
    }
}
