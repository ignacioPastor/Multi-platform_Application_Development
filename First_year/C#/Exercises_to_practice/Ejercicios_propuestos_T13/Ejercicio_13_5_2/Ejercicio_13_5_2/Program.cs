using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
(13.5.2) Crea una función que diga si una cadena que se le pase como parámetro parece un correo electrónico válido.
*/

namespace Ejercicio_13_5_2
{
    class Program
    {
        public static bool EsMail(string cadena)
        {
            Regex mail = new Regex(@"\A[a-zA-Z0-9]+@+?[a-zA-Z0-9]+\.+?[a-zA-z]+\z"); //Como lo he resuelto yo
           // Regex mail = new Regex("\\A[0-9a-zA-Z\\._]+@[0-9a-zA-Z_]+[0-9a-zA-Z\\._]*\\.[a-z]+\\z"); //Como lo ha resuelto el profesor
            return mail.IsMatch(cadena);
        }
        static void Main(string[] args)
        {
            string respuesta;
            bool salir = false;
            do
            {
                Console.WriteLine("Introduce un correo electrónico");
                respuesta = Console.ReadLine();
                if (EsMail(respuesta) == true)
                    Console.WriteLine("Es un mail válido");
                else
                    Console.WriteLine("No es un mail válido");
                if (respuesta == "salir")
                salir = true;
            }
            while (salir == false);
        }
    }
}
