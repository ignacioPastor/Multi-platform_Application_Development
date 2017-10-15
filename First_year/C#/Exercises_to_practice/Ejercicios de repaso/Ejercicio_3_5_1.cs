// (3.5.1) Crea un programa que use el operador condicional para dar a
//  una variable llamada "iguales" (booleana) el valor "true" si los dos
// números que ha tecleado el usuario son iguales, o "false" si son distintos.

using System;
public class Ejercicio_3_5_1
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
			
			iguales = n1==n2 ? true:false;
			if(iguales)
				Console.WriteLine("Son iguales");
			else
				Console.WriteLine("No son iguales");
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
