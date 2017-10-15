using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Crea un proyecto llamado SaludoColor que tenga una enumeración con algunos colores básicos 
(por ejemplo, ROJO, VERDE, AZUL y AMARILLO). Le pediremos al usuario que indique uno de estos cuatro colores, y le mostraremos un saludo en ese color elegido.
Para ello, deberemos convertir el texto que escriba el usuario (por ejemplo, "AZUL") en el tipo enumerado correspondiente (AZUL). 
Busca en Internet cómo hacerlo (echa un vistazo al método Enum.Parse). Después, con una estructura switch..case o similar, cambiaremos al color elegido, 
y mostraremos un saludo "Hola" o similar, en ese color.
*/
namespace SaludoColor
{
    class Program
    {
        enum colores { ROJO, VERDE, AZUL, AMARILLO };

        static void Main(string[] args)
        {
            bool peta = false;
            string respuesta;
            Console.WriteLine("Indica un color (amarillo, rojo, verde, azul)");
            respuesta = Console.ReadLine();
            colores colorRespuesta;
            try
            {
                colorRespuesta = (colores)Enum.Parse(typeof(colores), respuesta.ToUpper());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                peta = true;
                colorRespuesta = colores.AMARILLO;
            }
            if (peta == false)
            {
                switch (colorRespuesta)
                {
                    case colores.AMARILLO:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Hola, este es el color que has indicado");
                        break;
                    case colores.AZUL:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Hola, este es el color que has indicado");
                        break;
                    case colores.ROJO:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Hola, este es el color que has indicado");
                        break;
                    case colores.VERDE:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Hola, este es el color que has indicado");
                        break;
                    default:
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
