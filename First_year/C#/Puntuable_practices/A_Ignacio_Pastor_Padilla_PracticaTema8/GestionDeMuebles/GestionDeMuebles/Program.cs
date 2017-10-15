using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//Aquí tenemos nuestro main, desde él simplemente llamaremos al método Empezar de Gmuebles
namespace GestionDeMuebles
{
    class Program
    {
        static void Main(string[] args)
        {
            Gmuebles g = new Gmuebles();

            g.Empezar();
        }
    }
}
