// Practica Evaluable Tema2
// Ejercicio 4

using System;
public class PracT2_E4
{
	public static void Main()
	{
		int filas;
		
		Console.WriteLine("Introduce un número impar de filas");
		filas=Convert.ToInt32(Console.ReadLine());
		
		if(filas%2==0)
			Console.WriteLine("Número de filas incorrecto");
		else
		{
			for(int i=0; i<filas; i++)
			{
				for(int j=0; j<filas; j++)
				{
					if(j==filas/2-i||j==filas/2+i||i==filas/2+j||j==filas/2+filas-1-i)
						Console.Write("*");
					else Console.Write(" ");
				}
				Console.WriteLine();
			}
			
			
			
			
		}
	}
}
