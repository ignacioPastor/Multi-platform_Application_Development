// (3.2.3.5) Crea un programa que muestre los primeros 20 valores
// de la función y = x2 - 1

using System;
public class Ejercicio_3_2_3_5
{
	public static void Main()
	{
		int y, x;
		
		Console.WriteLine("Programa para resolver la ecuación y=x2-1");
		Console.WriteLine("Introduce el valor de \"x\"");
		x=Convert.ToInt32(Console.ReadLine());
		
		y=(x*x)-1;
		Console.WriteLine("\"y\" vale {0}", y);
	}
}
