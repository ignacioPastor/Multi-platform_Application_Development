// (3.5.4) Crea un programa que use el operador condicional para dar
// a una variable llamada "ambosPares" (booleana) el valor "true" si dos
// números introducidos por el usuario son pares, o "false" si alguno es impar.

using System;
public class Ejercicio_3_5_4
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
			
			ambosPares = n1%2==0&&n2%2==0 ? true:false;
			if(ambosPares)
				Console.WriteLine("Ambos son pares");
			else
				Console.WriteLine("Almenos uno es impar");
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
