// (4.4.3.1) Un programa que te pida tu nombre y lo muestre en pantalla separando
// cada letra de la siguiente con un espacio. Por ejemplo, si tu nombre es "Juan",
// debería aparecer en pantalla "J u a n".

using System;
public class Ejercicio_4_4_3_1
{
	public static void Main()
	{
		string nombre;
		
		Console.WriteLine("Introduce tu nombre");
		nombre=Console.ReadLine();
		
		for (byte i = 0; i < nombre.Length; i++)
		{
			Console.Write("{0} ", nombre[i]);
		}
		Console.WriteLine();
	}
}
