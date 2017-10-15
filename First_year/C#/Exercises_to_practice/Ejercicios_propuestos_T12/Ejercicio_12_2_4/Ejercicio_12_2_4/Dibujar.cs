using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_12_2_4
{
    class Dibujar
    {
        bool salir = false;
        int x = 0;
        int y = 0;
        int yAyuda;
        string lineaLectura;
        string nuevoCaracter = "patatu";
        string[] itemArchivoPartido;

        StreamWriter ficheroEscritura;
        StreamReader ficheroLectura;

        ConsoleKeyInfo tecla;

        List<item> listaItems = new List<item>();

        public void Proceso()
        {
            do
            {
                Console.SetCursorPosition(x, y);
                    tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.Escape) // Salir
                {
                    salir = true;
                }
                else if (tecla.Key == ConsoleKey.LeftArrow) // Mover izquierda
                {
                    if (x > 0)
                        x--;
                }
                else if (tecla.Key == ConsoleKey.RightArrow) //Mover derecha
                {
                    if (x < Console.BufferWidth - 1)
                        x++;
                }
                else if (tecla.Key == ConsoleKey.UpArrow) //Mover hacia arriba
                {
                    if (y > 0)
                        y--;
                }
                else if (tecla.Key == ConsoleKey.DownArrow) //Mover abajo
                {
                    if (y < Console.BufferHeight - 1)
                        y++;
                }
                else if (tecla.Key == ConsoleKey.F1) //Mostrar menú de ayuda
                {
                    imprimirMenuAyuda();
                }
                else if (tecla.Key == ConsoleKey.F2) //Guardar dibujo en fichero
                {
                    ficheroEscritura = File.CreateText("guardadoDibujo.txt");
                    guardarEnFichero();
                    ficheroEscritura.Close();
                }
                else if (tecla.Key == ConsoleKey.F3) //Cargar dibujo desde fichero
                {
                    if (File.Exists("guardadoDibujo.txt"))
                    {
                        while (listaItems.Count > 0)
                            listaItems.RemoveAt(0);
                        ficheroLectura = File.OpenText("guardadoDibujo.txt");
                        cargarDibujo();
                        ficheroLectura.Close();
                    }
                    else
                    {
                        Console.Clear();
                        imprimirCentrado("Ha habido un error al cargar la página", 13);
                        imprimirCentrado("Pulsa cualquier tecla para continuar", 14);
                        Console.ReadKey(true);
                    }
                }
                else
                {
                    nuevoCaracter = Convert.ToString(tecla.KeyChar);
                    listaItems.Add(new item(nuevoCaracter, x, y));
                }
                Console.Clear();
                    dibujarItems();
                if(salir == true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                }
            }
            while (salir == false);
        }
        public void dibujarItems()
        {
            for (int i = 0; i < listaItems.Count; i++)
            {
                Console.SetCursorPosition(listaItems[i].GetX(), listaItems[i].GetY());
                Console.Write(listaItems[i].GetAItem());
            }
        }
        public void imprimirMenuAyuda()
        {
            Console.Clear();
            yAyuda = 10;
            imprimirCentrado("Mueve el cursor con las flechas del teclado,", yAyuda);
            yAyuda++;
            imprimirCentrado("pulsa una letra o caracter para dibujar.", yAyuda);
            yAyuda++;
            imprimirCentrado("Pulsa F1 para mostrar ayuda.", yAyuda);
            yAyuda++;
            imprimirCentrado("Pulsa F2 para guardar el dibujo", yAyuda);
            yAyuda++;
            imprimirCentrado("Pulsa F3 para cargar el dibujo", yAyuda);
            yAyuda++;
            imprimirCentrado("Pulsa cualquier tecla para salir volver al dibujo.", yAyuda);
            yAyuda++;
            Console.ReadKey();
        }
        public void imprimirCentrado(string texto, int yAyudaC)
        {
            Console.SetCursorPosition((Console.BufferWidth / 2) - (texto.Length / 2), yAyudaC);
            Console.Write(texto);
        }

        public void guardarEnFichero()
        {
            for (int i = 0; i < listaItems.Count; i++)
            {
                ficheroEscritura.Write(listaItems[i].GetX() + "," + listaItems[i].GetY() + "," + listaItems[i].GetAItem());
                ficheroEscritura.WriteLine();
            }
        }
        public void cargarDibujo()
        {
            do
            {
                lineaLectura = ficheroLectura.ReadLine();
                if (lineaLectura != null)
                {
                    itemArchivoPartido = lineaLectura.Split(',');
                    listaItems.Add(new item(itemArchivoPartido[2], Convert.ToInt16(itemArchivoPartido[0]), Convert.ToInt16(itemArchivoPartido[1])));
                }
            }
            while (lineaLectura != null);   
        }
    }
}
