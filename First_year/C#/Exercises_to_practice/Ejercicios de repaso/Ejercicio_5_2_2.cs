// (5.2.2) Crea una función llamada "DibujarCuadrado3x3", que dibuje un cuadrado
// formato por 3 filas con 3 asteriscos cada una. Incluye un "Main" para probarla.

using System;
public class Ejercicio_5_2_2
{
	public static void DibujarCuadrado3x3()
	{
		byte i, j;
		
		for (i = 0; i < 3; i++)
		{
			for(j=0; j<3; j++)
			{
				Console.Write("*");
			}
			Console.WriteLine();
		}
		
	}
	
	public static void Main()
	{
		DibujarCuadrado3x3();
	}
}
