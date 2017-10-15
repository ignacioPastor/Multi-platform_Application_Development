// (3.5.3) Crea una versión alternativa del ejercicio 3.5.1, que asigne
// directamente el valor al booleano a partir de una comparación.

using System;
public class Ejercicio_3_5_3
{
	public static void Main()
	{
		try
		{
			int n1, n2;
			bool iguales;
			
			Console.WriteLine("Introduce un número");
			n1=Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Introduce un segundo número");
			n2=Convert.ToInt32(Console.ReadLine());
			
			iguales=n1==n2;
			if(iguales)
				Console.WriteLine("Los números son iguales");
			else
				Console.WriteLine("Los números no son iguales");
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
