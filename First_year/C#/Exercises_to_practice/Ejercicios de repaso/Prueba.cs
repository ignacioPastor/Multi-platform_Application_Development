// prueba 

using System;
public class Prueba
{
	public static void Main()
	{
		short n;
		
		Console.WriteLine("Introduce el número para calcular su raíz cuadrada");
		n=Convert.ToInt16(Console.ReadLine());
		
		Console.WriteLine(Math.Pow(n,2));
		
	}
}
