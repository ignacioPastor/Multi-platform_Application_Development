// (3.5.2) Crea una versión alternativa del ejercicio 3.5.1,
// que use "if" en vez del operador condicional.

using System;
public class Ejercicio_3_5_2
{
	public static void Main()
	{
		try
		{
			int n1, n2;
			bool iguales=false;
			
			Console.WriteLine("Introduce un número");
			n1=Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Introduce otro número");
			n2=Convert.ToInt32(Console.ReadLine());
			
			if(n1==n2)
				iguales=true;
			else if(n1!=n2)
				iguales=false;
			
			if(!iguales)
				Console.WriteLine("No son iguales");
			else
				Console.WriteLine("Son iguales");
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
