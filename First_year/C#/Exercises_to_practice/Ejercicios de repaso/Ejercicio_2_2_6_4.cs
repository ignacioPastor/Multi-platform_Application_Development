// (2.2.6.4) Crea un triángulo de asteriscos, que mostrará uno en la
// primera fila, dos en la segunda, tres en la tercera y así
// sucesivamente, hasta llegar al tamaño indicado por el usuario.

using System;
public class Ejercicio_2_2_6_4
{
	public static void Main()
	{
		int tamanyo;
		
		Console.WriteLine("Introduce el tamaño del triángulo");
		tamanyo=Convert.ToInt32(Console.ReadLine());
		
		for(int i=0; i<tamanyo; i++)
		{
			for(int j=0; j<tamanyo; j++)
			{
				if(j<=i)
					Console.Write("*");
			}
			Console.WriteLine();
		}
	}
}
