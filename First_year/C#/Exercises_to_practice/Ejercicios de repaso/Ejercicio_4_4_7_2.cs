// (4.4.7.2) Un programa que pida al usuario varios números separados
// por espacios y muestre su suma.

using System;
public class Ejercicio_4_4_7_2
{
	public static void Main()
	{
		string numeros;
		short suma=0;
		
		Console.WriteLine("Introduce varios números separados por espacios");
		numeros=Console.ReadLine();
		
		string[] numerosSeparados = numeros.Split(' ');
		
		for (ushort i = 0; i < numerosSeparados.Length; i++)
		{
			suma+=Convert.ToInt16(numerosSeparados[i]);
		}
		Console.WriteLine("La suma de los números introducidos es {0}", suma);
	}
}
