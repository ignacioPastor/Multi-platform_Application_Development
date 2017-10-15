// (2.2.6.5) Dibuja un triángulo de asteriscos descendente.
// Por ejemplo, si el usuario escoge "4" como tamaño, la primera fila
// tendrá 4 asteriscos, la segunda tendrá 3, la siguiente tendrá 2 y la
// última tendrá 1.

using System;
public class Ejercicio_2_2_6_5
{
	public static void Main()
	{
		int tamanyo;
		
		Console.WriteLine("Introduce el tamaño del triángulo");
		tamanyo=Convert.ToInt32(Console.ReadLine());
		
		for(int i=tamanyo; i>0; i--)
		{
			for(int j=0; j<i; j++)
			{
				Console.Write("*");
			}
			Console.WriteLine();
		} 
	}
}
