// Practica Evaluable Tema2
// Ejercicio 3

using System;
public class PracT2_E3
{
	public static void Main()
	{
		int numero, factorial=1;
		
		Console.WriteLine("Introduce el número del cual quieras calcular el factorial");
		numero=Convert.ToInt32(Console.ReadLine());
		
		Console.Write("El factorial de {0} se calcularía multiplicando: ", numero);
		for(int i=0; i<numero; i++)
		{
			factorial=factorial*(numero-i);
			Console.Write("{0} ", numero-i);
		}
		Console.WriteLine();
		Console.WriteLine("Y el factorial de {0} es {1}", numero, factorial);
	}
}
