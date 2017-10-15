// (5.9.1.1) Crea un programa que imite el lanzamiento de un dado,
// generando un número al azar entre 1 y 6.

using System;
public class Ejercicio_5_9_1_1
{
	public static void Main()
	{
		Random dado = new Random();
		string opcion;
		do
		{
			Console.WriteLine("Pulsa una tecla para tirar el dado, teclea \"salir\" para salir del programa");
			opcion=Console.ReadLine();
			Console.WriteLine(dado.Next(1, 7));
		}
		while(opcion!="salir");	
	}
}
