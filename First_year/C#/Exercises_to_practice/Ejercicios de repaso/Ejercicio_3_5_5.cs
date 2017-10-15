// (3.5.5) Crea una versión alternativa del ejercicio 3.5.4,
// que use "if" en vez del operador condicional.

using System;
public class Ejercicio_3_5_5
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
			
			if(n1%2==0&&n2%2==0)
				ambosPares=true;
			else
				ambosPares=false;
				
			if(ambosPares)
				Console.WriteLine("Ambos son pares");
			else
				Console.WriteLine("Al menos uno es impar");
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
