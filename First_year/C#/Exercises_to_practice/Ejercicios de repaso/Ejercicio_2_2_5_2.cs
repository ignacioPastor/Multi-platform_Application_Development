// (2.2.5.2) Crea un programa escriba 4 veces los números del 1 al 5,
// en una misma línea, usando "while": 12345123451234512345.

using System;
public class Ejercicio_2_2_5_2
{
	public static void Main()
	{
		int i=0, j=1;
		
		while(i<4)
		{
			while(j<=5)
			{
				Console.Write(j);
				j++;
			}
			j=1;
			i++;
		}
		Console.WriteLine();
	}
}
