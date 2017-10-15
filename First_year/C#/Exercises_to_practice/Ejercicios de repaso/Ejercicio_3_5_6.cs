// (3.5.6) Crea una versión alternativa del ejercicio 3.5.4,
// que asigne directamente el valor al booleano a partir de una comparación.

using System;
public class Ejercicio_3_5_6
{
	public static void Main()
	{
		try
		{
			short n1, n2;
			bool ambosPares;
			
			Console.WriteLine("Introduce un número");
			n1=Convert.ToInt16(Console.ReadLine());
			Console.WriteLine("Introduce un segundo número");
			n2=Convert.ToInt16(Console.ReadLine());
			
			ambosPares= n1%2==0 && n2%2==0;
			if(ambosPares)
				Console.WriteLine("Ambos son pares");
			else
				Console.WriteLine("Almenos uno no es par");
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
