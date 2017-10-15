using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
(12.3.2) Crea un programa que cree un fichero de texto a partir del contenido
de todos los ficheros de texto existentes en la carpeta actual.
    */
namespace Ejercicio_12_3_2
{
    class Aplicacion
    {
        DirectoryInfo dirActual = new DirectoryInfo(".");
        

        StreamReader ficheroLectura;
        StreamWriter ficheroEscritura;
        string linea;
        public void Lanzar()
        {

            FileInfo[] ficheros = dirActual.GetFiles("*.txt");
            
                ficheroEscritura = File.AppendText("AquiEscribo.txt");
            
            for (int i = 0; i <ficheros.Length; i++)
            {
                ficheroLectura = File.OpenText(ficheros[i].Name);
                do
                {
                    linea = ficheroLectura.ReadLine();
                    if(linea != null)
                    {
                        ficheroEscritura.WriteLine(linea);
                    }
                }
                while (linea != null);
                ficheroLectura.Close();
            }
            ficheroEscritura.Close();
        }
    }
}
