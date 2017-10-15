// (4.4.4.3) Un programa que te pida tu nombre y lo muestre en pantalla
// como un triángulo creciente desde la derecha.

using System;
public class Ejercicio_4_4_4_3
{
	public static void Main()
	{
		string nombre;
		
		Console.WriteLine("Introduce tu nombre");
		nombre=Console.ReadLine();
		
		
			for (int j = nombre.Length; j>=0; j--)
			{
				for (int i = j; i > 0; i--)
				{
					Console.Write(" ");
				}
				
				Console.WriteLine("{0}", nombre.Substring(j));
			}
		
		
	}
}
