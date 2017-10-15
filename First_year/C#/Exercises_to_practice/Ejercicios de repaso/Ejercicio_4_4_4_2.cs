// (4.4.4.2) Un programa que te pida tu nombre y lo muestre en pantalla
// como un triángulo creciente.

using System;
public class Ejercicio_4_4_4_2
{
	public static void Main()
	{
		string nombre;
		
		Console.WriteLine("Introduce tu nombre");
		nombre=Console.ReadLine();
		
		for (byte i = 1; i <= nombre.Length; i++)
		{
			Console.WriteLine("{0}", nombre.Substring(0,i));
		}
		
	}
}
