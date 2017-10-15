// (2.2.5.1) Crea un programa escriba 4 veces los números del 1 al 5,
// en una misma línea, usando "for": 12345123451234512345.

using System;
public class Ejercicio_2_2_5_1
{
	public static void Main()
	{
		for(int i=0; i<4; i++)
		{
			for(int j=1; j<=5; j++)
			{
				Console.Write(j);
			}
		}
		Console.WriteLine();
	}
}
