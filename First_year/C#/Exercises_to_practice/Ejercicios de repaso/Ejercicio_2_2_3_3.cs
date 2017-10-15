// (2.2.3.3) Crea un programa que muestre los números del 100 al 200
// (ambos incluidos) que sean divisibles entre 7 y a la vez entre 3.

using System;
public class Ejercicio_2_2_3_3
{
	public static void Main()
	{
		for (int i=100; i<=200; i++)
		{
			if(i%7==0&&i%3==0)
				Console.Write("{0} ", i);
		}
		Console.WriteLine();
	}
}
