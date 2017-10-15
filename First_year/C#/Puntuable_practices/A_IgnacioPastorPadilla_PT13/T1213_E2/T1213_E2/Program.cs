using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Ignacio Pastor Padilla - Ejercicio 2, Práctica Tema 13 - 1º DAM Semipresencial Grupo-A

//Crear un programa que pida un usuario (mail) y contraseña. Deberá comprobar que el mail es válido, y que la contraseña tiene
//al menos una letra minúscula, una mayúscula, un número, y un caracter alfanumérico. Pedirá reiterativamente mail y contraseña
//mientras no se cumplan estas condiciones indicando qué ha fallado.

namespace T1213_E2
{
    class Program
    {           //Para gestionar la comprobación de la validez de usuario y contraseña
                //Irá comprobando paso a paso y cortará en el momento en que no se cumpla una condición. Indicando qué es lo que ha fallado
        public static bool ComprobarValidez(string aUsuario, string aContra) 
        {                         
            if (UsuarioValido(aUsuario) == false)
            {
                Console.WriteLine("El usuario no es un correo electrónico válido");
                return false;
            }
            else if(ContraMinus(aContra) == false)
            {
                Console.WriteLine("La contraseña debe tener al menos una letra minúscula");
                return false;
            }
            else if(ContraMayus(aContra) == false)
            {
                Console.WriteLine("La contraseña debe contener al menos una letra mayúscula");
                return false;
            }
            else if(ContraNumero(aContra) == false)
            {
                Console.WriteLine("La contraseña debe contener al menos un número");
                return false;
            }
            else if(ContraCaracterNoAlfanumerico(aContra) == false)
            {
                Console.WriteLine("La contraseña debe contener al menos un carácter no alfanumérico");
                return false;
            }
            else
            {
                Console.WriteLine("Usuario registrado correctamente");
                return true;
            }
        }
        public static bool UsuarioValido(string aUsuario) // Comprueba que el usuario es un mail válido.
        {
            // Cadena alfanumérica, puede que haya un punto en medio, tiene @, cadena alfanumérica,
            // puede que haya un punto en medio, y acaba en punto cadena alfabética en minúsculas
            Regex mail = new Regex(@"\A[a-zA-Z0-9]+[a-zA-Z0-9\.]*@+?[a-zA-Z0-9]+[a-zA-Z0-9\.]*\.?[a-z]+\z"); 
            return mail.IsMatch(aUsuario);
        }
        public static bool ContraMinus(string aContra) // Comprueba que la contraseña tenga al menos una minúscula
        {
            Regex contraMinus = new Regex("[a-z]+");
            return contraMinus.IsMatch(aContra);
        }
        public static bool ContraMayus(string aContra) // Comprueba que la contraseña tenga al menos una mayúscula
        {
            Regex contraMayus = new Regex("[A-Z]+");
            return contraMayus.IsMatch(aContra);
        }
        public static bool ContraNumero(string aContra)
        {
            Regex contraNumero = new Regex("[0-9]+"); // Comprueba que la contraseña tenga al menos un número
            return contraNumero.IsMatch(aContra);
        }
        public static bool ContraCaracterNoAlfanumerico(string aContra) // Comprueba que la contraseña tenga al menos un caracter no alfanumérico
        {
            Regex contraCaracterNoNumerico = new Regex("[^a-zA-Z0-9]+");
            return contraCaracterNoNumerico.IsMatch(aContra);
        }

        static void Main(string[] args)
        {
            bool salirAnidado;
            string usuario, contra;
            ConsoleKeyInfo tecla;
            do
            {
                contra = "";
                salirAnidado = false;
                Console.Write("Usuario: ");
                usuario = Console.ReadLine();
                Console.Write("Contraseña: ");

                do // Hacemos un do/while para que la contraseña no aparezca en la consola mientras se escribe. Capturamos cada caracter con lectura de tecla
                { // usando ReadKey(true), y por cada tecla capturada mostramos un *. La tecla la pasamos a char, y luego a string y la vamos almacenando en 
                    tecla = Console.ReadKey(true);        // un string. Si la tecla es ENTER, salimos del bucle que captura la contraseña.
                    if (tecla.Key == ConsoleKey.Enter)
                        salirAnidado = true;
                    else
                    {
                        Console.Write("*");
                        contra = contra + tecla.KeyChar.ToString();
                    }
                }
                while (salirAnidado == false);
                Console.WriteLine();
            }
            while (!ComprobarValidez(usuario, contra)); // Mientras el mail y la contraseña no sean válidos los pedirá reiterativamente
        }
    }
}
