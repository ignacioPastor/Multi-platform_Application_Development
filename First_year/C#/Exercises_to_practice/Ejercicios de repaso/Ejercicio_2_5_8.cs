// (2.5.8) Crea un programa que "dibuje" un triángulo creciente,
// alineado a la derecha, con la altura que indique el usuario.

using System;
public class Ejercicio_2_5_8
{
	public static void Main()
	{
		int altura;
		
		Console.WriteLine("Introduce la altura del triángulo");
		altura=Convert.ToInt32(Console.ReadLine());
		
		for(int i=0; i<altura; i++)
		{
			for(int j=0; j<altura; j++)
			{
				if(j>=altura-1-i)
					Console.Write("*");
				else Console.Write(" ");
			}
			Console.WriteLine();
		}
	}
}
