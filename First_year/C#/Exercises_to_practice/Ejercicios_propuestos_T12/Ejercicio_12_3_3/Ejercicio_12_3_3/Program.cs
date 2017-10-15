using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
(12.3.3) Crea un programa que permita "pasear" por la carpeta actual,
al estilo del antiguo "Comandante Norton": mostrará la lista de ficheros 
y subdirectorios de la carpeta actual, y permitirá al usuario moverse hacia 
arriba o abajo dentro de la lista usando las flechas del cursor. 
El elemento seleccionado se mostrará en color distinto del resto.
*/
namespace Ejercicio_12_3_3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Aplicacion a = new Aplicacion();
            a.LanzarAplicacion();

        }
    }
}
