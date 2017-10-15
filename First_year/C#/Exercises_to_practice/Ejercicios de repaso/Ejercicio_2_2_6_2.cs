// (2.2.6.2) Crea un programa que pida al usuario el ancho
// (por ejemplo, 4) y el alto (por ejemplo, 3) y escriba un rectángulo
// formado por esa cantidad de asteriscos.

using System;
public class Ejercicio_2_2_6_2
{
	public static void Main()
	{
		int alto, ancho;
		
		Console.WriteLine("Introduce el alto del rectángulo");
		alto=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce el ancho del rectángulo");
		ancho=Convert.ToInt32(Console.ReadLine());
		
		for(int i=0; i<alto; i++)
		{
			for(int j=0; j<ancho; j++)
			{
				Console.Write("*");
			}
			Console.WriteLine();
		}
	}
}
