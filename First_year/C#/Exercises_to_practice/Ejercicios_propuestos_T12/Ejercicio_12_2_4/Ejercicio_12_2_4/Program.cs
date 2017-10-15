using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - DAM Semi A

/* 
(12.2.4) Crea una versión del programa de "dibujar" en consola (12.2.3), que permita escribir más caracteres
(por ejemplo, las letras), así como mostrar ayuda (pulsando F1), guardar el contenido de la pantalla en un fichero de texto
(con F2) o recuperarlo (con F3).

    (12.2.3) Crea un programa que permita "dibujar" en consola, moviendo el cursor con las flechas del teclado y
    pulsando "espacio" para dibujar un punto o borrarlo.
*/
namespace Ejercicio_12_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dibujar d = new Dibujar();
            d.Proceso();
        }
    }
}
