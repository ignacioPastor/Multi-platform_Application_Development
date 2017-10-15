// (2.2.6.3) Haz un programa que dibuje un cuadrado de asteriscos, cuyo
// ancho (y alto, que tendrá el mismo valor) será introducido por el usuario.

using System;
public class Ejercicio_2_2_6_3
{
	public static void Main()
	{
		int lado;
		
		Console.WriteLine("Introduce el lado del cuadrado");
		lado=Convert.ToInt32(Console.ReadLine());
		
		for(int i=0; i<lado; i++)
		{
			for(int j=0; j<lado; j++)
			{
				Console.Write("*");
			}
			Console.WriteLine();
		}
	}
}
